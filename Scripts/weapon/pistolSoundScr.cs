using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolSoundScr : MonoBehaviour
{
    [SerializeField] GameObject startReload;
    [SerializeField] GameObject endReload;
 
    public void StartReload()
    {
        startReload.GetComponent<AudioSource>().Play();
    }
    public void EndReload()
    {
        endReload.GetComponent<AudioSource>().Play();
    }
}
