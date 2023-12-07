using UnityEngine;

namespace DarkHorrorGame
{
public class ZombieClown : MonoBehaviour
{

    public GameObject character;
    private Vector3 characterLocation;
    private bool increaseSize;
    private float scaleX;
    private float scaleY;
    private float scaleZ;
    private ParticleSystem thisParticle;
    public static bool clownIsClose;
    [SerializeField] private ScriptableAudioFile evilClownLaugh;
    private bool playClownSound;
   
   private void Awake()
   {
      thisParticle = GetComponentInChildren<ParticleSystem>();
   }
   
    // Update is called once per frame
    void Update()
    {
        characterLocation = character.transform.position;
        transform.LookAt(characterLocation);
        
        scaleX = 1;
        scaleY = 1;
        scaleZ = 1;

        if (MiddleTextUI.killClownSequence)
        {
            thisParticle.Play();
        }
        else
        thisParticle.Pause();

        if (Timer.m_Time == 4 || Timer.m_Time == 3 || Timer.m_Time == 2 || Timer.m_Time == 1)
        {
            if (Timer.increaseSizePlease)
            {
                increaseSize = true;
                Timer.increaseSizePlease = false;
            }
            
        }
        else 
            increaseSize = false;

        if (increaseSize )
        {
            Vector3 scaleChange = new Vector3(scaleX, scaleY, scaleZ);
            transform.localScale += scaleChange;
            increaseSize = false; // Reset the flag so it doesn't keep growing without control
        }
        
        float distance = Vector3.Distance(characterLocation,transform.position);
        
        if (distance < 28f && !Timer.timerFinished)
        {
           // Calculate the direction from the enemy to the player
   Vector3 directionToPlayer = (characterLocation - transform.position).normalized;

   // Move the enemy in the opposite direction
   Vector3 newDirection =- directionToPlayer;

   // Set how far you want the enemy to move
   float moveDistance = 5f; // for example

   // Update the enemy's position
   transform.position += newDirection * moveDistance * Time.deltaTime;
        }
        else if (Timer.timerFinished)
        {

            if (playClownSound)
            {
               evilClownLaugh.PlayAudio();
               playClownSound = false;
            }
            

            Vector3 directionToPlayer = (characterLocation - transform.position).normalized;
   // Move the enemy in the opposite direction
   Vector3 newDirection = directionToPlayer;

   // Set how far you want the enemy to move
   float moveDistance = 5f; // for example

   // Update the enemy's position
   transform.position += newDirection * moveDistance * Time.deltaTime;
        }

        if (distance > 32f && !Timer.timerFinished)
        {
                    // Calculate the direction from the enemy to the player
   Vector3 directionToPlayer = (characterLocation - transform.position).normalized;

   // Move the enemy in the opposite direction
   Vector3 newDirection = directionToPlayer;

   // Set how far you want the enemy to move
   float moveDistance = 5f; // for example

   // Update the enemy's position
   transform.position += newDirection * moveDistance * Time.deltaTime;
        }

        if (distance > 29 && distance < 32 && Timer.timerFinished)
        {
            playClownSound = true;
        }
    

    if (distance < 6)
    {
        clownIsClose = true;
    }
    }
}
}
