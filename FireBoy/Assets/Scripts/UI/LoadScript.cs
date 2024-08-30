using UnityEngine;

public class LoadScript : MonoBehaviour
{
    public float LoadStat(string nameStat)
    {
        if (PlayerPrefs.HasKey(nameStat))
        {
            return PlayerPrefs.GetFloat(nameStat);
        }
        return 0.5f;
    }
}
