using UnityEngine;
using UnityEngine.UI;
using Alpaca.Markets;



public class CheckBlockScr : MonoBehaviour
{
    [SerializeField] Text checkBlockText;
    public void CheckBlock(IAccount account)
    {
        if (account.IsTradingBlocked)
        {
           checkBlockText.text ="Account is currently restricted from trading.";
        }
        else
        {
            checkBlockText.text="Account is not restricted, and works! " + account.BuyingPower.ToString();
        }
    }
}
