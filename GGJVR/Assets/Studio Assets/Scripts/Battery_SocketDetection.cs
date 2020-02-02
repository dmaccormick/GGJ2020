using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_SocketDetection : MonoBehaviour
{
    private GameObject lastBatterySocket;

    public void snap()
    {
        // Return if nowhere to snap to
        if (lastBatterySocket == null)
            return;

        // TODO: Just make the battery a single object and move the one object instead of this handle / body joint setup
        this.transform.parent.position = lastBatterySocket.transform.position;
        this.transform.parent.rotation = Quaternion.LookRotation(-lastBatterySocket.transform.up, lastBatterySocket.transform.forward);
        this.transform.parent.GetComponent<Rigidbody>().isKinematic = true;

        //this.transform.position = lastBatterySocket.transform.position;
        //this.transform.position = new Vector3(lastBatterySocket.transform.position.x, lastBatterySocket.transform.position.y, lastBatterySocket.transform.position.z - 0.05f);
        //this.GetComponent<Rigidbody>().isKinematic = true;


        //// Calculate the new z angle
        //int angleZ = (int)(this.transform.rotation.eulerAngles.z);
        //angleZ += 45;
        //int angle360Z = angleZ % 360;
        //int snapZ = angle360Z / 90;
        //if (snapZ > 3)
        //    snapZ = 3;
        //float newZ = snapZ * 90.0f;

        //// Calculate the new y angle
        //int angleX = (int)(this.transform.rotation.eulerAngles.x);
        //angleX += 90;
        //int angle360X = angleX % 360;
        //int snapX = angle360X / 180;
        //if (snapX > 1)
        //    snapX = 1;
        //float newX = snapX * 180.0f;

        //// Add the angle of the box
        //newX += lastBatterySocket.transform.rotation.eulerAngles.x;

        //// Set the rotation with x to be 0
        //this.transform.rotation = Quaternion.Euler(newX, 0.0f, newZ+90.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BatterySocket")
        {
            Debug.Log("in the battery socket");
            lastBatterySocket = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BatterySocket")
        {
            Debug.Log("out the battery socket");

            lastBatterySocket = null;
        }
    }


    //Unsnap the hose from the connector
    //Called on the prefab in the interactable
    public void unsnap()
    {
        this.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "BatterySocket")
    //    {
    //        Debug.Log("Touching the battery socket");
    //        other.transform.parent.parent = this.transform.parent.parent;
    //    }
    //}
}
