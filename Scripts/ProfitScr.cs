using Alpaca.Markets;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ProfitScr : MonoBehaviour
{
    float costBasic;
    float unrealPL;
    float profit;

    IAlpacaTradingClient client;
    public bool canUse = false;
    public void StateClient(IAlpacaTradingClient client)
    {
        this.client = client;
        canUse = true;       
    }
    void FindProfit()
    {
        profit = (unrealPL/costBasic)*100;       
    }
    public void ValueNull()
    {
        unrealPL = 0;
        costBasic = 0;
        profit = 0;
    }
    async void SetValue()
    {
        try
        {
        var pos = await client.GetPositionAsync(GetComponent<SettingsControllScr>().NameS);
        costBasic = (float)pos.CostBasis;
        unrealPL=(float)pos.UnrealizedProfitLoss;            
        FindProfit();            
        }
        catch
        {
            return;
        }
        
    }

    public float GetProfit()
    {
        SetValue();
        return profit;
    }
}
