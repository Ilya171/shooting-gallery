using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class akScr : MonoBehaviour
{
    [SerializeField] buyButtonScr buyButton;
    [SerializeField] Camera cameraM;

    public void SReload()
    {
        buyButton.StartReload();
    }
    public void EReload()
    {
        buyButton.EndReload();
    }

    private void LateUpdate()
    {
        if(gameObject.activeInHierarchy)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, cameraM.transform.position.z - 0.2f);
        }        
    }
}
