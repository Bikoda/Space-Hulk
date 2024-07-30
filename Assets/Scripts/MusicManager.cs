using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicboxMusic;
    private static MusicManager instance;
    void Awake()
    {
        musicboxMusic = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if (!musicboxMusic.isPlaying)
            {
                musicboxMusic.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
