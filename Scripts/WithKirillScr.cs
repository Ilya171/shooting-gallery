using UnityEngine;
using Alpaca.Markets;
using System.Threading;
using System;
using System.Threading.Tasks;
using Alpaca.Markets.Extensions;
using System.Collections;

   namespace System
{
    public enum IAsyncDisposable
    {
    }
}
public class WithKirillScr : MonoBehaviour
{
 

// Start is called before the first frame update
string KEY_ID = "PKYIR26NSSE2V64QLLP0";
    string SECRET_KEY = "nE2oTJ2LaOLMBy0CgrmGukuHmb1f9mitIhLwgw7b";

    private void Start()
    {
        

      //  Program();
        
    }
    // Update is called once per frame
    async void Program()
    {
        using var client = Environments.Paper
   .GetAlpacaDataStreamingClient(new SecretKey(KEY_ID, SECRET_KEY));

        await client.ConnectAndAuthenticateAsync();
        var cancellationTokenSource = new CancellationTokenSource();
       // cancellationTokenSource.CancelAfter(/*TimeSpan.FromSeconds(15)*/15);
        await using var subscription = await client.SubscribeTradeAsync("AAPL");      
        await foreach (var trade in subscription
            .AsAsyncEnumerable(cancellationTokenSource.Token)
            .ConfigureAwait(false))
        {
            Debug.Log($"Trade received for the {trade.Symbol} {trade.Price} {trade.TimestampUtc} contract");
            

        }
        Debug.Log("2");
        await client.DisconnectAsync();

    }
   
}
