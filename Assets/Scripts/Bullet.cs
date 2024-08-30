using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    Player player;
    [SerializeField] float Speed = 10f;
    Animator anm;
    bool hadcolloied ;
    float xspeed;
    [SerializeField] GameObject Object;
    Audio aud;
        void Start()
    {
        rb= GetComponent<Rigidbody2D>(); 
        player = FindObjectOfType<Player>();
        xspeed = player.transform.localScale.x *Speed; 
        anm =gameObject.GetComponent<Animator>();
        aud = FindObjectOfType<Audio>(); 
    }

    
    void Update()
    {
        rb.velocity= new Vector2(xspeed, 0);
       
        
        
    }
     void OnTriggerEnter2D(Collider2D other) 
     {
        if(other.tag=="Enemy")
        {
            
            Destroy(other.gameObject);
            aud.PlaySound(aud.EnemyDeath);
            
            
           
            
        }
        Instantiate(Object ,transform.position,transform.rotation);
        
        Destroy(gameObject);
       
        
        
    }
    void   OnCollisionEnter2D(Collision2D other)
    {

        
         Destroy(gameObject);
         
         
    }
    
  
       
        
        
    
}
