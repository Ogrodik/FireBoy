using UnityEngine;

public class IceLaser : MonoBehaviour
{
    [SerializeField] private float sizePluse, lifeTime;
    private Animator moon;

    private void Awake()
    {
        moon = GameObject.FindGameObjectWithTag("Moon").GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        lifeTime -= Time.fixedDeltaTime;
        StateController();        
    }

    private void StateController()
    {
        if (lifeTime > 0)
        {
            transform.localScale += new Vector3(sizePluse, 0);
        }
        else if (lifeTime < 0 && transform.localScale.x > 0)
        {
            transform.localScale -= new Vector3(sizePluse, 0);
        }
        else
        {
            moon.SetBool("Attack", false);
            Destroy(gameObject);
        }
    }
}
