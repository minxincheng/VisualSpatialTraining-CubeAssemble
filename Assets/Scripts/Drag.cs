using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    PlateController plateControl;
    
    //the camera that emits radiation
    private Camera cam;
    public GameObject plate;
    //objects colliding with rays
    public GameObject currentOption;
    private GameObject[] otherOptions;
    
    private Vector3 screenSpace;
    public bool isDrage = false;
    
    void Start()
    {
        cam = Camera.main;
        
        currentOption = null;
        
        plateControl = plate.GetComponent<PlateController>();
        
    }

    void Update ()
    {
      if(Input.GetMouseButton(0))
      {
          
          MouseDown();
          
     }
      
      if(Input.GetMouseButtonUp(0)){
          
          MouseUp();

      }
      
      currentOption = GameObject.FindWithTag("Current") != null ? GameObject.FindWithTag("Current") : null;
      otherOptions = GameObject.FindGameObjectsWithTag("Options");
      
      //plateControl.isDrage = isDrage;
      
      if(currentOption != null){
          
          plateControl.currentOption = currentOption;
                
      }
      else{
          plateControl.currentOption = null;
      }

    }
    
    public void MouseDown(){
        
        //overall initial position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //ray from camera to click coordinate
        RaycastHit hitInfo;
        
        if (isDrage == false)
        {
            
          if(Physics.Raycast (ray, out hitInfo))
          {
              
            //The scribed rays can only be seen in the scene view
            Debug.DrawLine(ray.origin, hitInfo.point);
            
            hitInfo.collider.gameObject.tag = hitInfo.collider.gameObject.tag == "Options" ? "Current" : hitInfo.collider.gameObject.tag;
                
            if(currentOption != null){
                
                screenSpace = cam.WorldToScreenPoint(currentOption.transform.position);
                
            }
            
          }
          
          Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
          Vector3 currentPosition = cam.ScreenToWorldPoint(currentScreenSpace);
          
          if (currentOption != null){
              
              currentOption.transform.position = new Vector3(currentPosition.x, currentPosition.y, -0.05f);
              foreach(GameObject otherOption in otherOptions){
                  
                  otherOption.GetComponent<BoxCollider>().enabled = false;
                  
              }
              
          }
          
          isDrage = true;
          
        }
        else{

            isDrage = false;
            
        }
    }
    
    public void MouseUp(){
        
          isDrage = false;
          plateControl.dragging = false;
          
          plateControl.Check();
          
          foreach(GameObject otherOption in otherOptions){
              
              otherOption.GetComponent<BoxCollider>().enabled = true;
              
          }
          
          
    }

}
