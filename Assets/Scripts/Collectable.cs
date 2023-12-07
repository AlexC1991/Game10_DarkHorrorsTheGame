using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public GameObject pickUpText; //the pickup text

    CollectableCheck counterUpdate; //the counter to check if player has all the collectables

    private bool playerInteract = false;
    void Update()
    {

        // check if the player pressed e and if the pick up text is active
       if (pickUpText.activeInHierarchy && Input.GetKeyDown("e"))
        {
            playerInteract = true;
        }

       // Workaround for not to destroy all game when you walk near them
       if (!pickUpText.activeInHierarchy)
        {
            playerInteract = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Displays the pickup text if player is in the trigger area
        if (other.CompareTag("Player"))
        {
            pickUpText.gameObject.SetActive(true);
        }

    }


    private void OnTriggerStay(Collider other)
    {
        //checks if player clicked e and set object to disabled
        if (playerInteract == true)
        {
            this.gameObject.SetActive(false);
        }
    }


    //checks if player left trigger and set picktext to inactive
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUpText.gameObject.SetActive(false);
        }
    }

    //playing around with ondisbale
    private void OnDisable()
    {
        counterUpdate = GameObject.FindGameObjectWithTag("Counter").GetComponent<CollectableCheck>();
        counterUpdate.counter += 1;

        pickUpText.SetActive(false);
    }
}
