using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    SpatialTaskController spatialTaskController;
    AnimationController animationController;
    
    public bool pushing, pushed;
    private GameObject index;
    
    private float max, min;
    
    void Start(){

        Initiate(gameObject.name); 
        
        GameObject gameController = GameObject.Find("GameController");
        spatialTaskController = gameController.GetComponent<SpatialTaskController>();
        animationController = gameController.GetComponent<AnimationController>();
        
        pushing = false;
        pushed = false;
        min = gameObject.transform.position.z;
        max = min + 0.01f;
        
    }

    public void Initiate(string buttonname)
    {

        switch (buttonname)
        {

            case string bn when buttonname == "CheckButton":
                if (GlobalControl.Instance.handOption == 0)
                {
                    gameObject.transform.position = new Vector3(-0.0945f, -0.1634f, -0.02203f);
                }
                else
                {

                    gameObject.transform.position = new Vector3(0.0978f, -0.1634f, -0.02203f);

                }
                break;

            case string bn when buttonname =="SubmitButton":
                if (GlobalControl.Instance.handOption == 0)
                {
                    gameObject.transform.position = new Vector3(-0.2207f, -0.1634f, -0.0226f);
                }
                else
                {

                    gameObject.transform.position = new Vector3(0.224f, -0.1634f, -0.0226f);

                }
                break;

            case string bn when buttonname == "FinishCheckingButton":
                if (GlobalControl.Instance.handOption == 0)
                {
                    gameObject.transform.position = new Vector3(-0.0945f, -0.1634f, -0.02203f);
                }
                else
                {

                    gameObject.transform.position = new Vector3(0.0978f, -0.1634f, -0.02203f);

                }
                break;

        }

    }
    
    void OnTriggerEnter(Collider other){
        
        if(other.tag == "Index" || other.tag == "Finger"){
            
            pushing = true;
            index = other.gameObject;
            
        }

    }
    
    void OnTriggerExit(Collider other){
        
        pushing = false;
        index = null;

    }
    
    public void FixedUpdate(){
        
        if(gameObject.transform.position.z >= max - 0.002f){
            
            pushed = true;
            pushing = false;
            CheckEvent(gameObject.transform.name);
            
        }
    }
    
    public void Update(){

        if(pushing){
            
            if(index.transform.position.z >= min && index.transform.position.z + 0.002f <= max){
                
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, index.transform.position.z + 0.008f);
                
            }

        }
        else{
            
            if(gameObject.transform.position.z > min){
                
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, min);
                
            }
        }
        
    }
    
    public void CheckEvent(string buttonname){
        
        if(pushed){
            
            switch(buttonname){
                
                case string bn when buttonname == "CheckButton":
                    animationController.Fold();
                    break;
                    
                case string bn when buttonname == "FinishCheckingButton":
                    animationController.UnFold();
                    break;
                    
                case string bn when buttonname == "SubmitButton":
                    spatialTaskController.Paused();
                    break;
                    
                case string bn when buttonname == "Yes":
                    spatialTaskController.QuitTask();
                    break;
                    
               case string bn when buttonname == "No":
                    spatialTaskController.Resume();
                    break;
                
            }
            
            
        }
        
        pushed = false;
        
    }
    
}
