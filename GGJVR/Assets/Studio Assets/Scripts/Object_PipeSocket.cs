using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_PipeSocket : MonoBehaviour
{
    [Tooltip("Select two bools to enable to pick correct answer.")]
    public List<bool> colliderBooleans = new List<bool>();

    public List<Collider> colliders = new List<Collider>();

    public bool socketSolved;

    private int numCollidersActive;

    [SerializeField]
    private int colliderCounter;


    // Start is called before the first frame update
    void Start()
    {
        numCollidersActive = 0;
        colliderCounter = 0;

        //disable all colliders
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = false;
        }

        //Makes sure all colliders that need to be on, are
        EnableColliders();
    }
    private void EnableColliders()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            if (colliderBooleans[i] == true)
            {
                colliders[i].enabled = true;
                numCollidersActive++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the object trigger is correct = pipe
        //Increment collider counter
        if(other.CompareTag("Pipe"))
            colliderCounter++;
    }

    public void IncreaseColliderCount()
    {
        colliderCounter++;
    }

    //Called by the snap of the object in place
    public void CheckForSolution()
    {
        if (colliderCounter >= numCollidersActive)
        {
            socketSolved = true;
            GameObject.FindObjectOfType<Puzzle_Water>().CheckPuzzleFinish();
        }
    }

    //Called by the unsnap when object is pulled from slot
    public void ResetSolution()
    {
        colliderCounter = 0;
    }
}
