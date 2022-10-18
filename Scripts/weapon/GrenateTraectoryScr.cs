using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GrenateTraectoryScr : MonoBehaviour
{
    [SerializeField] selectCoinScr selectCoin;
    [SerializeField] enemyControllerScr enemyController;
    [SerializeField] Transform startPs;  
    [SerializeField] GameObject granPref;

    float ygol=20f;
    
    float v,x,y,anguleInRadians,v2,g=Physics.gravity.y;
    bool rotate = false;
    GameObject a;
   public void Move()
    {
        transform.rotation = Quaternion.Euler(0,-180,-ygol);
      
        Vector3 fromTo = enemyController.enemys[selectCoin.ActionCoin].GetComponent<Transform>().position - startPs.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);
        
        x = fromToXZ.magnitude;
        y = fromTo.y;
        anguleInRadians = ygol * Mathf.PI / 100;
        v2 = (g * x * x) / (2 * (y - Mathf.Tan(anguleInRadians) * x) * Mathf.Pow(Mathf.Cos(anguleInRadians), 2));
        v = Mathf.Sqrt(Mathf.Abs(v2))+3f;
        a = Instantiate(granPref, startPs.position, Quaternion.identity);
        a.GetComponent<Rigidbody>().useGravity = true;
        rotate= true;
        a.GetComponent<Rigidbody>().velocity = -transform.right * v;
        
    }
    private void FixedUpdate()
    {
        if(rotate)
        {
            if(!a.gameObject.IsDestroyed())
            {
                a.transform.Rotate(7f, 7f, 7f);
            }
            
        }
    }
}
