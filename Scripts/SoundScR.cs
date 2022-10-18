using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScR : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] Toggle sound;
    public void MusicMute()
    {
        if (!sound.isOn)
        {
            music.mute = true;
        }
        else music.mute = false;
        
    }
}
