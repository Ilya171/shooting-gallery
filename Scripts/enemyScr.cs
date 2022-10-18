using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyScr : MonoBehaviour
{
    [SerializeField] GameObject hoolsPrefab;
    [SerializeField]public TextMeshProUGUI nameEnemy;
    
    

    public void ChangeName(string nameS)
    {
        nameEnemy.text = nameS;
       

    }

    public void HoolActive()
    {
        hoolsPrefab.SetActive(true);
    }
}
