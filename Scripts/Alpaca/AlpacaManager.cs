using UnityEngine;
using System;
using Alpaca.Markets;

public class AlpacaManager : MonoBehaviour
{
    [SerializeField] coinAddScr coinAdd;
    [SerializeField] CreateOrderScr createOrder;
    [SerializeField] CheckBlockScr checkBlock;
    [SerializeField] APIWindowScr APIWindow;
    [SerializeField]enemyControllerScr enemyController;
    [SerializeField] GameObject mishenPref;
    [SerializeField] SettingsControllScr SettingsControll;
     StateNumberScr stateNumber;
    CashEquityScr cashEquity;
    
   

    private static string API_KEY /*= "PKDNMDTEBBVKS0GA499F"*/;

    private static string API_SECRET/* = "kSnzpbYw7em8UziVwmlWxiNd9XcCg4MOzkuRTyu2"*/;

    //C# example resources.
    //https://alpaca.markets/docs/api-documentation/how-to/account/

    // Start is called before the first frame update
    private void Start()
    {           
        checkBlock = GetComponent<CheckBlockScr>();
        createOrder = GetComponent<CreateOrderScr>();
        stateNumber = GetComponent<StateNumberScr>();  
        cashEquity = GetComponent<CashEquityScr>();
    }
    IAlpacaTradingClient client;

    public IAlpacaTradingClient TakeCl()
    {
        return client;
    }

    
    public async void AlpacaCallback(string key, string secret)
    {

        bool noError = true;
         API_KEY = key;
         API_SECRET = secret;

        // First, open the API connection

        client = Alpaca.Markets.Environments.Paper
            .GetAlpacaTradingClient(new SecretKey(API_KEY, API_SECRET));       
       

        // Get our account information.
        try
        {
            var account = await client.GetAccountAsync();          
        }
        catch (Exception)
        {
            APIWindow.StateStatus(false);
            noError = false;

        }
        if(noError)
        {
            
            APIWindow.StateStatus(true);
            var account = await client.GetAccountAsync();
            checkBlock.CheckBlock(account);
            createOrder.StateClient(client);
            coinAdd.StateClient(client);
            stateNumber.StateNumber(client);
            cashEquity.StateAccount(client);
            
           
            for(int i = 0; i < 5; i++)
            {
                enemyController.enemys[i].GetComponent<ProfitScr>().StateClient(client);
            }            
        }     

    }
   
}