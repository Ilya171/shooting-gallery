using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyControllerScr : MonoBehaviour
{
    [SerializeField] AlpacaManager alpacaManager;
    [SerializeField] CreateOrderScr createOrder;
    [SerializeField] enemyMoveScr enemyMove;
    [SerializeField] StateNumberScr stateNumber;    
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] PriceScr priceScr;
   public  GameObject[] enemys = new GameObject[5];

    Vector3 startPos = new Vector3(0f, 0.88f, -5.25f);
    int enemyNumber = 0;


    public void DeleteEnemy()
    {
        
        Destroy(enemys[0]);
        changeIndex();
        trasformPosition();
        enemyNumber--;
        startPos.z += 1.83f;
    }
    void changeIndex()
    {
        //for (int i = 0; i < enemyNumber - 1; i++)
        //{
        //    enemys[i] = enemys[i + 1];
        //}
        //enemys[enemyNumber - 1] = null;
    }
    void trasformPosition()
    {
        enemyMove.PosAfterDelet();
        for (int i = 0; i < enemyNumber - 1; i++)
        {
           enemys[i].transform.position = new Vector3(enemys[i].transform.position.x, enemys[i].transform.position.y, enemys[i].transform.position.z + 1.83f);    
        }

    }
    private void Start()
    {
        AddEnemy("AAPL");
        AddEnemy("SNAP");
        AddEnemy("NVDA");
        AddEnemy("TSLA");
        AddEnemy("AMD");
        enemyNumber = 0;
        
    }
    int k;
    private void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!enemys[i].activeInHierarchy)
            {
                k = i;
                Invoke("ActiveTrue", 3f);
            }
        }
    }
    void ActiveTrue()
    {
        enemys[k].SetActive(true);
    }
    public void AddEnemy(string name)
    {       
        enemys[enemyNumber] = Instantiate(enemyPrefab);
        enemys[enemyNumber].transform.position = startPos;
        enemys[enemyNumber].GetComponent<enemyScr>().ChangeName(name);
        enemys[enemyNumber].GetComponent<SettingsControllScr>().NameS = name;
        enemys[enemyNumber].GetComponent<SettingsControllScr>().StateStatus(alpacaManager.TakeCl());
       // enemys[enemyNumber].GetComponent<SettingsControllScr>().clickOK();
            
        if(enemyNumber==0)
        {
            enemys[enemyNumber].GetComponent<PriceScr>().priceSelect = PriceScr.PriceSelect.p1;
        }
        if (enemyNumber == 1)
        {
            enemys[enemyNumber].GetComponent<PriceScr>().priceSelect = PriceScr.PriceSelect.p2;
        }
        if (enemyNumber == 2)
        {
            enemys[enemyNumber].GetComponent<PriceScr>().priceSelect = PriceScr.PriceSelect.p3;
        }
        if (enemyNumber == 3)
        {
            enemys[enemyNumber].GetComponent<PriceScr>().priceSelect = PriceScr.PriceSelect.p4;
        }
        if (enemyNumber == 4)
        {
            enemys[enemyNumber].GetComponent<PriceScr>().priceSelect = PriceScr.PriceSelect.p5;
        }

        enemyNumber++;
                startPos.z -= 1.83f;
                return;     

    }
    public void NameChange(string name, int indeX)
    {
        enemys[indeX].GetComponent<SettingsControllScr>().NumberCoin = 0;
        enemys[indeX].GetComponent<enemyScr>().nameEnemy.text = name;
       enemys[indeX].GetComponent<SettingsControllScr>().NameS = name;
      // enemys[indeX].GetComponent<SettingsControllScr>().clickOK();        
        stateNumber.Check();
        //enemys[indeX].GetComponent<PriceScr>().GetPrice();
        // priceScr.GetPrice();
        enemys[indeX].GetComponent<ProfitScr>().ValueNull();
        enemys[indeX].GetComponent<enemyMoveScr>().chanchePosition(0);
        
        

    }
    public void ShopHools(int indeX)
    {
        if (enemys[indeX]!=null)
        {
            enemys[indeX].GetComponent<enemyScr>().HoolActive();
        }
        
    }
    public void GetName(int index, int number)
    {
        if(enemys[index]!=null)
        Debug.Log(enemys[index].GetComponent<enemyScr>().nameEnemy.text +" " +number);
    }
    public void GetAll(int index)
    {
        if (enemys[index] != null)
        {
           // Debug.Log(enemys[index].GetComponent<enemyScr>().nameEnemy.text + " reloadQ: " + enemys[index].GetComponent<SettingsControllScr>().reloadQuantity);
         //   Debug.Log("pistolSell: "+enemys[index].GetComponent<SettingsControllScr>().pistolSell);
           // Debug.Log("michiGunSell: " + enemys[index].GetComponent<SettingsControllScr>().machineGunSell);
        }
            
    }
    public void AddOrder(bool site, int weaponNumber,int index)
    {
        if(site)
        {
            createOrder.AddOrder(site, enemys[index].GetComponent<SettingsControllScr>().reloadQuantity, enemys[index].GetComponent<enemyScr>().nameEnemy.text);            
            return;
        }
        if (weaponNumber == 1 && !site)
        {
             createOrder.AddOrder(site, enemys[index].GetComponent<SettingsControllScr>().machineGunSell, enemys[index].GetComponent<enemyScr>().nameEnemy.text);
            return;
        }
        if(weaponNumber == 2 && !site)
        {
            createOrder.AddOrder(site, enemys[index].GetComponent<SettingsControllScr>().pistolSell, enemys[index].GetComponent<enemyScr>().nameEnemy.text);
            return;
        }
        if(weaponNumber == 3 && !site)
        {
            createOrder.AddOrder(site, enemys[index].GetComponent<SettingsControllScr>().NumberCoin, enemys[index].GetComponent<enemyScr>().nameEnemy.text);
        }
    }
    public void StateReload(int index,int number)
    {
        if (number == 0) number = 1;
        Debug.Log("INDEX: "+index);
        enemys[index].GetComponent<SettingsControllScr>().reloadQuantity = number;
    }
    public void StatePistolSell(int index, int number)
    {
      enemys[index].GetComponent<SettingsControllScr>().pistolSell = number;
    }
    public void StateMichineGunSell(int index,int number)
    {
        enemys[index].GetComponent<SettingsControllScr>().machineGunSell = number;
    }
}
