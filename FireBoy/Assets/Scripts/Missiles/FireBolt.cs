using UnityEngine;

public class FireBolt : MonoBehaviour
{
    [SerializeField] private GameObject boomObj;
    [SerializeField] private float force;
    private CircleCollider2D cirCollider;

    private void Awake()
    {
        cirCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cirCollider.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(collision.GetContact(0).point.x - collision.transform.position.x, collision.GetContact(0).point.y - collision.transform.position.y).normalized * -(force - (Vector2.Distance(transform.position, collision.transform.position) * force / 2)), ForceMode2D.Impulse);
            collision.transform.GetComponent<EnemyHp>().ChangeHp(-1);

        }

        if (!collision.transform.CompareTag("Player"))
        {
            Instantiate(boomObj, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }       
    }
}
