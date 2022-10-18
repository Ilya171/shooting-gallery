using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberCoinSellScr : MonoBehaviour
{
    [SerializeField] Text numberCoinsSellText;
     int _numberCoinsSell = 1;
    public int NumberCoinsSell
    {
        get
        {
            return _numberCoinsSell;
        }
        set
        {
            _numberCoinsSell = value;
            numberCoinsSellText.text = _numberCoinsSell.ToString();
        }
    }
}
