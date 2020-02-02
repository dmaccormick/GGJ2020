using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose_Player : MonoBehaviour
{


    //Parent it to the player when grabbed
    public void makeParent()
    {
        this.transform.parent.parent = GameObject.Find("Player").transform;
    }
    //UnParent from player when dropped
    public void unParent()
    {
        this.transform.parent.parent = null;
    }

}
