using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatAmbient : MonoBehaviour
{

    public GameObject character;

    public ScriptableAudioFile sound;

    private Vector3 characterLocation;

    private float timer;
    private bool inDistance;
    private void Start()
    {
        sound.PlayAudio();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        characterLocation = character.transform.position;

        float distance = Vector3.Distance(characterLocation, this.transform.position);


        if (timer > 1 && inDistance)
        {
            sound.volume = 6/distance;
            sound.RestartAudio();
            timer = 0;
            Debug.Log("audio update");
        }    

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inDistance = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inDistance = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inDistance = false;

            sound.StopAudio();
        }
    }
}
