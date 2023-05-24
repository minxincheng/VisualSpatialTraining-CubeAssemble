using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plate : MonoBehaviour
{
    public bool entered = false;
    public bool taken = false;
    
    public Vector3 thisPosition;
    public float distance;
    
    private GameObject currentOption;
    public string takenOption;
    
    public void Start(){
        
        currentOption = null;
        takenOption = null;
        
        GetPosition(gameObject.transform.name);
        
    }
    
    public void GetPosition(string name){
        
        switch(name){
            
            case string n when name == "v1":
            thisPosition = new Vector3(-3.2f, 1.85f, 0f);
                break;
            case string n when name == "v2":
            thisPosition = new Vector3(-3.2f, 0.6f, 0f);
                break;
            case string n when name == "v3":
            thisPosition = new Vector3(-3.2f, -0.65f, 0f);
                break;
            case string n when name == "v4":
            thisPosition = new Vector3(-3.2f, -1.9f, 0f);
                break;
            case string n when name == "left":
            thisPosition = new Vector3(-4.45f, 0.6f, -0.0065f);
                break;
            case string n when name == "right":
            thisPosition = new Vector3(-1.95f, 0.6f, 0.0065f);
                break;
            
        }
        
    }
    
    void OnTriggerEnter(Collider other){
        
        if(other.gameObject.tag == "Current"){
            
            entered = true;
            currentOption = other.gameObject;
            
            if(distance <= 1.2f){
                
                taken = true;
                //other.transform.position = new Vector3(thisPosition.x, thisPosition.y, -0.02f);
                currentOption.transform.SetParent(this.gameObject.transform);
                other.GetComponent<BoxCollider>().enabled = false;
                other.transform.tag = "Finish";
                //Invoke("ChangeBack", 1f);
                
            }
            else{
                
                taken = false;
                
            } 
        }
    }

    void OnTriggerExit(Collider other){
        
        entered = false;
        taken = false;
        
    }
    
    void Update(){
        
        if(currentOption != null){
            
            distance = Vector3.Distance(currentOption.transform.position, thisPosition);
            
        }

        if(taken == true || gameObject.transform.childCount > 0){
            
            gameObject.GetComponent<BoxCollider>().enabled = false;
            takenOption = currentOption.name;
            
            gameObject.transform.GetChild(0).transform.position = new Vector3(thisPosition.x, thisPosition.y, -0.02f);

            
        }
        
        if(distance > 1.2f){
            
            taken = false;
            takenOption = null;
            gameObject.transform.DetachChildren();
            gameObject.GetComponent<BoxCollider>().enabled = true;
            
        }
    }
    
    public void ChangeBack(){
        
        if(currentOption != null){
            
            currentOption.transform.tag = "Options";
            currentOption.GetComponent<BoxCollider>().enabled = true;
            
        }
        
    }
    

}
