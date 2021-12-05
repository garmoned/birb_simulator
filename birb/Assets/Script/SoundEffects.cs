using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public AudioSource levelMusic;
    public AudioSource deathSound;

    public bool isLevelSong = true;
    public bool isDeathSound = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelMusic()
    {
        isLevelSong = true;
        isDeathSound = false;
        levelMusic.Play();
    }

    public void DeathSound()
    {
        if (levelMusic.isPlaying)
        {
            isLevelSong = false;
        }

        if(!deathSound.isPlaying && isDeathSound == false)
        {
            deathSound.Play();
            isDeathSound = true;
        }
    }
}


