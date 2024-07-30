using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicboxMusic;
    private static MusicManager instance;
    void Awake()
    {
        // If an instance already exists and it's not this one, destroy this instance
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance to this one
        instance = this;

        // Prevent this object from being destroyed on scene load
        DontDestroyOnLoad(gameObject);

        // Get the AudioSource component and start playing music if not already playing
        musicboxMusic = GetComponent<AudioSource>();
        if (!musicboxMusic.isPlaying)
        {
            musicboxMusic.Play();
        }
    }
}
