using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyButtonScr : MonoBehaviour
{
    [SerializeField] NumberOnMishenScr numberOnMishen;
    [SerializeField] NumberBulletScr numberBulletAk;
    [SerializeField] NumberBulletScr numberBulletPistol;
    [SerializeField]CashEquityScr cashEquity;
    
    [SerializeField] GameObject ak;
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject grenade;
    [SerializeField] GameObject startReload;
    [SerializeField] GameObject endReload;
    [SerializeField] enemyControllerScr enemyController;
    [SerializeField] selectCoinScr selectCoin;
    [SerializeField] GameObject sounds;
    [SerializeField] AudioSource reloadGrenade;
    [SerializeField] AudioSource reloadPistol;


    public void clickButton()
    {
        if (!enemyController.enemys[selectCoin.ActionCoin].activeInHierarchy) return;
        numberOnMishen.ChangeReload();
        if(ak.activeInHierarchy)
        {
            enemyController.AddOrder(true, 1, selectCoin.ActionCoin);
           //ak.GetComponent<Animation>().Play("reload");
            numberBulletAk.NumberUp();
            sounds.GetComponent<AudioSource>().Play();
        }
        if(pistol.activeInHierarchy)
        {
            enemyController.AddOrder(true, 2, selectCoin.ActionCoin);
           // pistol.GetComponent<Animation>().Play("pistolReload");
            numberBulletPistol.NumberUp();
            reloadPistol.Play();
        }
        if(grenade.activeInHierarchy)
        {
            enemyController.AddOrder(true,3,selectCoin.ActionCoin);
            reloadGrenade.Play();
        }
        
        
        cashEquity.StateValues();   
    }
    public void StartReload()
    {
        startReload.GetComponent<AudioSource>().Play();
    }
    public void EndReload()
    {
        endReload.GetComponent<AudioSource>().Play();
    }
}
