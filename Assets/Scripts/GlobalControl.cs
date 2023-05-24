using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CubeTaskHand { RIGHT, LEFT };

public class GlobalControl : MonoBehaviour
{
    
    public static GlobalControl Instance;
    
    public CubeTaskHand hand;
    
    public string participantID = "";
    
    public int handOption = 0;
    
    public string v1, v2, v3, v4, left, right;
    
    public bool recordingData = true;
    
    private void Awake(){
        
        if(Instance == null){
            
            DontDestroyOnLoad(gameObject);
            Instance = this;
            
        }
        else if (Instance != this){
            
            Destroy(gameObject);
            
        }
        
    }

    
}
