using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OPtions : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Volumeslider;
     public void Volume(float num)
    {
        Volumeslider.text = num.ToString();
    }
   
}
