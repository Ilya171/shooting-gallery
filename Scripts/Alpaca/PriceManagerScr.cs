using UnityEngine;
using Alpaca.Markets;
using System.Threading;
using System;
using System.Threading.Tasks;
using Alpaca.Markets.Extensions;
using System.Collections;
using Unity.VisualScripting;

public class PriceManagerScr : MonoBehaviour
{
    [SerializeField] enemyControllerScr enemyController;
    // Start is called before the first frame update
    string API_KEY /*= "PKDNMDTEBBVKS0GA499F"*/;
   string API_SECRET /*= "kSnzpbYw7em8UziVwmlWxiNd9XcCg4MOzkuRTyu2"*/;

    IAlpacaDataStreamingClient client;
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();    
    // Update is called once per frame
   public async void PriceCallBack(string key, string secret)
    { 
        
        API_KEY = key;
          API_SECRET = secret;
         client = Environments.Paper
   .GetAlpacaDataStreamingClient(new SecretKey(API_KEY, API_SECRET));

        await client.ConnectAndAuthenticateAsync();
       
        //await client.DisconnectAsync();
        for(int i = 0; i < 5; i++)
        {
            //enemyController.enemys[i].GetComponent<PriceScr>().StateClient(client);  движение через цену             
        }
    }
    public async void SubToken(string name)
    {
        await using var subscription = await client.SubscribeTradeAsync(name);
        await foreach (var trade in subscription
            .AsAsyncEnumerable(cancellationTokenSource.Token)
            .ConfigureAwait(false))
        {
            Debug.Log($"Trade received for the {trade.Symbol} {trade.Price} {trade.TimestampUtc} contract");

        }
       // subscription.Describe();
    }
}
