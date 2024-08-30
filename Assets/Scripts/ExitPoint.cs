using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    [SerializeField] float Loaddelay = 1f;
    Audio aud;
    void Awake()
    {
        aud= FindObjectOfType<Audio>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            aud.PlaySound(aud.Checkpoint);
            StartCoroutine(LoadNextScene());
        }
        
        
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(Loaddelay);
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        int NextScene = CurrentScene + 1;
        if(NextScene==SceneManager.sceneCountInBuildSettings)
        {
            NextScene =0;
        }

        SceneManager.LoadScene(NextScene);
        FindObjectOfType<Screenpresist>().ResetScreenpresis();
    }
}
