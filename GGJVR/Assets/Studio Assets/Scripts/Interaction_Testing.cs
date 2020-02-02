using UnityEngine;

public class Interaction_Testing : MonoBehaviour
{
    //--- Button Interactions ---//
    public void OnButtonDown()
    {
        Debug.Log("OnButtonDown()");
    }

    public void OnButtonUp()
    {
        Debug.Log("OnButtonUp()");
    }

    public void OnButtonIsPressed()
    {
        Debug.Log("OnButtonIsPressed()");
    }



    //--- Freezing Interactions ---//
    public void OnAttachedToHand(Transform _caller)
    {
        // Set the rigidbody to be dynamic
        _caller.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void OnDetachedFromHand(Transform _caller)
    {
        // Set the rigidbody to be kinematic
        _caller.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
