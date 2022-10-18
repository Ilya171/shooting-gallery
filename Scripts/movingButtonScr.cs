using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingButtonScr : MonoBehaviour
{
    [SerializeField] coinControllerScr coinController;
    [SerializeField] selectCoinScr selectCoin;
    public void clickLeft()
    {
        /*if(coinController.coinNumber!=0)*/ selectCoin.ActionCoin--;
        
    }
    public void clickRight()
    {
        /*if (coinController.coinNumber != 0)*/ selectCoin.ActionCoin++;
            
    }
}
