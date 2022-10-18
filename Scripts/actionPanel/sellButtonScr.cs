using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellButtonScr : MonoBehaviour
{
    [SerializeField] GrenateTraectoryScr grenateTraectory;
    [SerializeField] colorChangerScr colorChanger;    
    [SerializeField] NumberOnMishenScr numberOnMishen;
    [SerializeField] PistolScr pistolS;
    [SerializeField] NumberCoinSellScr numberCoinSell;
    [SerializeField] NumberCoinBuyScr numberCoinBuy;
    [SerializeField] selectCoinScr selectCoin;
    [SerializeField] enemyControllerScr enemyController;
    [SerializeField] GameObject ak;
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject granate;
    [SerializeField] GameObject fire;
    [SerializeField] AudioSource noButton;
    [SerializeField] CashEquityScr cashEquity;
   
    Vector3 firePos;
    Vector3 newPos;
   bool granateMove = false;
    public void clickButton()
    {
        if (!enemyController.enemys[selectCoin.ActionCoin].activeInHierarchy) return;
        if (numberCoinSell.NumberCoinsSell==0)
        {
            return;
        }
        if(enemyController.enemys[selectCoin.ActionCoin].GetComponent<SettingsControllScr>().NumberCoin==0)
        {
            noButton.Play();
            return;
        }
        colorChanger.ChangeClor();
        if(ak.activeInHierarchy)
        {
            numberOnMishen.ChangeNumberAk();
            StartCoroutine(TimerShoot());
            if(ak.GetComponent<NumberBulletScr>().NumberBuller!=0)
            {
                ak.GetComponent<NumberBulletScr>().NumberBuller -= numberCoinSell.NumberCoinsSell;
               
                
            }
            enemyController.AddOrder(false,1,selectCoin.ActionCoin);
        }
        if(pistol.activeInHierarchy)
        {
            numberOnMishen.ChangeNumberPistol();
            enemyController.AddOrder(false, 2, selectCoin.ActionCoin);
            StartCoroutine(pistolS.TimerShoot());
            if (pistol.GetComponent<NumberBulletScr>().NumberBuller != 0)
            {
                pistol.GetComponent<NumberBulletScr>().NumberBuller -= numberCoinSell.NumberCoinsSell;

                
            }
        }
        
        if (granate.activeInHierarchy)
        {
            
            enemyController.AddOrder(false, 3, selectCoin.ActionCoin);       
            granateMove = true;
            grenateTraectory.Move();
            numberOnMishen.ChangeNumberGrenade();
        }


        cashEquity.StateValues();
    } 
    
    private void FixedUpdate()
    {
        if(granateMove)
        {
            //granate.transform.Rotate(7f,7f,7f);
            //granate.transform.position = Vector3.MoveTowards(granate.transform.position, enemyController.enemys[selectCoin.ActionCoin]
            //    .GetComponent<Transform>().position, 30f * Time.deltaTime);
            //if(granate.transform.position== enemyController.enemys[selectCoin.ActionCoin].GetComponent<Transform>().position)
            //{
            //    granateMove = false;

            //}
        }
          
    }


    void ShotFire()
    {
        firePos = new Vector3(ak.transform.position.x+1.25f, ak.transform.position.y+0.28f, ak.transform.position.z);
        GameObject g = Instantiate(fire, firePos, Quaternion.Euler(0, -90, Random.Range(0, 90)));
        Destroy(g, 0.2f);
    }
    public void Shoot()
    {   
            ShotFire();
            ak.GetComponent<Animation>().Play();
            ak.GetComponent<AudioSource>().Play();
            enemyController.ShopHools(selectCoin.GetActiveCoin());                    
    }
    IEnumerator TimerShoot()
    {
        Shoot();        
        for (int i = 0; i < 3; i++)
        {
            
            yield return new WaitForSeconds(0.1f);
            Shoot();
        }
            
    }
}
