using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Battery : MonoBehaviour
{
    public List<bool> batteryInserted = new List<bool>();

    private bool puzzleFinished;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSocketStatus(int batteryNumber)
    {
        batteryInserted[batteryNumber - 1] = true;

        CheckEnding();
    }

    private void CheckEnding()
    {
        for (int i = 0; i < batteryInserted.Count; i++)
        {
            if (batteryInserted[i] == false)
            {
                puzzleFinished = false;
                break;
            }
            else
                puzzleFinished = true;
        }

        if (puzzleFinished == true)
        {
            //Do Ending

        }
    }
}
