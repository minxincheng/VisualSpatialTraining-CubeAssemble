using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMonitor2 : MonoBehaviour
{
    PlateController plateControl;
    
    public GameObject finger;
    public float distance;
    public bool move = false;
    
    public void Start(){
        
        plateControl = GameObject.FindWithTag("Plate").GetComponent<PlateController>();
        
    }
    
    void OnTriggerEnter(Collider other){
        
        if(other.tag == "Index"){
            
            move = true;
            gameObject.tag = "Current";
            
        }

    }
    
    void OnTriggerExit(Collider other){
        
        move = false;
        plateControl.Check();
        
    }
    
    public void Update(){
        
        finger = GameObject.FindWithTag("Index");
        
        if(finger != null && gameObject.tag == "Current"){
            
            distance = Mathf.Abs(finger.transform.position.z - gameObject.transform.position.z);
            
        }
        else{
            
            move = false;
        }

        if(move && distance <= 0.5f){
            
            gameObject.transform.position = new Vector3(finger.transform.position.x, finger.transform.position.y, -0.2f);
            plateControl.currentOption = gameObject;
            
        }
        
       // if(distance > 0.5f){
            
        //    move = false;

       // }

    }
}
