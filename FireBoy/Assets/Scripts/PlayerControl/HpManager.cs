using UnityEngine;

[RequireComponent (typeof(DeathManager))]
public class HpManager : MonoBehaviour
{
    [SerializeField] private RectTransform hpImage;
    [SerializeField] private int hp;

    private AudioSource hpSource;
    private DeathManager death;

    private void Awake()
    {
        hpSource = GetComponent<AudioSource>();
        death = GetComponent<DeathManager>();
    }
    public void HpChange(int num)
    {
        hp+=num;
        if(num<0)
        {
            hpSource.Play();
        }
        ImageController(num);
        CheckHp();                
    }
    private void ImageController(int num)
    {
        hpImage.sizeDelta += new Vector2(num * 50, 0);
        hpImage.localPosition += new Vector3(25 * num, 0);
    }

    private void CheckHp()
    {
        if(hp<1)
        {
            death.Death();
        }            
    }

    
}
