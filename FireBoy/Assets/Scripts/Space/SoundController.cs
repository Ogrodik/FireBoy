using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource[] soundObjes;
    [SerializeField] private AudioSource[] musicObjes;

    public void StatChange(float newStat, string statName)
    {
        if (statName == "sound")
        {
            SoundChange(newStat);
        }
        else if (statName == "music")
        {
            MusicChange(newStat);
        }
        else
        {
            Debug.LogError("Incorrect name");
        }
    }

    private void SoundChange(float newSound)
    {
        if(soundObjes != null)
        {
            foreach (AudioSource sounObj in soundObjes)
            {
                sounObj.volume = newSound;
            }
        }     
    }

    private void MusicChange(float newMusic)
    {
        if(musicObjes != null)
        {
            foreach (AudioSource musicObj in musicObjes)
            {
                musicObj.volume = newMusic;
            }
        }
    }
}
