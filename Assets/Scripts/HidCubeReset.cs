using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidCubeReset : MonoBehaviour
{

    public void Awake()
    {
        if (GlobalControl.Instance.handOption == 0)
        {

            gameObject.transform.position = new Vector3(-0.1259f, 0.0331f, -0.133743f);
            gameObject.transform.rotation = Quaternion.Euler(-6, 5, -5);

        }
        else
        {

            gameObject.transform.position = new Vector3(0.1952f, 0.0329f, -0.133743f);
            gameObject.transform.rotation = Quaternion.Euler(-6, 5, -5);

        }


    }
    /*
    public void Update()
    {
        //grasp = this.GetComponent<InteractionBehaviour>()._justGrasped;

        if (gameObject.transform.position.x  < -0.2f || gameObject.transform.position.x > -0.05f || gameObject.transform.position.y > 0.0875f || gameObject.transform.position.y < -0.007 || gameObject.transform.position.z > -0.1337 || gameObject.transform.position.z < -0.3)
        {

            gameObject.transform.position = new Vector3(-0.1259f, 0.0331f, -0.133743f);
            gameObject.transform.rotation = Quaternion.Euler(-6, 5, -5);

        }

    }
    */
}
