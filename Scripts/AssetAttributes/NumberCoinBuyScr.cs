using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberCoinBuyScr : MonoBehaviour
{
    [SerializeField] Text numberCoinsBuyText;
    int _numberCoinsBuy = 1;
    public int NumberCoinsBuy
    {
        get
        {
            return _numberCoinsBuy;
        }
        set
        {
            _numberCoinsBuy = value;
            numberCoinsBuyText.text = _numberCoinsBuy.ToString();
            
        }
    }
}
