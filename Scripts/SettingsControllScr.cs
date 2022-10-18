using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alpaca.Markets;
using TMPro;

public class SettingsControllScr : MonoBehaviour
{ 
    [SerializeField]public TextMeshProUGUI numberCoinText;

    string nameS;

    public string NameS
    {
        get
        {
            return nameS;
        }
        set
        {
            nameS = value;
            
            
        }
    }
    public int reloadQuantity = 50;
    public int pistolSell = 10;
    public int machineGunSell = 50;
    int numberCoin = 0;
    public int NumberCoin
    {
        get
        {
            return numberCoin;
        }
        set
        {
            numberCoin = value;
            if (numberCoin < 0) numberCoin = 0; //pereDELAY 
            numberCoinText.text = numberCoin.ToString();
        }
    }
    public float startPrice;

   
    
    public IAlpacaTradingClient clients;

    private void Start()
    {
        numberCoinText.text = numberCoin.ToString();
    }
    public void StateStatus(IAlpacaTradingClient client)
    {
        //Debug.Log("CLIENT:"+client);           
        clients = client;
        
       
    }
    public async void clickOK()
    {
               
        if(clients==null)
        {
           
            return;
        }
        var account = await clients.GetPositionAsync(NameS);
        //startPrice = (float)account.AssetLastPrice;
        startPrice = (float)account.AssetCurrentPrice;       
        Debug.Log(startPrice);

       
    }

    

}
