using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    Vector2 Inputmove;
    Rigidbody2D rb;
    Animator Anm;
    [SerializeField] int  speed = 10;
    [SerializeField] int  Jumpspeed = 10;
    CapsuleCollider2D cps;
    BoxCollider2D myfoot;
    [SerializeField]  int climbspeed = 5;
    float gravityatstart = 8f;
    bool Isalive = true;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Audio aud;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anm= GetComponent<Animator>();
        cps = GetComponent<CapsuleCollider2D>();
        gravityatstart = rb.gravityScale;
         myfoot= GetComponent<BoxCollider2D>(); 
         aud =FindObjectOfType<Audio>();   
    }

    
    void Update()
    {
        if(!Isalive){
            return;
        }
       Run(); 
       flipsprite();
       climbladder();
       Die();
      
    }
    void OnFire()
    {
        
        if(!Isalive )
        {
            return;
        }
        if(! IsPointerOverUIElement())

        {Instantiate(bullet , gun.position , transform.rotation);}
    }
    void OnMove(InputValue value)
    {
        if(!Isalive){
            return;
        }
        Inputmove= value.Get<Vector2>();    
    }
    void OnJump(InputValue value)
    {
        if(!Isalive){
            return;
        }
        if(!myfoot.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }
        if(value.isPressed)
        {

            rb.velocity = new Vector2(0f,Jumpspeed);
            

        }
    }
    void Run ()
    {
        Vector2 Velocity = new Vector2(Inputmove.x*speed,rb.velocity.y);
        rb.velocity=Velocity;
        bool hasplayermoved = Mathf.Abs(rb.velocity.x)>Mathf.Epsilon;
        Anm.SetBool("Isrunning",hasplayermoved);

    }
    void flipsprite()
    {
        bool hasplayermoved = Mathf.Abs(rb.velocity.x)>Mathf.Epsilon;
        if(hasplayermoved)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x),1f);
        } 
    }
    void climbladder()
    {
         if(!myfoot.IsTouchingLayers(LayerMask.GetMask("Climbing")))
         {
             rb.gravityScale = gravityatstart;
             Anm.SetBool("Isclimbing",false);

            return;
        }
        
        
            Vector2 climbVelocity = new Vector2(rb.velocity.x,Inputmove.y*climbspeed);
        rb.velocity=climbVelocity;
        rb.gravityScale = 0;
        bool hasplayermovedup = Mathf.Abs(rb.velocity.y)>Mathf.Epsilon;
        Anm.SetBool("Isclimbing",hasplayermovedup );
        
        


    }
    void Die()
    {
        if(cps.IsTouchingLayers(LayerMask.GetMask("Enemies","Hazard")))
        {
            Isalive =false;
            rb.velocity = new Vector2(15f,15f);
            Anm.SetTrigger("Dieing");
            
            StartCoroutine(Afterdeath());
            if(FindObjectOfType<GameSession>().playerLives>1)
            {
                aud.PlaySound(aud.PlayerDeath);
            }
           
        
        }
    }
    IEnumerator Afterdeath()
    {
        
        yield return new WaitForSeconds(1);
        FindObjectOfType<GameSession>().ProcessPlayerDeath();

    }

    private bool IsPointerOverUIElement()
    {
        
        return EventSystem.current.IsPointerOverGameObject();
    }
}
