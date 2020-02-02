using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Water : MonoBehaviour
{
    public List<Object_PipeSocket> sockets = new List<Object_PipeSocket>();

    private bool puzzleFinished;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckPuzzleFinish()
    {
        for (int i = 0; i < sockets.Count; i++)
        {
            if (sockets[i].socketSolved)
            {
                puzzleFinished = true;
                continue;
            }
            else
            {
                puzzleFinished = false;
                break;
            }
        }

        if (puzzleFinished)
        {
            Debug.Log("Water puzzle finished!");
            //Allow for bottom of fridge to open
            //Show 100% completion on UI screen
        }
    }
}
