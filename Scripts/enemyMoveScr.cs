using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class enemyMoveScr : MonoBehaviour
{

    float profitValue;
    
    private float _minPos=-10f, _maxPos=10f;    
    /*public*/ float value=0;
    float niceValue = 0f;
   public float NiceValue
    {
        get
        { 
            return niceValue;
        }
        set 
        { 
            niceValue = value;
        }
    }
    public float Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
           //  chanchePosition();
            
            
        }
    }


    Vector3 newPos=new Vector3(0,0,0);
    float procent=5;
    
    Color myRed = new Color(1f, 0.325f, 0.286f, 1f);
    Color myGreen = new Color(0.501f,0.9f,0.501f,1f);
    
    public void chanchePosition(float profValue)
    {

        // if (niceValue == 0 || Value ==0) return;      // s.155 и n.156  1%=1.55  156-155/1.55=n/-10
        //  procent = niceValue * 1f / 100;             
        // newPos.x = ((Value - NiceValue) * _minPos / procent); // niceVal/pos = value/newpos                 движение через цену

        
            newPos.x = _minPos * profValue /procent;                             //-10/procent=newpos/proc
            if (newPos.x < -10f) newPos.x = -10f;
            if (newPos.x > 10f) newPos.x = 10f;
       // Debug.Log(GetComponent<SettingsControllScr>().NameS + " profValue+ " + profValue);

             if (newPos.x<0)
             {
                if (gameObject.GetComponent<SettingsControllScr>().numberCoinText.color != Color.green)
                {
                    gameObject.GetComponent<SettingsControllScr>().numberCoinText.color = Color.green;
                    gameObject.GetComponent<enemyScr>().nameEnemy.color = Color.green;
                }
                
             }
            if(newPos.x == 0)
            {
                if (gameObject.GetComponent<SettingsControllScr>().numberCoinText.color != Color.white)
                {
                    gameObject.GetComponent<SettingsControllScr>().numberCoinText.color = Color.white;
                    gameObject.GetComponent<enemyScr>().nameEnemy.color = Color.white;
                }
            }
            if(newPos.x > 0)
            {
                if (gameObject.GetComponent<SettingsControllScr>().numberCoinText.color != Color.red)
                {
                    gameObject.GetComponent<SettingsControllScr>().numberCoinText.color = Color.red;
                    gameObject.GetComponent<enemyScr>().nameEnemy.color = Color.red;
                }
                
            }


    }
    
    public void PosAfterDelet()
    {
        newPos.z += 1.83f;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.83f);
    }

    private void Start()
    {
        newPos = transform.position;
        gameObject.GetComponent<enemyScr>().nameEnemy.color = Color.white;
       
    }
    
    private void FixedUpdate()
    {          
            
        try
        {       
        transform.position = Vector3.MoveTowards(transform.position, newPos, 5f * Time.deltaTime);
        }
        catch
        {
            Debug.Log("EROR");
            return;
        }                                 
       
    }
   float i = 0;
   // [SerializeField] float val = 0;
    private void Update()
    {
        // chanchePosition(val);
        //if(GetComponent<PriceScr>().VL()!=0 )
        //{ 
        //    if(i==0)NiceValue = GetComponent<PriceScr>().VL();        движение через цену
        //    i++;
        //    Value = GetComponent<PriceScr>().VL();

        //}

        if (GetComponent<ProfitScr>().canUse)
        {
            i += Time.deltaTime;
            if (i >= 4)
            {

                profitValue = GetComponent<ProfitScr>().GetProfit();
                chanchePosition(profitValue);
                i = 0;

            }
        }
        
    }
   

}
