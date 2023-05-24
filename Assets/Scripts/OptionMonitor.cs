using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMonitor : MonoBehaviour
{
    PlateController plateControl;
    AnimationController animationController;
    
    public bool move = false;
    public bool release = true;
    public bool folded = false;
    
    public GameObject finger;
    private GameObject[] otherOptions;
    public GameObject currentOption;
    
    public float distance;
    
    public void Start(){
        
        plateControl = GameObject.FindWithTag("Plate").GetComponent<PlateController>();
        animationController = GameObject.Find("GameController").GetComponent<AnimationController>();

    }
    
    void OnTriggerEnter(Collider other){
        
        if(other.transform.tag == "Index"){
            
            move = true;
            release = false;
            gameObject.tag = "Current";
            
        }
        else{
            
            move = false;
            release = true;
            gameObject.tag = "Options";
            
        }
        
    }
    
    void OntriggerExit(Collider other){
        
        move = false;
        release = true;
        
    }
    
    public void Update(){
        
        finger = GameObject.FindWithTag("Index");
        folded = animationController.folded;
        
        if(finger != null){
            
            distance = Mathf.Abs(finger.transform.position.z - gameObject.transform.position.z);
            
        }
        else{
            
            move = false;
            release = true;
            
        }
        
        
        if(move && distance <= 0.08f){
            
            Dragging();
            
        }
        
        if(distance > 0.09f){
            
            release = true;

            if(currentOption != null){
                
                Releasing();
                
            }
            
        }
        
        if(release){
            move = false;
            
        }
        if(move){
            release = false;
        }

         currentOption = GameObject.FindWithTag("Current") != null ? GameObject.FindWithTag("Current") : null;
         otherOptions = GameObject.FindGameObjectsWithTag("Options");
         
        if(otherOptions.Length == 31 && folded == false){
            
            foreach(GameObject otherOption in otherOptions){
                
                otherOption.GetComponent<BoxCollider>().enabled = true;
                
            }
  
        }
        
        if(folded){
            
            foreach(GameObject otherOption in otherOptions){
                
                otherOption.GetComponent<BoxCollider>().enabled = false;
                
            }
            
        }

        
    }
    
    public void Dragging(){
        
        release = false;
        
        if(move){
            
            gameObject.transform.position = new Vector3(finger.transform.position.x, finger.transform.position.y, -0.03f);
            
        }
        
        plateControl.currentOption = this.gameObject;
        
      
        foreach(GameObject otherOption in otherOptions){
            
            otherOption.GetComponent<BoxCollider>().enabled = false;
            
        }
         
         
        
    }
    
    public void Releasing(){
        
        move = false;
        
        
        foreach(GameObject otherOption in otherOptions){
            
            otherOption.GetComponent<BoxCollider>().enabled = true;
                
        }
         
        
        if(release){
            
            plateControl.Check();
            
        }
        
    }
    
}
