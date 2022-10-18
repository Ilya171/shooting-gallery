using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranateScr : MonoBehaviour
{
    [SerializeField] GameObject ak;
    [SerializeField] GameObject pistol;
    [SerializeField] Camera cameraM;
    [SerializeField] Rigidbody ragdoll;
    [SerializeField] GameObject firePref;
    [SerializeField] AudioSource grenadeSource;
    private void LateUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, cameraM.transform.position.z - 0.25f);
            
        }

    }
    GameObject other;
    Rigidbody r;
    Vector3 firePos;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<enemyScr>(out enemyScr enemy))
        {
            firePos = other.transform.position;
            firePos=new Vector3(firePos.x,firePos.y-1,firePos.z);
            GameObject f = Instantiate(firePref, firePos, Quaternion.Euler(0,90,0));
            Destroy(f, 3f);
            grenadeSource.Play();            
            Destroy(gameObject);
            other.gameObject.SetActive(false);            
            this.other = other.gameObject;   
        }      

    }     
}
