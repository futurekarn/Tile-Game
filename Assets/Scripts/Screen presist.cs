using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenpresist : MonoBehaviour
{
    void Awake()
    {
         int Screenpresists = FindObjectsOfType<Screenpresist>().Length;

         if(Screenpresists>1)
         {
            Destroy(gameObject);

         }

         else
         {
            DontDestroyOnLoad(gameObject);
         }
    }
    public void ResetScreenpresis()
    {
        Destroy(gameObject);
    }
}
