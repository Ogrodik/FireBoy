using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public void SaveStat(float stat, string nameStat)
    {
        PlayerPrefs.SetFloat(nameStat, stat);
    }
}
