using UnityEngine;

public class IceBolt : MonoBehaviour
{
    [SerializeField] private float power;
    private float highPos = 0, force;
    private Vector3 target;
    private Rigidbody2D rb;
    bool changeVector;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        rb = GetComponent<Rigidbody2D>();        
    }

    public void Awaked(Vector3 target, float newForce)
    {        
        highPos = target.normalized.y * (newForce / 1.6f);
        force = newForce/1.25f;

        rb.AddForce(target.normalized * newForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {        
        if(!changeVector)
        {
            ChangeVector();
        }
    }

    private void ChangeVector()
    {
        if (transform.position.y > highPos)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce((transform.position - target).normalized * -force, ForceMode2D.Impulse);
            changeVector = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y).normalized * -(power - (Vector2.Distance(transform.position, collision.transform.position) * power / 2)), ForceMode2D.Impulse);
        }
    }
}
