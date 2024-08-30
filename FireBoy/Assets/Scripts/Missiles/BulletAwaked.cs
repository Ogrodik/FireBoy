using UnityEngine;

public class BulletAwaked : MonoBehaviour
{
    [SerializeField] private float power;

    public void GiveTarget(Vector3 target)
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg);
        GetComponent<Rigidbody2D>().AddForce((transform.position - target).normalized * -power, ForceMode2D.Impulse);
    }
}
