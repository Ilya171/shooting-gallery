using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alpaca.Markets;
using Unity.VisualScripting;

public class CashEquityScr : MonoBehaviour
{
    [SerializeField] Text cashText;
    [SerializeField] Text equityText;

    IAlpacaTradingClient client;
    IAccount account;

    float _cash;
    float _equity;
    public float Cash
    {
        get
        {
            return _cash;
        }
        set
        {
            _cash = value;
            cashText.text = "Cash: "+_cash.ToString();
        }
    }
    public float Equity
    {
        get
        {
            return _equity;
        }
        set
        {
            _equity = value;
            equityText.text = "Equity: " +_equity.ToString();
        }
    }
    public async void StateAccount(IAlpacaTradingClient client)
    {
        this.client = client;  
        account = await client.GetAccountAsync();
        StateValues();

        
    }

   public async void StateValues()
    {
        account = await client.GetAccountAsync();
        Cash = (float)account.TradableCash;
        Equity = (float)account.Equity-Cash;  
    } 


}
