using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Net.Sockets;

public class SpatialTaskController : MonoBehaviour
{
    
    DataHandler dataHandler;
    GlobalControl globalControl;
    PlateController plateControl;
    OptionList optionList;

    public GameObject plate;
    public GameObject hidcube;
    private GameObject finger;
    public List<GameObject> cube;
    
    // plate option
    List<string> faceoption = new List<string>();
    List<string> faceoption_ = new List<string>();
    List<string> hidfaceoption = new List<string>();
    List<int> correction = new List<int>();
    private string draging, placing;
    public int checking, submitting;
    private GameObject[] options;
    //private GameObject currentOption;
    //private GameObject[] otherOptions;
    public GameObject virtualHand;
    public GameObject confirmQuad;
    
    public void Start(){
        
        globalControl = GlobalControl.Instance;
        dataHandler = GetComponent<DataHandler>();
        plateControl = plate.GetComponent<PlateController>();
        optionList = GetComponent<OptionList>();
        
        optionList.Initialize();

        if (GlobalControl.Instance.handOption == 0)
        {

            cube[0].transform.position = new Vector3(-9.5f, 8f, 0f);
            cube[1].transform.position = new Vector3(-9.5f, 5f, 0f);
            cube[2].transform.position = new Vector3(-9.5f, 2f, 0f);

        }
        else
        {
            cube[0].transform.position = new Vector3(5f, 8f, 0f);
            cube[1].transform.position = new Vector3(5f, 5f, 0f);
            cube[2].transform.position = new Vector3(5f, 2f, 0f);
        }

        faceoption.Add(GlobalControl.Instance.v1);
        faceoption.Add(GlobalControl.Instance.v2);
        faceoption.Add(GlobalControl.Instance.v3);
        faceoption.Add(GlobalControl.Instance.v4);
        faceoption.Add(GlobalControl.Instance.left);
        faceoption.Add(GlobalControl.Instance.right);

        SetGoal();
        
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        
        hidfaceoption.Add(null);
        hidfaceoption.Add(null);
        hidfaceoption.Add(null);
        hidfaceoption.Add(null);
        hidfaceoption.Add(null);
        hidfaceoption.Add(null);
        
        correction.Add(0);
        correction.Add(0);
        correction.Add(0);
        correction.Add(0);
        correction.Add(0);
        correction.Add(0);
        
        confirmQuad.SetActive(false);
        
        Initialize();
        
    }
    
    public void Update(){
        
        finger = GameObject.FindWithTag("Index");
        
        for(int i = 0; i < 6; i ++){
            
            faceoption_[i] = plateControl.takenOptions[i];
            
        }
        
        CheckFaces();
        //OptionsControl();
        GatherContinuousData();
        
    }

    public void Initialize(){
        
        dataHandler.dataWritten = false;
        
        if(globalControl.recordingData){
            
            StartRecording();
            
        }
        
        options = GameObject.FindGameObjectsWithTag("Options");
        
        Debug.Log("Initialized");
        
    }
    
    public void SetGoal(){
        
        for(int i = 0; i < 6; i ++){
            
            optionList.Greet(faceoption[i]);
            
            foreach(GameObject c in cube){
                
                GameObject face = Instantiate(optionList.face, c.transform.GetChild(i).transform.position, c.transform.GetChild(i).transform.rotation);
                face.transform.localScale = new Vector3(face.transform.localScale.x * 20, face.transform.localScale.y * 20, face.transform.localScale.z * 20);
                face.transform.SetParent(c.transform.GetChild(i).transform);
                face.transform.localPosition = optionList.relativePos;
                face.gameObject.layer = c.layer;
                
            }
        }
    }
    
    public void CheckFaces(){

        for(int i = 0; i < 6; i++){
            
            if(hidfaceoption[i] != faceoption_[i]){
                
                optionList.Greet(faceoption_[i]);
                SetCube(i);
                
            }

            if (hidcube.transform.GetChild(i).childCount != 0)
            {
                hidcube.transform.GetChild(i).transform.GetChild(0).gameObject.layer = 5;
            }
            
        }
        
    }
    
