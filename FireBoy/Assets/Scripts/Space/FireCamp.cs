using UnityEngine;

public class FireCamp : MonoBehaviour
{
    [SerializeField] private Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FireEnd(collision);
        }            
    }

    private void FireEnd(Collider2D collision)
    {
        Destroy(gameObject.GetComponent<Animator>());
        Destroy(gameObject.GetComponent<AudioSource>());
        Destroy(gameObject.GetComponent<FireCamp>());

        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        collision.GetComponent<HpManager>().HpChange(1);
        collision.GetComponent<AmmoController>().Recharge(10);        
    }
}
