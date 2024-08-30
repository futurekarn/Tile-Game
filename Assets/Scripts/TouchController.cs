using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public void SetAvtive()
    {
        
        gameObject.SetActive(Application.isMobilePlatform);
    }
}
