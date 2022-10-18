using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScr : MonoBehaviour
{
    [SerializeField] NumberCoinSellScr numberCoinSell;
    [SerializeField] enemyControllerScr enemyController;
    [SerializeField] selectCoinScr selectCoin;
    [SerializeField] GameObject firePref;

    [SerializeField] Camera cameraM;

    Vector3 firePos;
    private void LateUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, cameraM.transform.position.z - 0.25f);
        }
            
    }

    void Shoot()
    {
        ShootFire();
        GetComponent<Animation>().Play();
        enemyController.ShopHools(selectCoin.GetActiveCoin());
        GetComponent<AudioSource>().Play();
    }
    void ShootFire()
    {
        
            firePos = new Vector3(transform.position.x+0.6f, transform.position.y + 0.28f, transform.position.z);
            GameObject g = Instantiate(firePref, firePos, Quaternion.Euler(0, 0, 0));
            Destroy(g, 0.2f);
        
    }

    public IEnumerator TimerShoot()
    {
        Shoot();
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Shoot();
        }

    }
}
