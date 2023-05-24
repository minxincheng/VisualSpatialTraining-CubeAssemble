using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Net.Sockets;

public class SpatialTaskController2 : MonoBehaviour
{
    PlateController plateControl;
    OptionList optionList;

    public GameObject plate;
    private GameObject finger;
    
    // plate option
    List<string> faceoption_ = new List<string>();
    private string draging, placing;
    public int checking, submitting;
    private GameObject[] options;
    private GameObject currentOption;
    private GameObject[] otherOptions;
    public GameObject virtualHand;
    
    public void Start(){
        
        plateControl = plate.GetComponent<PlateController>();
        optionList = GetComponent<OptionList>();
        
        optionList.Initialize();
        
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);
        faceoption_.Add(null);

        Initialize();
        
    }
    
    public void Update(){
        
        finger = GameObject.FindWithTag("Index");
        
        for(int i = 0; i < 6; i ++){
            
            faceoption_[i] = plateControl.takenOptions[i];
            
        }

        OptionsControl();
        
    }

    public void Initialize(){
        
        options = GameObject.FindGameObjectsWithTag("Options");
        
        Debug.Log("Initialized");
        
    }

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

}
