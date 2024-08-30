using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Mainmenu : MonoBehaviour
{
    [SerializeField] int loadscene;
    Transistion transistion;
    void Start()
    {
        transistion = FindObjectOfType<Transistion>();
    }
    public void Startgame()
    {
        SceneManager.LoadScene(loadscene);
        transistion.Loadlevel();

    }
     public void QuitGame()
    {
        Application.Quit();
    }
   
   
}
