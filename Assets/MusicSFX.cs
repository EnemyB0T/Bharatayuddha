using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSFX : MonoBehaviour
{
    // Start is called before the first frame upda
   
    public AudioSource src;
    public AudioSource music;
    public AudioClip FireSFX, GrassSFX, WaterSFX, ImpactSFX, Stage1;

    void Start()
    {
        music.clip = Stage1;
        music.loop = true;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
