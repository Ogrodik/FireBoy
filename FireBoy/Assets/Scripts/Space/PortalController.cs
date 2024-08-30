using UnityEngine;

public class PortalController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject clickGo, winMenu;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && anim.GetInteger("Phase")==5)
        {
            clickGo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clickGo.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        ClickChecked();
    }

    private void ClickChecked()
    {
        if(Input.GetKey(KeyCode.E) && clickGo.activeSelf == true) 
        {
            Time.timeScale = 0;
            winMenu.SetActive(true);
        }
    }
}
