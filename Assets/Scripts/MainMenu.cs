using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Button Clicked");
    }

    public void Replay()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Reload Scene");
    }
}
