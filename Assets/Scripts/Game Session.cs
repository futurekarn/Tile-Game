using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameSession : MonoBehaviour
{
    public int playerLives = 3;
    [SerializeField] TextMeshProUGUI Scoretext;
    [SerializeField] TextMeshProUGUI livestext;
    int Score = 100;
    Audio aud;
    
    void Awake()
    {
        aud = FindObjectOfType<Audio>();
         int Numgamesessions = FindObjectsOfType<GameSession>().Length;

         if(Numgamesessions>1)
         {
            Destroy(gameObject);

         }

         else
         {
            DontDestroyOnLoad(gameObject);
         }
         livestext.text =  playerLives.ToString(); 
         Scoretext.text= Score.ToString();
        
    }
   public void AddtoScore(int points)
   {
    Score += points;
    Scoretext.text= Score.ToString();

   }
    public void ProcessPlayerDeath()
    {
        if(playerLives>1)
        {
            TakeLife();
        }


        else
        {
            
            Loadsceneagain();
            
        }
    }
    void TakeLife()
    {
      playerLives--;
      int Currentscene = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(Currentscene);
      livestext.text =  playerLives.ToString();  
    }

    void Loadsceneagain()
    {
        
        SceneManager.LoadScene(4);
        Destroy(gameObject);
        FindObjectOfType<Screenpresist>().ResetScreenpresis();
    }

    
}
