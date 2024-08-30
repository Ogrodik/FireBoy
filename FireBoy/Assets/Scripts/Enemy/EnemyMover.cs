using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float rPosX, lPosX;
    [SerializeField] private float force;

    private SpriteController sprite;
    private Rigidbody2D rb;
    private float modifier = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteController>();
    }

    public float Force()
    {
        return force;
    }

    public void StandartBehaviour ()
    {
        MoveController();
        PositionController();
        sprite.RotateSprite(modifier);
    }

    private void MoveController ()
    {
        rb.AddForce(Vector2.right * modifier * force, ForceMode2D.Force);        
    }

    private void PositionController()
    {
        if ((transform.position.x > rPosX && modifier == 1) || (transform.position.x < lPosX && modifier == -1))
        {
            modifier *= -1;
        }
    }
}
