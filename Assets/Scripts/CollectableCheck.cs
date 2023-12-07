using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCheck : MonoBehaviour
{

    public int counter;

    public GameObject timerText;

    public GameObject gameOverbackground;
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
        timerText.gameObject.SetActive(false);
        gameOverbackground.gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}