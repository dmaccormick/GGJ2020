using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_BatterySocket : MonoBehaviour
{
    public bool hasCorrectBattery;

    private Puzzle_Battery batteryController;

    [SerializeField] private int answerNumber;

    // Start is called before the first frame update
    void Start()
    {
        batteryController = FindObjectOfType<Puzzle_Battery>();

        hasCorrectBattery = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Battery" + answerNumber)
            hasCorrectBattery = true;

        batteryController.UpdateSocketStatus(answerNumber);
    }
}
