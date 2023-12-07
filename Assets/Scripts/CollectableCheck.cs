using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCheck : MonoBehaviour
{

    public int counter; //the counter of all the collectables picked up

    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 6)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("You Win");
    }
}