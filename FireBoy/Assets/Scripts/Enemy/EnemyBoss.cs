using UnityEngine;
using System.Collections;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private GameObject pref;
    private Transform player;
    private Vector3 playerPos;
    private RaycastHit2D[] hits;
    private Animator anim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GameObject.FindGameObjectWithTag("Moon").GetComponent<Animator>();    
    }

    public void AnimAttack()
    {
        StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        hits = Physics2D.RaycastAll(player.position, Vector2.down);
        playerPos = player.position;
        anim.SetBool("Attack", true);

        yield return new WaitForSeconds(delay);

        Attack();
    }

    private void Attack()
    {      
        foreach(RaycastHit2D hit in hits) 
        {
            if(hit.transform.CompareTag("Ground"))
            {
                Instantiate(pref, new Vector3(playerPos.x, hit.point.y + (pref.transform.localScale.y / 2)), Quaternion.identity);
                break;
            }
        }
    }
}
