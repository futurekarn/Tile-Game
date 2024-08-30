using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("******AudioListner*******")]
    [SerializeField]  AudioSource Music;
    [SerializeField]  AudioSource SFx;
    [Header("******AUdioClip*******")]

    public AudioClip Background;
    public AudioClip PlayerDeath;
    public AudioClip EnemyDeath;
    public AudioClip Checkpoint;
    public AudioClip Over;
     void Start()
    {
       Music.clip = Background;
        Music.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        SFx.PlayOneShot(clip);
    }

   
}
