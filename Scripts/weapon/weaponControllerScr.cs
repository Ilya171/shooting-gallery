using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponControllerScr : MonoBehaviour
{
    [SerializeField] GameObject reloadButton;

    [SerializeField] GameObject weaponPanel;
    [SerializeField] GameObject ak;
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject granate;

    public enum TypeWeapon
    {
        ak,
        pistol,
        granate
    }
    public TypeWeapon typeWeapon;

public void clickButton()
    {
        weaponPanel.GetComponent<AudioSource>().Play();
        if (typeWeapon == TypeWeapon.ak)
        {
            reloadButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("reloadAK");
            pistol.SetActive(false);
            granate.SetActive(false);
            ak.SetActive(true);
            ak.GetComponent<NumberBulletScr>().ShowNumber();
        }
        if (typeWeapon == TypeWeapon.granate)
        {
            reloadButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("reloadGrenade");
            pistol.SetActive(false);
            granate.SetActive(true);
            ak.SetActive(false);
        }
        if (typeWeapon == TypeWeapon.pistol)
        {
            reloadButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("reloadPistol");
            pistol.SetActive(true);
            granate.SetActive(false);
            ak.SetActive(false);
            pistol.GetComponent<NumberBulletScr>().ShowNumber();
        }
    }
}
