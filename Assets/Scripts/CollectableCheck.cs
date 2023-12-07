using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DarkHorrorGame
{


public class CollectableCheck : MonoBehaviour
{
    public static int counter;
    [SerializeField] private Text keyCounted;
    [SerializeField] private GameObject keyCounterText;
    public GameObject timerText;
    public GameObject gameOverbackground;
    [SerializeField] private GameObject gameOverWon;

    void Start()
    {
        counter = 0;
        timerText.gameObject.SetActive(true);
        keyCounterText.gameObject.SetActive(true);
    }

    void Update()
    {
        keyCounted.text = ("Keys Located : " + counter).ToString();

        if (Timer.timerFinished && ZombieClown.clownIsClose)
        {
            EndGameLost();
        }
        else if (!Timer.timerFinished && MiddleTextUI.killClownSequence)
        {
             float quickTimer = 2;
             quickTimer -= Time.deltaTime;

             if (quickTimer <= 0.2f)
             {
                EndGameWon();
             }
        }
    }

   public void EndGameLost()
    {
        Debug.Log("You Lost");
        timerText.gameObject.SetActive(false);
        gameOverbackground.gameObject.SetActive(true);
        keyCounterText.gameObject.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void EndGameWon()
    {
        Debug.Log("You Won");
        timerText.gameObject.SetActive(false);
        gameOverWon.gameObject.SetActive(true);
        keyCounterText.gameObject.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}
}