using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
   
    public AudioSource music;
    public AudioClip MainMenu;

    void Start()
    {
        music.clip = MainMenu;
        music.loop = true;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
