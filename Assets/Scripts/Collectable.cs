using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DarkHorrorGame
{
public class Collectable : MonoBehaviour
{
    [SerializeField] private  GameObject pickUpText;
    public static bool keyText;
    private bool playerInteract = false;

    ParticleSystem particle;

    private void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // check if the player pressed e and if the pick up text is active
       if (pickUpText.activeInHierarchy && Input.GetKeyDown("e"))
        {
            playerInteract = true;
            particle.Play();
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
            Debug.Log("Detects Player");
            keyText = true;
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
            keyText = false; 
        }
    }

    //playing around with ondisbale
    private void OnDisable()
    {
        Debug.Log("Text Disabled On Disabled");
        CollectableCheck.counter += 1;
        keyText = false; 
    }
}
}
