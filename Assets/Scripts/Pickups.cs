using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] AudioClip Soundsfx;
    [SerializeField]  int pointstoadd = 100; 
    bool waspicked = false;
   
     void OnTriggerEnter2D(Collider2D other) 
     {
        if(other.tag == "Player"&& !waspicked)
        {
            waspicked =true;
            FindObjectOfType<GameSession>().AddtoScore(pointstoadd);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(Soundsfx, Camera.main.transform.position ,0.15f);
        }
    }
}
