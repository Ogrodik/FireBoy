using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteController : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color color;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
    }

    public void RotateSprite(float xMove)
    {
        if (xMove > 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }

    public void Blinked(float timer)
    {
        if (sprite.color != color || timer <= 0)
        {
            sprite.color = color;
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 0.4f);
        }
    }
}
