using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [SerializeField] private float ammo, maxAmmo;

    [SerializeField] private RectTransform ammoImage;

    public bool Recharge(float count)
    {
        ammo += count;
        if (ammo >= maxAmmo)
        {
            ammo = maxAmmo;
        }
        ImageChanger();

        if (ammo<=0)
        {
            return false;
        }
        else
        {
            return true;
        }               
    }

    private void ImageChanger()
    {
        ammoImage.sizeDelta = new Vector2(ammo * 50, ammoImage.sizeDelta.y);
        ammoImage.localPosition = new Vector3(-940+(20*(ammo-1)),ammoImage.localPosition.y);
    }
}
