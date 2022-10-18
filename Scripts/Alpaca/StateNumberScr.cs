using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alpaca.Markets;
using System.Threading.Tasks;

public class StateNumberScr : MonoBehaviour
{
    [SerializeField] selectCoinScr selectCoin;
    [SerializeField] enemyControllerScr enemyController;

    IReadOnlyList<IPosition> pos;
    IAlpacaTradingClient client;

    
   public async void StateNumber(IAlpacaTradingClient client)
    {
        this.client = client;
        pos = await client.ListPositionsAsync();
        Check();
       
       
    }
  
   
   
    public async void Check()
    {
  
        await Task.Delay(1000);
        pos = await client.ListPositionsAsync();

        for(int i=0;i<5;i++)
        {
            enemyController.enemys[i].GetComponent<SettingsControllScr>().NumberCoin = 0;
        }

        try
        {
foreach (var item in pos)
            {
                Debug.Log(item.Quantity + " " + item.Symbol);
                for(int i = 0; i < 5; i++)
                {
                   
                    if (enemyController.enemys[i].GetComponent<SettingsControllScr>().NameS == item.Symbol)
                    {
                        enemyController.enemys[i].GetComponent<SettingsControllScr>().NumberCoin = (int)item.Quantity;                        
                       
                    }
                                        
                }
            }
        }
        catch (System.Exception)
        {

            return;
        }
     
    }
   
   
   
}
