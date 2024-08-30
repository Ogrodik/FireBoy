using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private bool hunt;
    private float timerHunt = 0, maxTimerHunt = 1f;
    [SerializeField] private float force;

    private SpriteController sprite;
    private Rigidbody2D rb;
    private Transform player;
    private EnemyMover mover;
    private Vector3 huntPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mover = GetComponent<EnemyMover>();
        sprite = GetComponent<SpriteController>();
    }

    private void FixedUpdate()
    {
        if (hunt)
        {
            HuntBehaviour();
        }
        else
        {     
            mover.StandartBehaviour();
        }        
    }

    private void HuntBehaviour()
    {
        HuntSimulator();
        HuntMoveController();
        HuntPositionController();
        sprite.RotateSprite(-(transform.position.x - huntPos.x));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            timerHunt = 0;
            hunt = true;
        }
    }

    private void HuntMoveController ()
    {
        if(Vector2.Distance(new Vector2(huntPos.x,0), new Vector2(transform.position.x, 0)) > 0.25f)
        {
            rb.AddForce(new Vector3(transform.position.x - huntPos.x, 0).normalized * -force, ForceMode2D.Force);
        }
    }

    private void HuntPositionController()
    {
        if (Vector2.Distance(huntPos, transform.position) > 20)
        {
            hunt = false;
        }
    }

    private void HuntSimulator ()
    {
        timerHunt -= Time.fixedDeltaTime;
        if(timerHunt<0)
        {
            huntPos = player.position;
            timerHunt = maxTimerHunt;
        }
    }
}
