using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmbientSound : MonoBehaviour
{
    public List<GameObject> oncePlay = new List<GameObject>();
    public List<ScriptableAudioFile> oncePlaySounds = new List<ScriptableAudioFile>();

    private ScriptableAudioFile soundOnce;
    
    public GameObject character;
    private Vector3 characterLocation;
    private Vector3 onceLocation;

    private float distance;


    private float timer;
    private int randomPlay;
    private int randomNextPlay;
    // Update is called once per frame
    private void Start()
    {
        randomNextPlay = Random.Range(4, 8);
    }

    void Update()
    {
        characterLocation = character.transform.position;

        timer += Time.deltaTime;

        if (timer > randomNextPlay)
        {
            randomPlay = Random.Range(0, oncePlay.Count);
            randomNextPlay = Random.Range(4, 8);


            SoundSelect(randomPlay);
            onceLocation = oncePlay[randomPlay].transform.position;

            distance = Vector3.Distance(characterLocation, onceLocation);

            soundOnce.volume = 8/distance;
            soundOnce.PlayAudio();

            timer = 0;
        }
   
    }

    void SoundSelect(int selector)
    {
        switch (selector)
        {
            case int n when (n == 0 || n == 1):
                soundOnce = oncePlaySounds[0];
                break;

            case int n when (n == 2 || n == 6):
                soundOnce = oncePlaySounds[1];
                break;

            case int n when (n == 7 || n == 10):
                soundOnce = oncePlaySounds[2];
                break;

            case int n when (n == 11 || n == 14):
                soundOnce = oncePlaySounds[3];
                break;

            case int n when (n == 15 || n == 19):
                soundOnce = oncePlaySounds[4];
                break;
        }
    }
}