    public void SetCube(int i){
        
        Vector3 offset = new Vector3(0, 0, 0.002f);
        
        if(faceoption_[i] != null){
            
            if(hidcube.transform.GetChild(i).childCount == 0){
                
                GameObject face = Instantiate(optionList.face, hidcube.transform.GetChild(i).transform.position + offset, hidcube.transform.GetChild(i).transform.rotation);
                face.transform.SetParent(hidcube.transform.GetChild(i).transform);
                face.transform.localPosition = optionList.relativePos;
                face.gameObject.layer = hidcube.layer;
                hidfaceoption[i] = faceoption_[i];
                
            }
            
        }
        else{
            
            if(hidcube.transform.GetChild(i).transform.childCount != 0){
                
                UnityEngine.Object.Destroy(hidcube.transform.GetChild(i).transform.GetChild(0).gameObject);
                hidfaceoption[i] = null;

            }
        }
        
    }
    
    private void StartRecording(){
        
        dataHandler.recordHeaderInfo(GlobalControl.Instance.hand.ToString(), faceoption[0], faceoption[1], faceoption[2], faceoption[3], faceoption[4], faceoption[5]);
        
    }
    
    private void GatherContinuousData(){
        
        string v1 = faceoption_[0] == null ? "NA" : faceoption_[0];
        string v2 = faceoption_[1] == null ? "NA" : faceoption_[1];
        string v3 = faceoption_[2] == null ? "NA" : faceoption_[2];
        string v4 = faceoption_[3] == null ? "NA" : faceoption_[3];
        string left = faceoption_[4] == null ? "NA" : faceoption_[4];
        string right = faceoption_[5] == null ? "NA" : faceoption_[5];
        
        draging = GameObject.FindWithTag("Current") == null ? "NA" : GameObject.FindWithTag("Current").name.ToString();
        Vector3 fingerTipPos = finger == null ? new Vector3(0, 0, 0) : finger.transform.position;
        
        for(int i = 0; i < 6; i ++){
            
            correction[i] = faceoption_[i] == faceoption[i] ? 1 : 0;
            
        }
        
        if(globalControl.recordingData){
        
            dataHandler.recordContinuous(Time.time, submitting, checking, v1, v2, v3, v4, left, right, draging, correction[0], correction[1], correction[2], correction[3], correction[4], correction[5], fingerTipPos);
            
        }
        
        
    }
    /*
    public void OptionsControl(){
        
        currentOption = GameObject.FindWithTag("Current");
        otherOptions = GameObject.FindGameObjectsWithTag("Options");
        
        if(currentOption != null){
            
            foreach(GameObject otherOption in otherOptions){
                
                otherOption.GetComponent<BoxCollider>().enabled = false;
                
            }
            
        }
        else{
            
            if(checking == 0){
                
                foreach(GameObject otherOption in otherOptions){
                    
                    otherOption.GetComponent<BoxCollider>().enabled = true;
                    
                }
                
            }
            else{
                
                foreach(GameObject otherOption in otherOptions){
                    
                    otherOption.GetComponent<BoxCollider>().enabled = false;
                    
                }
                
            }
        }
        
    }
    */
    
    public void Paused(){
        
        confirmQuad.SetActive(true);
        submitting = 1;
        
        plate.GetComponent<PlateController>().enabled = false;
        
        foreach(GameObject option in options){
            
            option.GetComponent<BoxCollider>().enabled = false;
            option.GetComponent<OptionMonitor>().enabled = false;
            
        }
        
    }
    
    public void Resume(){
        
        confirmQuad.SetActive(false);
        submitting = 0;
        
        plate.GetComponent<PlateController>().enabled = true;
        
        Invoke("ResumeOptions", 2f);
        
    }
    
    public void ResumeOptions(){
        
        
        foreach(GameObject option in options){
            
            option.GetComponent<BoxCollider>().enabled = true;
            option.GetComponent<OptionMonitor>().enabled = true;
        }

    }
    
    private void OnApplicationQuit(){
        
        QuitTask();
        
    }
    
    public void QuitTask(){
        
        dataHandler.WriteDataToFiles();
        SceneManager.LoadScene("Empty");
        
    }
    
}
