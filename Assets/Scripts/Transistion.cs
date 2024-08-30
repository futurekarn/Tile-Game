using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transistion : MonoBehaviour
{

    [SerializeField] float delaytime = 1.0f;
    [SerializeField] Animator transistion;

    public void Loadlevel()
    {
        StartCoroutine(Loadnextlevel(SceneManager.GetActiveScene().buildIndex+1));
    }

   IEnumerator  Loadnextlevel(int index)
    {
        transistion.SetTrigger("Start");
        yield return new WaitForSeconds(delaytime);
        SceneManager.LoadScene(index);


    }
     
}
