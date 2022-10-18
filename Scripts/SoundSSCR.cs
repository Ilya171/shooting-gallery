using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSSCR : MonoBehaviour
{
    public GameObject[] clip = new GameObject[8];
   public void Switch()
    {
        if(GetComponent<Toggle>().isOn)
        {
            
            for(int i = 0; i < clip.Length; i++)
            {
                clip[i].GetComponent<AudioSource>().volume = 1f;
            }
        }
        else
        {
            
            for( int i = 0; i < clip.Length; i++)
            {
                clip[i].GetComponent<AudioSource>().volume = 0f;
            }
        }
       
        
    }
}
