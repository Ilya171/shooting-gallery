using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alpaca.Markets;

public class coinAddScr : MonoBehaviour
{
    [SerializeField] GameObject buttonOk;
    [SerializeField] coinControllerScr coinController;
    [SerializeField] enemyControllerScr enemyController;
    [SerializeField]InputField input;    
    [SerializeField] Text numberText;
    
    int number=0;
    string nameCoin;

    IAlpacaTradingClient client;
    bool noError=true;
    public void StateClient(IAlpacaTradingClient client)
    {
        this.client = client;
    }
public void clickMinus()
{
    if (number == 0) return;
    number--;
    numberText.text = number.ToString();
    //  coinController.DeleteCoin();
    enemyController.DeleteEnemy();


}
public void clickPlus(string inputS, GameObject button, int indeX)
    {
        if (client == null)
        {
            Debug.Log("enter API");
            return;
        }

        if (number >= 5) return;
        CheckName(inputS, button, indeX);





    }

    async void CheckName(string inputS, GameObject button, int indeX)
    {
        nameCoin = inputS;

        try
        {
             var asset = await client.GetAssetAsync(nameCoin);
        }
        catch (System.Exception)
        {
            Debug.Log("Enter right name");
            noError = false;
            return;
        }

        number++;
        numberText.text = number.ToString();
      //   coinController.AddCoin(nameCoin);
        enemyController.NameChange(nameCoin,indeX);
        Destroy(button.GetComponent<Button>());
        Debug.Log("good");
        noError = true;
    }
}
