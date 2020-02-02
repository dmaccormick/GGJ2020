using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocketSocket : MonoBehaviour
{
    private GameObject lastPipeSocket;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void snap()
    {
        // Return if nowhere to snap to
        if (lastPipeSocket == null)
            return;

        // Move to the socket
        this.transform.position = lastPipeSocket.transform.position;
        this.GetComponent<Rigidbody>().isKinematic = true;

        // Parent so we can rotate relative to the box
        //this.transform.parent = lastPipeSocket.transform;

        // Calculate the new z angle
        int angleZ = (int)(this.transform.rotation.eulerAngles.z);
        angleZ += 45;
        int angle360Z = angleZ % 360;
        int snapZ = angle360Z / 90;
        if (snapZ > 3)
            snapZ = 3;
        float newZ = snapZ * 90.0f;

        // Calculate the new y angle
        int angleY = (int)(this.transform.rotation.eulerAngles.y);
        angleY += 90;
        int angle360Y = angleY % 360;
        int snapY = angle360Y / 180;
        if (snapY > 1)
            snapY = 1;
        float newY = snapY * 180.0f;

        // Add the angle of the box
        newY += lastPipeSocket.transform.rotation.eulerAngles.y;

        // Set the rotation with x to be 0
        this.transform.rotation = Quaternion.Euler(0.0f, newY, newZ);

        lastPipeSocket.GetComponentInParent<Object_PipeSocket>().CheckForSolution();
    }

    public void unsnap()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.parent = null;

        if (lastPipeSocket == null)
        {
            return;
        }

        lastPipeSocket.GetComponentInParent<Object_PipeSocket>().ResetSolution();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PipeSocket")
            lastPipeSocket = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PipeSocket")
            lastPipeSocket = null;
    }
}
