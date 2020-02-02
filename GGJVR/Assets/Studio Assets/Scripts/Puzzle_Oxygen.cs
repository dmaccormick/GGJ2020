using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Oxygen : MonoBehaviour
{
    public List<bool> hoseConnected = new List<bool>();

    private bool puzzleFinished;

    // Start is called before the first frame update
    void Start()
    {
        puzzleFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSocketStatus(int hoseNumber)
    {
        hoseConnected[hoseNumber - 1] = true;

        CheckPuzzleFinish();
    }

    private void CheckPuzzleFinish()
    {
        for (int i = 0; i < hoseConnected.Count; i++)
        {
            if (hoseConnected[i] == false)
            {
                puzzleFinished = false;
                break;
            }
            else
                puzzleFinished = true;
        }

        if (puzzleFinished == true)
        {
            //Do Puzzle Finish - Puzzle at 100%
            //Allow for top of fridge to open
        }
    }
}
