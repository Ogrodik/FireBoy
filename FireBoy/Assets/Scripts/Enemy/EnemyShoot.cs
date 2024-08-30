using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float maxTimerShoot, force;
    [SerializeField] private GameObject bulletPref;
    private IceBolt bullet;
    private bool shoot;
    private float timerShoot = 0;
    private Transform player;
    private EnemyMover mover;
    private Vector2 target;

    private void Awake()
    {
        mover = GetComponent<EnemyMover>();
    }

    private void FixedUpdate()
    {
        if (shoot)
        {
            ShootBehaviour();
        }
        else
        {
            mover.StandartBehaviour();
        }
    }

    private void ShootBehaviour()
    {
        Shooting();
        CheckDistance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            timerShoot = 0;
            shoot = true;
        }
    }

    private void Shooting()
    {
        timerShoot -= Time.fixedDeltaTime;

        if (timerShoot < 0)
        {
            timerShoot = maxTimerShoot;
            target = new Vector2((transform.position.x - player.position.x) * -1, transform.position.y + 10);

            bullet = Instantiate(bulletPref, transform.position, Quaternion.identity).GetComponent<IceBolt>();
            bullet.Awaked(target, force);
        }
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, player.position) > 14)
        {
            shoot = false;
        }
    }
}