using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinButtonScr : MonoBehaviour
{
    [SerializeField]public Text coinNameText;
    
    public enum coinNames
    {
        BTC,
        LTC,
        Tether
    }
    public coinNames coinName;    
   
    public void clickButton()
    {
        GetComponent<Image>().color = Color.yellow;
    }
 }
