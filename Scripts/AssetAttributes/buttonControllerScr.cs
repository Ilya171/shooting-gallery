using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonControllerScr : MonoBehaviour
{
    [SerializeField] NumberCoinBuyScr numberCoinBuy;
    [SerializeField] NumberCoinSellScr numberCoinSell;
        
    [SerializeField] InputField input;

    public enum Action
    {
        buy,
        sell
    }
    public Action action;
    public void clickMinus()
    {
        if(action==Action.buy)
        {
            if (numberCoinBuy.NumberCoinsBuy== 0) return;
            numberCoinBuy.NumberCoinsBuy--;
        }
        if(action==Action.sell)
        {
            if (numberCoinSell.NumberCoinsSell == 0) return;
            numberCoinSell.NumberCoinsSell--;
        }
       
    }
    public void clickPlus()
    {
        if (action == Action.buy) numberCoinBuy.NumberCoinsBuy++;
        if (action == Action.sell) numberCoinSell.NumberCoinsSell++;
        
    }
    int number;
    public void clickOk()
    {
        if(action==Action.buy)
        {
            while (!int.TryParse(input.text, out number)) return;
            numberCoinBuy.NumberCoinsBuy = number;
            input.text = null;
        }
        if(action==Action.sell)
        {
            while (!int.TryParse(input.text, out number)) return;
            numberCoinSell.NumberCoinsSell = number;
            input.text = null;
        }
        
    }

}
