using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminController : MonoBehaviour
{
    Drag dragFunction;
    OptionList optionList;
    PlateController plateControl;

    // each plate
    public GameObject v1, v2, v3, v4, left, right;
    // each face of the cube
    public GameObject plate;
    public List<GameObject> cube;
    
    public GameObject reminder;
    
    // plate option
    List<string> faceoption = new List<string>();
    List<string> faceoption_ = new List<string>();
    //public string test1, test2;

    public void Start(){
        
        dragFunction = GetComponent<Drag>();
        optionList = GetComponent<OptionList>();
        plateControl = plate.GetComponent<PlateController>();
        
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

        faceoption.Add(null);
        faceoption.Add(null);
        faceoption.Add(null);
        faceoption.Add(null);
        faceoption.Add(null);
        faceoption.Add(null);
        
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        
        reminder.SetActive(false);
        
    }
    
    void Update(){
        
        for(int i = 0; i < 6; i ++){
            
            faceoption_[i] = plateControl.takenOptions[i];
            
        }

        CheckFaces();
        
    }
    
    public void CheckFaces(){
        
        for(int i = 0; i < 6; i++){
            
            if(faceoption[i] != faceoption_[i]){
                
                optionList.Greet(faceoption_[i]);
                SetCube(i);
                
            }
            
        }
        
    }

    public void SetCube(int i){
        
        if(faceoption_[i] != null){
            
            foreach(GameObject c in cube){
                
                if(c.transform.GetChild(i).childCount == 0){
                    
                    GameObject face = Instantiate(optionList.face, c.transform.GetChild(i).transform.position, c.transform.GetChild(i).transform.rotation);
                    face.transform.localScale = new Vector3(face.transform.localScale.x * 20, face.transform.localScale.y * 20, face.transform.localScale.z * 20);
                    face.transform.SetParent(c.transform.GetChild(i).transform);
                    face.transform.localPosition = optionList.relativePos;
                    face.gameObject.layer = c.layer;
                    faceoption[i] = faceoption_[i];
                    
                }
                
            }

            
        }
        else{
            
            foreach(GameObject c in cube){
                
                if(c.transform.GetChild(i).transform.childCount != 0){
                    
                    Object.Destroy(c.transform.GetChild(i).transform.GetChild(0).gameObject);
                    faceoption[i] = null;
                    
                }
                
            }
            
        }
        
    }
    
    public void StartGame(){
        
        if(faceoption.Contains(null)){
            
            reminder.SetActive(true);
            Invoke("Resume", 2f);
            
        }
        else{

            GlobalControl.Instance.v1 = faceoption[0];
            GlobalControl.Instance.v2 = faceoption[1];
            GlobalControl.Instance.v3 = faceoption[2];
            GlobalControl.Instance.v4 = faceoption[3];
            GlobalControl.Instance.left = faceoption[4];
            GlobalControl.Instance.right = faceoption[5];
            
            SceneManager.LoadScene("SpatialTask");
            
        }

        
    }
    
    public void Resume(){
        
        reminder.SetActive(false);
        
    }
    
}
