using UnityEngine;

[RequireComponent (typeof(TimeController))]
public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject exitPlate;
    private TimeController timer;

    private void Awake()
    {
        timer = GetComponent<TimeController>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            exitPlate.SetActive(!exitPlate.activeSelf);
            timer.TimeChange();
        }
    }

    
}
