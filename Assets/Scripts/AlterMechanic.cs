using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkHorrorGame 
{
public class AlterMechanic : MonoBehaviour
{
    public static bool playerInAlter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInAlter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInAlter = false;
        }
    }
}
}
