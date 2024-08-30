using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private GameObject pref;    

    private float timeToAttack;
    private bool charge;

    private BulletAwaked bullet;
    private AmmoController ammo;

    private void Awake()
    {
        charge = true;
        ammo = GetComponent<AmmoController>();
        timeToAttack = attackSpeed;
    }

    private void FixedUpdate()
    {
        if (timeToAttack > 0)
            timeToAttack -= Time.fixedDeltaTime;
    }
    
    public void Attack()
    {
        if (timeToAttack < 0 && charge)
        {
            charge = ammo.Recharge(-1);
            timeToAttack = attackSpeed;
                        
            bullet = Instantiate(pref, transform.position, Quaternion.identity).GetComponent<BulletAwaked>();
            bullet.GiveTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            charge = ammo.Recharge(0);
        }
    }
}
