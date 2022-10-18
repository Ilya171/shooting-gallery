using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOnMishenScr : MonoBehaviour
{
    [SerializeField] enemyControllerScr enemyController;
    [SerializeField] selectCoinScr selectCoin;
   [SerializeField] SettingsControllScr settingsControll;

    public void ChangeReload()
    {
        //enemyController.enemys[selectCoin.ActionCoin].GetComponent<SettingsControllScr>().NumberCoin += enemyController.enemys[selectCoin.ActionCoin]
        //    .GetComponent<SettingsControllScr>().reloadQuantity;
    }


    public void ChangeNumberAk()
    {
        //enemyController.enemys[selectCoin.ActionCoin].GetComponent<SettingsControllScr>().NumberCoin -= enemyController.enemys[selectCoin.ActionCoin]
        //    .GetComponent<SettingsControllScr>().machineGunSell;
    }
    public void ChangeNumberPistol()
    {
        //enemyController.enemys[selectCoin.ActionCoin].GetComponent<SettingsControllScr>().NumberCoin -= enemyController.enemys[selectCoin.ActionCoin]
        //    .GetComponent<SettingsControllScr>().pistolSell;
    }
    public void ChangeNumberGrenade()
    {
        //enemyController.enemys[selectCoin.ActionCoin].GetComponent<SettingsControllScr>().NumberCoin = 0;
    }
}
