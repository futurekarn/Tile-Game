using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;
    Rigidbody2D rbg;
    void Start()
    {
       rbg = GetComponent<Rigidbody2D>(); 
    }

    
    void Update()
    {
       rbg.velocity= new Vector2(movespeed , 0f); 
    }
    void OnTriggerExit2D(Collider2D other) {
        
    
    {
        movespeed= -movespeed;
        flipchar();
        
    }

     void flipchar()
     {
        transform.localScale = new Vector2(-(Mathf.Sign(rbg.velocity.x)),1f);

     }
}}
