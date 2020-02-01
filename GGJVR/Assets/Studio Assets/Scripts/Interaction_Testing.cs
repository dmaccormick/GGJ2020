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
}
