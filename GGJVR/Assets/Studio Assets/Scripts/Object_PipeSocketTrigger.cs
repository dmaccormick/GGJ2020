using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_PipeSocketTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");

        //Check to see if the object trigger is correct = pipe
        //Increment collider counter
        if (other.CompareTag("Pipe"))
        {
            GetComponentInParent<Object_PipeSocket>().IncreaseColliderCount();
        }

    }
}
