﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose_Connect : MonoBehaviour
{
    public bool flipSnapAxis;

    private GameObject lastHoseSocket;


    //Snap the end of the hose to the connector
    public void snap()
    {
        // Return if nowhere to snap to
        if (lastHoseSocket == null)
            return;

        this.transform.position = lastHoseSocket.transform.position;
        Vector3 lookAxis = (flipSnapAxis) ? lastHoseSocket.transform.up : -lastHoseSocket.transform.up;  // flip for the other end piece of the hose
        this.transform.rotation = Quaternion.LookRotation(lookAxis, lastHoseSocket.transform.forward);
        Vector3 currentEulerAngles = this.transform.rotation.eulerAngles; // flip another 180 for reasons
        this.transform.rotation = Quaternion.Euler(currentEulerAngles.x, currentEulerAngles.y + 180.0f, currentEulerAngles.z);
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    //When it is triggered do stuff
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HoseSocket")
        {
            lastHoseSocket = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HoseSocket")
        {
            lastHoseSocket = null;
        }
    }


    //Unsnap the hose from the connector
    //Called on the prefab in the interactable
    public void unsnap()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
    }


    public void makeParent()
    {
        this.transform.parent.parent = GameObject.Find("Player").transform;
    }

    public void unParent()
    {
        this.transform.parent.parent = null;
    }

}
