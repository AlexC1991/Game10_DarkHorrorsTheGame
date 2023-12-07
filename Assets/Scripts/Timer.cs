using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float m_Time = 5;
    public static float s_Time = 59f;
    public static bool timerFinished;
    [SerializeField] private Text timerText;
    public static bool increaseSizePlease;


    private void Update()
    {
        string formattedTime = string.Format("Time: {0:00}:{1:00}", m_Time, s_Time);
        timerText.text = formattedTime;
        if (!timerFinished)
        {
            s_Time -= 20 * Time.deltaTime;
        }
         
        if ( s_Time < 0.2f && m_Time > 0f && !timerFinished )
        {
            increaseSizePlease = true;
            m_Time -= 1f;
            s_Time = 59f;
        }

        if (m_Time <= 0f && s_Time < 0.2f)
        {
            m_Time = 0f;
            s_Time = 0f;
            timerFinished = true;
        }

    }
}
