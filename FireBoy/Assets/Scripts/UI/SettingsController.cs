using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SaveScript))]
[RequireComponent(typeof(LoadScript))]
public class SettingsController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider, soundSlider;    
    private float music, sound;

    private SoundController soundController;
    private SaveScript save;
    private LoadScript load;

    private void Awake()
    {
        save = GetComponent<SaveScript>();
        load = GetComponent<LoadScript>();
        soundController = GetComponent<SoundController>();

        music = load.LoadStat("music");
        musicSlider.value = music;
        
        sound = load.LoadStat("sound");
        soundSlider.value = sound;
    }

    private void Update()
    {
        CheckStat(ref music,musicSlider.value,"music");
        CheckStat(ref sound, soundSlider.value, "sound");
    }

    private void CheckStat(ref float stat, float value, string statName)
    {
        if (value != stat) 
        {
            stat = value;
            save.SaveStat(stat, statName);
            soundController.StatChange(stat, statName);
        }
    }
}
