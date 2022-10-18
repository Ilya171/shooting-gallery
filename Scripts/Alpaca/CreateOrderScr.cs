using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alpaca.Markets;

public class CreateOrderScr : MonoBehaviour
{
    IAlpacaTradingClient client;

    string coinName;
    public void StateClient(IAlpacaTradingClient client)
    {
        this.client = client;
         
    }
    public async void AddOrder(bool buy, int number, string name)
    {
       // Debug.Log("NUMB: " + number);
        if (client == null)
        {
            return;
        }
        
        
        OrderSide orderSide;
        coinName=name;

        Debug.Log("CreatOrder");
        if (buy)
        {
            orderSide = OrderSide.Buy;
           
        }
        else
        {
            
            try
            {
                Debug.Log("1");
                var pos = await client.GetPositionAsync(name);
                Debug.Log("2");
                if (pos.Quantity < number)
                {
                    number =(int)pos.Quantity;
                    Debug.Log("posQRY: " + pos.Quantity);                    
                }
            }
            catch (System.Exception)
            {
                Debug.Log("ERR0R");
                return;
            }
            
                
            orderSide = OrderSide.Sell;
        }
        if(coinName==null)
        {
            Debug.Log("enter name");
            return;
        }
        OrderQuantity orderQuantity=OrderQuantity.FromInt64(number); 
        OrderType orderType = OrderType.Market;
        TimeInForce timeInForce = TimeInForce.Day;
        
        NewOrderRequest first = new NewOrderRequest(coinName, orderQuantity, orderSide, orderType, timeInForce);
        Debug.Log("+");
        var ord = await client.PostOrderAsync(first);
        Debug.Log("HERE");
    }
}
