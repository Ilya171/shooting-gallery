using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberBulletScr : MonoBehaviour
{
    [SerializeField] NumberCoinBuyScr numberCoinBuy;

    [SerializeField] Text numberBullet;
    

    int _numberBullet = 0;
    public int NumberBuller
    {
        get
        {
            return _numberBullet;
        }
        set
        {

            _numberBullet = value;
            
            numberBullet.text = _numberBullet.ToString() + "/30";
        }
    }
    public void ShowNumber()
    {
        numberBullet.text = _numberBullet.ToString() + "/30";
    }
    public void NumberUp()
    {
        NumberBuller += numberCoinBuy.NumberCoinsBuy;
        
    }
}
