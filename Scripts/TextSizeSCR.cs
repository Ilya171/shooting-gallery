using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSizeSCR : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI numberText;
    
    float standartSize=0.35f;
    float upSize = 0.45f;

    public void MakeUP()
    {
        numberText.fontSize = upSize;
    }
    public void MakeStandart()
    {
        numberText.fontSize = standartSize;
    }

}
