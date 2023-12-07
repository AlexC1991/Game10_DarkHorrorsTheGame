using UnityEngine;

public class ZombieClown : MonoBehaviour
{

    public GameObject character;
    private Vector3 characterLocation;
    private bool increaseSize;
    private float scaleX;
    private float scaleY;
    private float scaleZ;
    // Update is called once per frame
    void Update()
    {
        characterLocation = character.transform.position;
        transform.LookAt(characterLocation);
        
        scaleX = 1;
        scaleY = 1;
        scaleZ = 1;

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
    }
}
