using UnityEngine;

public class IceBoltTimer : MonoBehaviour
{
    private float lifeTime;

    private void Awake()
    {
        lifeTime = 1.2f;
    }

    private void FixedUpdate()
    {
        LifeController();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {            
            lifeTime = 0.01f;
        }

        if (collision.CompareTag("Ground"))
        {
            lifeTime = 0.01f;
        }
    }
    private void LifeController()
    {
        lifeTime -= Time.fixedDeltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

}
