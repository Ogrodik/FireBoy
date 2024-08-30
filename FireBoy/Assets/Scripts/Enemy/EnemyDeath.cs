using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator portalAnim;

    private void Awake()
    {
        portalAnim = GameObject.FindGameObjectWithTag("Portal").GetComponent<Animator>();
    }

    public void Death()
    {
        portalAnim.SetInteger("Phase", portalAnim.GetInteger("Phase") + 1);
        Destroy(gameObject);
    }
}
