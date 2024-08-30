using UnityEngine;

public class EscapeController : MonoBehaviour
{
    [SerializeField] private GameObject endPlate, settingPlate;

    private void Update()
    {
        EscapeClick();
    }

    private void EscapeClick()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (settingPlate.activeSelf == true)
            {
                settingPlate.SetActive(false);
            }
            else
            {
                endPlate.SetActive(!endPlate.activeSelf);
            }
        }
    }
}
