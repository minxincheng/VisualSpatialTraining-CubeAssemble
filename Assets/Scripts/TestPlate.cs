using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlate : MonoBehaviour
{
    
    public bool entered = false;
    private GameObject currentOption;
    
    public Vector3 v1, v2, v3, v4, left, right;
    
    public void Start(){
        
        Debug.Log(gameObject.GetComponent<BoxCollider>().center);
    }
    
    void OnTriggerEnter(Collider other){
        
        entered = true;
        currentOption = other.gameObject;
        
    }
    
    void OnTriggerExit(Collider other){
        
        entered = false;
        
    }
}
