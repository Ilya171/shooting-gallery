using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshanScr : MonoBehaviour
{

    void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            Debug.Log("A");
           // Invoke("ActiveTrue", 3f);
        }
    }
    void ActiveTrue()
    {
        Debug.Log("B");
        gameObject.SetActive(true); 
    }
}
