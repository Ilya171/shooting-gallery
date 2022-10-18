using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonSCR : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void click()
    {
        if(panel.activeInHierarchy)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
}
