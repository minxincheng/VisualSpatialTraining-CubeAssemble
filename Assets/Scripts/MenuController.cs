using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    private void Start(){
        
        GlobalControl.Instance.participantID = "";
        
    }
    
    public void RecordID(string arg0){
        
        GlobalControl.Instance.participantID = arg0;
        
    }
    
    public void RecordHand(int arg0){
        
        GlobalControl.Instance.handOption = arg0;
        
        switch(arg0){
            
            case 0:
                GlobalControl.Instance.hand = CubeTaskHand.RIGHT;
                break;
            case 1:
                GlobalControl.Instance.hand = CubeTaskHand.LEFT;
                break;
            default:
                GlobalControl.Instance.hand = CubeTaskHand.RIGHT;
                break;
            
        }
        
    }
    
    public void NextScene(){
        
        SceneManager.LoadScene("AdminScene");
        
    }
    
}
