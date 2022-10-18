using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChangerScr : MonoBehaviour
{
    [SerializeField] enemyControllerScr enemyController;
    [SerializeField] selectCoinScr selectCoin;
    [SerializeField] GameObject lightS;
    Color standart;
    private void Start()
    {
        standart = lightS.GetComponent<Light>().color;
    }

    public void ChangeClor()
    {
        if (enemyController.enemys[selectCoin.ActionCoin].transform.position.x < 0)
        {
           // enemyController.enemys[selectCoin.ActionCoin].GetComponent<SettingsControllScr>().numberCoinText.color = Color.green;
           // enemyController.enemys[selectCoin.ActionCoin].GetComponent<enemyScr>().nameEnemy.color = Color.green;
            lightS.GetComponent<Light>().color = Color.green;
        }
            
        if(enemyController.enemys[selectCoin.ActionCoin].transform.position.x > 0)
        {
           // enemyController.enemys[selectCoin.ActionCoin].GetComponent<SettingsControllScr>().numberCoinText.color = Color.red;
           // enemyController.enemys[selectCoin.ActionCoin].GetComponent<enemyScr>().nameEnemy.color = Color.red;
            lightS.GetComponent<Light>().color = Color.red;
        }
        Invoke("StandarColor", 0.5f);
    }
    void StandarColor()
    {
       // enemyController.enemys[selectCoin.ActionCoin].GetComponent<SettingsControllScr>().numberCoinText.color = Color.white;
       // enemyController.enemys[selectCoin.ActionCoin].GetComponent<enemyScr>().nameEnemy.color = Color.white;
        lightS.GetComponent<Light>().color = standart;
    }
}
