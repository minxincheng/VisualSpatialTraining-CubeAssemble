using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    SpatialTaskController spatialTaskController;
    
    public GameObject plate, hidcube;
    public GameObject checkbutton, finishbutton;
    public bool folded = false;
    List<Animator> cubeanimations = new List<Animator>();
    private Animator plateanimation;

    public void Start(){
        
        spatialTaskController = gameObject.GetComponent<SpatialTaskController>();
        
        cubeanimations.Add(plate.transform.GetChild(0).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(1).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(2).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(3).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(4).GetComponent<Animator>());
        cubeanimations.Add(plate.transform.GetChild(5).GetComponent<Animator>());
        
        plateanimation = plate.GetComponent<Animator>();
        
        finishbutton.SetActive(false);

    }
    
    public void Fold(){
        
        Invoke("CheckCube", 2f);
        folded = true;
        spatialTaskController.checking = 1;
        
        plate.GetComponent<PlateController>().enabled = false;
        
        cubeanimations[0].Play("v1fold");
        cubeanimations[2].Play("v3fold");
        cubeanimations[3].Play("v4fold");
        cubeanimations[4].Play("leftfold");
        cubeanimations[5].Play("rightfold");

        plateanimation.Play("cuberotate");
        
        checkbutton.SetActive(false);
        finishbutton.SetActive(true);
        finishbutton.GetComponent<BoxCollider>().enabled = false;
        
    }
    
    public void UnFold(){
        
        Invoke("FinishedChecking", 2f);
        
        plate.SetActive(true);
        if (GlobalControl.Instance.handOption == 0)
        {
            hidcube.transform.position = new Vector3(-0.1259f, 0.0331f, -0.133743f);

        }
        else
        {

            hidcube.transform.position = new Vector3(0.1952f, 0.0329f, -0.133743f);

        }
        hidcube.transform.rotation = Quaternion.Euler(-6, 5, -5);
        hidcube.SetActive(false);
        spatialTaskController.checking = 0;
        
        plateanimation.Play("cuberotateback");
        
        cubeanimations[0].Play("v1unfold");
        cubeanimations[2].Play("v3unfold");
        cubeanimations[3].Play("v4unfold");
        cubeanimations[4].Play("leftunfold");
        cubeanimations[5].Play("rightunfold");
        
        checkbutton.SetActive(true);
        finishbutton.SetActive(false);
        checkbutton.GetComponent<BoxCollider>().enabled = false;
        
    }
    
    public void CheckCube(){
        
        plate.SetActive(false);
        hidcube.SetActive(true);
        hidcube.layer = 5;
        if (GlobalControl.Instance.handOption == 0)
        {
            hidcube.transform.position = new Vector3(-0.1259f, 0.0331f, -0.133743f);

        }
        else
        {

            hidcube.transform.position = new Vector3(0.1952f, 0.0331f, -0.133743f);

        }
        hidcube.transform.rotation = Quaternion.Euler(-6, 5, -5);

        finishbutton.GetComponent<BoxCollider>().enabled = true;
        
    }
    
    public void FinishedChecking(){
        
        plate.GetComponent<PlateController>().enabled = true;
        folded = false;
        checkbutton.GetComponent<BoxCollider>().enabled = true;
        
    }
}
