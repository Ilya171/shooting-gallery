using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPanelSCR : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] coinAddScr coinAdd;   
    [SerializeField] GameObject buttonOk;
    [SerializeField] Text numberReload;
    [SerializeField] Text pistolSell;
    [SerializeField] Text machineGunSell;
    [SerializeField] enemyControllerScr enemyController;
   

    public enum NUmberPanel
    {
        p1,
        p2,
        p3,
        p4,
        p5       
    }
    public NUmberPanel nUmberP;

  
    public void clickOk()
    {
        coinAdd.clickPlus(input.text,buttonOk,(int)(nUmberP));
        
      
    }
    public void clickReloadOk()
    {
        if(nUmberP==NUmberPanel.p1)
        {
            enemyController.StateReload(0, int.Parse(numberReload.text));
            return;
        }
        if(nUmberP==NUmberPanel.p2)
        {
            enemyController.StateReload(1, int.Parse(numberReload.text));
            return;
        }
        if (nUmberP == NUmberPanel.p3)
        {
            enemyController.StateReload(2, int.Parse(numberReload.text));
            return;
        }
        if (nUmberP == NUmberPanel.p4)
        {
            enemyController.StateReload(3, int.Parse(numberReload.text));
            return;
        }
        if (nUmberP == NUmberPanel.p5)
        {
            enemyController.StateReload(4, int.Parse(numberReload.text));
            return;
        }

        Debug.Log(numberReload.text);
    }
    public void clickOKPistolSell()
    {
        if (nUmberP == NUmberPanel.p1)
        {
            enemyController.StatePistolSell(0, int.Parse(pistolSell.text));
            return;
        }
        if (nUmberP == NUmberPanel.p2)
        {
            enemyController.StatePistolSell(1, int.Parse(pistolSell.text));
            return;
        }
        if (nUmberP == NUmberPanel.p3)
        {
            enemyController.StatePistolSell(2, int.Parse(pistolSell.text));
            return;
        }
        if (nUmberP == NUmberPanel.p4)
        {
            enemyController.StatePistolSell(3, int.Parse(pistolSell.text));
            return;
        }
        if (nUmberP == NUmberPanel.p5)
        {
            enemyController.StatePistolSell(4, int.Parse(pistolSell.text));
            return;
        }
        Debug.Log(pistolSell.text);
    }
    public void clickOkMichineGunSell()
    {
        if (nUmberP == NUmberPanel.p1)
        {
            enemyController.StateMichineGunSell(0, int.Parse(machineGunSell.text));
            return;
        }
        if (nUmberP == NUmberPanel.p2)
        {
            enemyController.StateMichineGunSell(1, int.Parse(machineGunSell.text));
            return;
        }
        if (nUmberP == NUmberPanel.p3)
        {
            enemyController.StateMichineGunSell(2, int.Parse(machineGunSell.text));
            return;
        }
        if (nUmberP == NUmberPanel.p4)
        {
            enemyController.StateMichineGunSell(3, int.Parse(machineGunSell.text));
            return;
        }
        if (nUmberP == NUmberPanel.p5)
        {
            enemyController.StateMichineGunSell(4, int.Parse(machineGunSell.text));
            return;
        }

        Debug.Log(machineGunSell.text);
    }
   
}
