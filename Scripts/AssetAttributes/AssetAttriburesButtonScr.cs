using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetAttriburesButtonScr : MonoBehaviour
{
    [SerializeField] GameObject assetAttributPanel;
    [SerializeField] GameObject settingPanel;
    public void clickButton()
    {
        if (settingPanel.activeInHierarchy) settingPanel.SetActive(false);
        if (assetAttributPanel.activeInHierarchy == true) assetAttributPanel.SetActive(false);
        else assetAttributPanel.SetActive(true);
    }
}
