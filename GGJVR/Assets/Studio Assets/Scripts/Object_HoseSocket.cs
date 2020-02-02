using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_HoseSocket : MonoBehaviour
{
    public bool hasCorrectHose;

    private Puzzle_Oxygen oxygenController;

    [SerializeField] private int answerNumber;

    // Start is called before the first frame update
    void Start()
    {
        hasCorrectHose = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hose Socket" + answerNumber)
            hasCorrectHose = true;

        oxygenController.UpdateSocketStatus(answerNumber);
    }
}
