using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private HpManager hpPlayer;
    private SpriteController sprite;
    
    private float invicible = 0;

    private void Awake()
    {
        hpPlayer = GetComponent<HpManager>();
        sprite = GetComponent<SpriteController>();
    }

    private void FixedUpdate()
    {
        if(invicible > 0)
        {
            invicible -= Time.fixedDeltaTime;
            sprite.Blinked(invicible);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if((collision.CompareTag("Trap") && invicible <=0))
        {
            Damage();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.transform.CompareTag("Enemy")) && invicible <= 0)
        {
            Damage();
        }
    }

    private void Damage()
    {
        hpPlayer.HpChange(-1);
        invicible = 1;
    }
}
