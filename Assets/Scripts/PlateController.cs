using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlateController : MonoBehaviour
{
    public GameObject gameController;
    OptionList optionList;

    List<GameObject> plates = new List<GameObject>();
    List<Vector3> platePoss = new List<Vector3>();
    public List<float> distances = new List<float>();
    public List<bool> takens = new List<bool>();
    public List<string> takenOptions = new List<string>();
    
    public GameObject currentOption, hint;
    public int takenPlate;
    
    public bool dragging = false;
    
    void Awake(){

        if (GlobalControl.Instance.handOption == 0)
        {

            gameObject.transform.position = new Vector3(-0.3f, -2.43f, 0f);

            platePoss.Add(new Vector3(-0.16f, 0.1f, 0f));
            platePoss.Add(new Vector3(-0.16f, 0.039f, 0f));
            platePoss.Add(new Vector3(-0.16f, -0.022f, 0f));
            platePoss.Add(new Vector3(-0.16f, -0.083f, 0f));
            platePoss.Add(new Vector3(-0.221f, 0.039f, 0f));
            platePoss.Add(new Vector3(-0.099f, 0.039f, 0f));

        }
        else
        {

            gameObject.transform.position = new Vector3(0.02f, -2.43f, 0f);

            platePoss.Add(new Vector3(0.16f, 0.1f, 0f));
            platePoss.Add(new Vector3(0.16f, 0.039f, 0f));
            platePoss.Add(new Vector3(0.16f, -0.022f, 0f));
            platePoss.Add(new Vector3(0.16f, -0.083f, 0f));
            platePoss.Add(new Vector3(0.098f, 0.039f, 0f));
            platePoss.Add(new Vector3(0.221f, 0.039f, 0f));

        }

        plates.Add(gameObject.transform.GetChild(0).gameObject);
        plates.Add(gameObject.transform.GetChild(1).gameObject);
        plates.Add(gameObject.transform.GetChild(2).gameObject);
        plates.Add(gameObject.transform.GetChild(3).gameObject);
        plates.Add(gameObject.transform.GetChild(4).gameObject);
        plates.Add(gameObject.transform.GetChild(5).gameObject);
            
        takens.Add(false);
        takens.Add(false);
        takens.Add(false);
        takens.Add(false);
        takens.Add(false);
        takens.Add(false);

        hint.SetActive(false);
        
    }
    
    public void Start(){
        
        optionList = gameController.GetComponent<OptionList>();
        
        distances.Add(0);
        distances.Add(0);
        distances.Add(0);
        distances.Add(0);
        distances.Add(0);
        distances.Add(0);
        
        takenOptions.Add(null);
        takenOptions.Add(null);
        takenOptions.Add(null);
        takenOptions.Add(null);
        takenOptions.Add(null);
        takenOptions.Add(null);
        
    }
    
    public void Update(){
        
        if(currentOption != null){
            
            for(int i = 0; i < 6; i ++){
                
                if(takens[i] == false){
                    
                    distances[i] = Vector3.Distance(currentOption.transform.position, platePoss[i]);
                    
                }
                else{
                    
                    distances[i] = 1000;
                    
                }
                
            }
            
            GetTakenPlate(distances);
            
        }

        if (currentOption != null)
        {
            Hint(distances);
        }
        else
        {

            hint.SetActive(false);

        }

        SelfCheck();

    }

    public void Hint(List<float> distances)
    {
        float mindistance = distances.Min();
        int idx = distances.IndexOf(mindistance);

        if (currentOption != null)
        {
            if (mindistance <= 0.06f)
            {
                hint.SetActive(true);
                hint.transform.position = platePoss[idx];
            }
            else
            {
                hint.SetActive(false);
            }
        }
        else
        {
            hint.SetActive(false); 
        }
    }

    public int GetTakenPlate(List<float> distances){
        
        takenPlate = 100;
        
        for(int i = 0; i < 6; i ++){
            
            float value = float.PositiveInfinity;
            
            if(distances[i] < value){

                value = distances[i];
                
                if(value <= 0.06){
                   takenPlate = i;
                }
                
            }
            else{
                
                takenPlate = 100;
                takens[i] = false;
                
            }
            
        }
        
        return takenPlate;
        
    }
    
    public void Check(){
        
        if(takenPlate != 100){
            
            Take();
            
        }
        else{
            
            SendBack(currentOption);
            
        }
        
    }
    
    public void Take(){
        
        takens[takenPlate] = true;
        takenOptions[takenPlate] = currentOption.name;
        
        currentOption.transform.position = new Vector3(platePoss[takenPlate].x, platePoss[takenPlate].y, -0.002f);
        currentOption.transform.SetParent(plates[takenPlate].transform);
        currentOption.GetComponent<BoxCollider>().enabled = false;
        currentOption.transform.tag = "Finish";
        
        Invoke("ChangeBack", 1f);
        
        SelfCheck();
        
    }
    
    public void SendBack(GameObject sendback){
        
        optionList.MoveBack(sendback.name);
        sendback.transform.position = new Vector3(optionList.col, optionList.row, 0f);
        
        sendback.tag = "Options";
        sendback.GetComponent<BoxCollider>().enabled = true;
        
    }
    
    public void ChangeBack(){
        
        GameObject finished = GameObject.FindWithTag("Finish");
        if(finished != null){
            
            finished.transform.tag = "Options";
            finished.GetComponent<BoxCollider>().enabled = true;
            
        }

    }
    

    public void SelfCheck(){
        
        for(int i = 0; i < 6; i ++){
            
            if(takens[i] == true){
                
                if(plates[i].transform.childCount == 0){
                    
                    takens[i] = false;
                    
                }
                else{
                    
                    if(plates[i].transform.GetChild(0).transform.position.z >= 0){
                        
                        takens[i] = false;
                        plates[i].transform.DetachChildren();
                        
                    }
                    
                    if(GameObject.FindWithTag("Current") == null && Vector3.Distance(plates[i].transform.GetChild(0).transform.position, plates[i].transform.position) > 0.01f){
                        
                        plates[i].transform.GetChild(0).transform.position = new Vector3(platePoss[i].x, platePoss[i].y, -0.002f);
                        
                    }
                    
                }

            }
            else{
                
                takenOptions[i] = null;
                
                if(plates[i].transform.childCount != 0){
                    
                    plates[i].transform.DetachChildren();
                    SendBack(plates[i].transform.GetChild(0).gameObject);
                    
                }
                
            }
            
        }

    }
    
}
