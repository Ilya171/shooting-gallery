using UnityEngine;
using Alpaca.Markets;
using System.Threading;
using System.Threading.Tasks;
using Alpaca.Markets.Extensions;

public class PriceScr : MonoBehaviour
{
    IAlpacaDataStreamingClient client;
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    public enum PriceSelect
    {
        p1,
        p2,
        p3,
        p4,
        p5

    }
   public PriceSelect priceSelect;
    public void StateClient(IAlpacaDataStreamingClient client)
    {
        this.client = client;
        GetPrice();
       
    }
    int i =0;
    public async void GetPrice()
    {
        
        if(priceSelect==PriceSelect.p1)
        {                 
            
          //  Debug.Log("NAME: " + gameObject.GetComponent<SettingsControllScr>().NameS);
            await using var subscription1 = await client.SubscribeTradeAsync(gameObject.GetComponent<SettingsControllScr>().NameS);                
            await foreach (var trade in subscription1
                .AsAsyncEnumerable(cancellationTokenSource.Token)
                .ConfigureAwait(false))
            {
               // Debug.Log($"Trade received for the {trade.Symbol} {trade.Price} {trade.TimestampUtc} contract");
                SetPrice(trade);
                await Task.Delay(3000);
            } 
        }
        if (priceSelect == PriceSelect.p2)
        {
          //  Debug.Log("NAME:" + gameObject.GetComponent<SettingsControllScr>().NameS);
            await using var subscription2 = await client.SubscribeTradeAsync(gameObject.GetComponent<SettingsControllScr>().NameS);           
            await foreach (var trade in subscription2
                .AsAsyncEnumerable(cancellationTokenSource.Token)
                .ConfigureAwait(false))
            {
              //  Debug.Log($"Trade received for the {trade.Symbol} {trade.Price} {trade.TimestampUtc} contract");
                SetPrice(trade);
                await Task.Delay(3000);
            }
        }
        if (priceSelect == PriceSelect.p3)
        {
            
            await using var subscription3 = await client.SubscribeTradeAsync(gameObject.GetComponent<SettingsControllScr>().NameS);
            await foreach (var trade in subscription3
                .AsAsyncEnumerable(cancellationTokenSource.Token)
                .ConfigureAwait(false))
            {
              //  Debug.Log($"Trade received for the {trade.Symbol} {trade.Price} {trade.TimestampUtc} contract");
                SetPrice(trade);
                await Task.Delay(3000);
            }
        }
        if (priceSelect == PriceSelect.p4)
        {
            
           // Debug.Log("NAME:" + gameObject.GetComponent<SettingsControllScr>().NameS);
            await using var subscription4 = await client.SubscribeTradeAsync(gameObject.GetComponent<SettingsControllScr>().NameS);
            await foreach (var trade in subscription4
                .AsAsyncEnumerable(cancellationTokenSource.Token)
                .ConfigureAwait(false))
            {
               // Debug.Log($"Trade received for the {trade.Symbol} {trade.Price} {trade.TimestampUtc} contract");
                SetPrice(trade);
                await Task.Delay(3000);

            }
        }
        if (priceSelect == PriceSelect.p5)
        {
            
           // Debug.Log("NAME:" +gameObject.GetComponent<SettingsControllScr>().NameS);
            await using var subscription5 = await client.SubscribeTradeAsync(gameObject.GetComponent<SettingsControllScr>().NameS);
            await foreach (var trade in subscription5
                .AsAsyncEnumerable(cancellationTokenSource.Token)
                .ConfigureAwait(false))
            {
               // Debug.Log($"Trade received for the {trade.Symbol} {trade.Price} {trade.TimestampUtc} contract");
                SetPrice(trade);
                await Task.Delay(3000);
            }
        }


    }
    float v;
     void SetPrice(ITrade trade)
     {
         v = (float)trade.Price;          
     }

    public float VL()
    {
        return v;
    }


}
