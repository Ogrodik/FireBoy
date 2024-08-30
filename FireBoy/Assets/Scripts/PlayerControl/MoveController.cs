using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private int speed;

    private Rigidbody2D rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0), ForceMode2D.Impulse);
    }
}
