using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLeap : MonoBehaviour
{
    public bool test;
    public GameObject finger;

    void OnTriggerStay(Collider other){
        
        if(other.transform.tag == "Index")
        {
            test = true;

        }

    }
    
    void OnTriggerExit(){
        test = false;
    }

    void Update()
    {
        finger = GameObject.FindWithTag("Index");

        if (test)
        {
            Dragging();
        }
    }

    public void Dragging()
    {

        gameObject.transform.position = new Vector3(finger.transform.position.x, finger.transform.position.y, -0.2f);


    }
}
