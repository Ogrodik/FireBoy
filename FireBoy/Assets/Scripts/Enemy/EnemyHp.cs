
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private float length, hp;
    [SerializeField] private RectTransform hpLine;    
    private float invicible = 0;

    private EnemyDeath death;
    private SpriteController sprite; 
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteController>();
        death = GetComponent<EnemyDeath>();
    }

    private void FixedUpdate()
    {
        if(invicible > 0) 
        {
            invicible -= Time.fixedDeltaTime;
            sprite.Blinked(invicible);
        }
    }

    public void ChangeHp(int num)
    {        
        if(invicible<=0)
        {
            hp += num;
            source.Play();

            if (hp <= 0)
            {
                death.Death();
            }
            else
            {
                hpLine.sizeDelta = new Vector2(hpLine.sizeDelta.x + (length * num), hpLine.sizeDelta.y);
                if(num<0)
                {                    
                    invicible = 2;
                }                
            }
        }        
    }  
}
