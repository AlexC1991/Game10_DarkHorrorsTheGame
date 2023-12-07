using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DarkHorrorGame
{
public class MiddleTextUI : MonoBehaviour
{
     [SerializeField] private Text textMiddle;
    [SerializeField] private  GameObject pickUpText; //the pickup text
    public static bool killClownSequence;

    void Update()
    {
        if (AlterMechanic.playerInAlter && CollectableCheck.counter < 6)
        {
            textMiddle.text = ("You need to find more keys to activate this Alter");
            SetPickUpTextActive(true);
        }
        else if (AlterMechanic.playerInAlter && CollectableCheck.counter == 6)
        {
            textMiddle.text = ("Press E to Vanquash this Evil!");
            SetPickUpTextActive(true);

            if (Input.GetKeyDown("e"))
            {
               killClownSequence = true;
            }
        }
        else if (!AlterMechanic.playerInAlter && !Collectable.keyText)
        {
            Debug.Log("Text Turned Off");
            SetPickUpTextActive(false);
        }
        else if (Collectable.keyText)
        {
            Debug.Log("Text Should be Showing");
           SetPickUpTextActive(true);
           textMiddle.text = ("Press E to Pickup Key");
        }        
        
    }

    private void SetPickUpTextActive(bool active)
    {
        pickUpText.gameObject.SetActive(active);
    }
}
}
