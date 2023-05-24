using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    
    public GameObject plate;
    List<Animator> cubeanimations = new List<Animator>();
    
    public void Start(){
        
        cubeanimations.Add(plate.transform.GetChild(0).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(1).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(2).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(3).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(4).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(5).GetComponent<Animator>());
        
    }
    
    public void Update(){
        
        if(Input.GetKeyDown("space")){
            
            cubeanimations[0].Play("v1fold");
            cubeanimations[2].Play("v3fold");
            cubeanimations[3].Play("v4fold");
            cubeanimations[4].Play("leftfold");
            cubeanimations[5].Play("rightfold");
            
            /*
            for(int i = 0; i < 6; i++){
                
                cubeanimations[i].Play();
                
            }
             */
            
        }
        
        if(Input.GetKeyDown("c")){
            
            cubeanimations[0].Play("v1unfold");
            cubeanimations[2].Play("v3unfold");
            cubeanimations[3].Play("v4unfold");
            cubeanimations[4].Play("leftunfold");
            cubeanimations[5].Play("rightunfold");
            
        }
        
    }
    

    
}
