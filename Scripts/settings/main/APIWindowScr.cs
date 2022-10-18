using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class APIWindowScr : MonoBehaviour
{
    public InputField inputKEY;
    public  InputField inputSECRET;
    [SerializeField] Text windowText;
    [SerializeField] Text statusText;
    [SerializeField] AlpacaManager alpacaManager;
    [SerializeField] PriceManagerScr priceManagerScr;

    string API_KEY;
    string API_SECRET;
  
    public void clickOK()
    {
        alpacaManager.AlpacaCallback(inputKEY.text,inputSECRET.text);
       // priceManagerScr.PriceCallBack(inputKEY.text, inputSECRET.text);

    }

    public void StateStatus(bool value)
    {
        if(value)
        {
            statusText.text = "CONNECT";
            statusText.color = Color.green;
            SaveKey();
        }
        else
        {
            statusText.text = "ERROR";
            statusText.color = Color.red;
        }
    }

    void SaveKey()
    {
        PlayerPrefs.SetString("API_KEY", inputKEY.text);
        PlayerPrefs.SetString("API_SECRET", inputSECRET.text);
    }
    void LoadKey()
    {
        API_KEY = PlayerPrefs.GetString("API_KEY");
        API_SECRET = PlayerPrefs.GetString("API_SECRET");
    }
    private void Start()
    {      
        LoadKey();
        inputKEY.text = API_KEY;
        inputSECRET.text = API_SECRET;
        if(inputKEY!=null && inputSECRET!=null)
        {
            alpacaManager.AlpacaCallback(inputKEY.text, inputSECRET.text);
        }
        
    }

}
