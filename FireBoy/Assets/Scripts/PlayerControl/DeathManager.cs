using System.Collections;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField] private GameObject loosePlate, menu;
    private HpManager hpManager;

    private void Awake()
    {
        hpManager = GetComponent<HpManager>();
    }

    public void Death()
    {
        Destroy(menu);
        Destroy(hpManager);

        Time.timeScale = 0.01f;
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.025f);
        Time.timeScale = 0f;
        loosePlate.SetActive(true);
    }
}
