using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FingerDrag : MonoBehaviour
{
    
    PlateController plateControl;
    
    public GameObject plate;
    
    public GameObject currentOption;
    private GameObject[] otherOptions;
    
    public bool isDrage = false;
    
    void Start(){
        
        currentOption = null;
        
    }
    
    void OnTriggerEnter(Collider other){
        
        if(other.transform.tag == "Options"){
            
            other.gameObject.tag = "Current";
            /*
            foreach(GameObject otherOption in otherOptions){
                
                otherOption.GetComponent<BoxCollider>().enabled = false;
                
            }
            */
            isDrage = true;

    }
    
    void OnTriggerExit(){
        
        isDrage = false;
        /*
        plateControl.Check();
        
        foreach(GameObject otherOption in otherOptions){
            
            otherOption.GetComponent<BoxCollider>().enabled = true;
            
        }
         */
        
    }
    
    void Update(){
        
        plateControl = plate.GetComponent<PlateController>();
        
        currentOption = GameObject.FindWithTag("Current") != null ? GameObject.FindWithTag("Current") : null;
        otherOptions = GameObject.FindGameObjectsWithTag("Options");
        
        if(currentOption != null){
            
            currentOption.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
            plateControl.currentOption = currentOption;
            
        }
        
        
    }
    }
    
    /*
    void Update(){
        RaycastHit hitInfo;
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * 50, Color.red);
        
        if(Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * 50, out hitInfo)){
            
            currentOption = hitInfo.collider.gameObject.tag == "Options" || hitInfo.collider.gameObject.tag == "Current" ? hitInfo.collider.gameObject : null;
            currentOption.gameObject.tag = "Current";
            Debug.Log(currentOption.name);
            
        }
        
        Vector3 currentPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.2f);
        
        if(currentOption != null){
            
            currentOption.transform.position = currentPosition;
            
            otherOptions = GameObject.FindGameObjectsWithTag("Options");
            foreach(GameObject otherOption in otherOptions){
                
                otherOption.GetComponent<BoxCollider>().enabled = false;
                
            }
        }
        
    }
     */
    

    
}
