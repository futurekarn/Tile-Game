using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{
    [SerializeField] AudioSource Mus;
    [SerializeField] AudioClip clip;

   public void Start()
   {
    Mus.PlayOneShot(clip);
    

   }
   public void LoadMAinmenu()
   {
    SceneManager.LoadScene(0);
   }
    public void FirstLevel()
   {
    SceneManager.LoadScene(1);
   }
}
