using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectCoinScr : MonoBehaviour
{
   // [SerializeField] enemyControllerScr enemyController;
    Vector3 startPos = new Vector3(-13.1f,1.5f,-5.3f);
    int _actionCoin;
    float moveDistance=1.828f;
    int moveLeft;
    public int ActionCoin
    {
        get
        {
            return _actionCoin;
        }
        set
        {
            if(value>_actionCoin)
            {
                moveLeft = -1;
            }
            else
            {
                moveLeft = 1;
            }
            
           _actionCoin = value;
            if(_actionCoin<0)
            {
                
                _actionCoin = 0;
                return;
            }
            if(_actionCoin>4)
            {
               
                _actionCoin = 4;
                return;
            }
            cameraMoving();
           // enemyController.enemys[_actionCoin].GetComponent<TextSizeSCR>().MakeUP();
            //enemyController.enemys[value].GetComponent<TextSizeSCR>().MakeStandart();

        }
    }
    public int GetActiveCoin()
    {
        return _actionCoin;
    }
    private void Start()
    {
        transform.position = startPos;
        _actionCoin = 0;
    }
    public void cameraMoving()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (moveDistance * moveLeft));
    }
   


}
