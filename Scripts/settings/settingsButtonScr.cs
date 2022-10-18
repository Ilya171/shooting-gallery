using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsButtonScr : MonoBehaviour
{
    [SerializeField] GameObject assetAttributPanel;
    [SerializeField] GameObject settingPanel;
    public void clickButton()
    {
       
        if (assetAttributPanel.activeInHierarchy) assetAttributPanel.SetActive(false);
        if (settingPanel.activeInHierarchy)
        {
            settingPanel.SetActive(false);
            gameObject.SetActive(true);
        }
        else
        {
            settingPanel.SetActive(true);
            gameObject.SetActive(false);
        }

        
        
    }
   
}
