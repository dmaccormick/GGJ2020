using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_PlantPot : MonoBehaviour
{
    public GameObject batteryPart;
    public bool hasCorrectFood;

    private string answer;

    // Start is called before the first frame update
    void Start()
    {
        hasCorrectFood = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == answer)
            hasCorrectFood = true;

        Instantiate(batteryPart);
    }
}
