using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void TimeChange()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
