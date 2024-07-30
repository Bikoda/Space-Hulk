using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitPoints : MonoBehaviour
{
    
    
    [SerializeField] AudioClip explossion;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem successParticle;
    private int hitPoints = 1;
    private Rigidbody playerRb;
    private GameObject gameOver;
    private GameObject level1Completed;
    private AudioSource audioSource;
    private PlayerController playerController;
    public bool isInTransition;
    public bool waitForIt;

    void Start()   
    {
        playerController = GetComponent<PlayerController>();
        gameOver = GameObject.FindWithTag("GameOver");
        audioSource = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Component playerAudio = gameObject.GetComponent<AudioSource>();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (waitForIt)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("I am friendly");
                break;
            case "Finish":
                SuccessSequence();
                break;
            default:
                Damange();
                break;
        }
    }

    void Damange()
    {
        audioSource.PlayOneShot(explossion);
        hitPoints--;
        Debug.Log("You've lost a Hit Point, you've got " + hitPoints + " left");

        if (hitPoints <= 0)
        {
            
            StartCrashSequence();

        }
    }

    void StartCrashSequence()
    {
        waitForIt = true;
        audioSource.Stop();
        audioSource.PlayOneShot(explossion);
        deathParticle.Play();       /*particlesSystem.Play(deathParticle); - this is generating a being immortal bug that just breaks the game*/
        Debug.Log("You are dead.");
        //gameOver.SetActive(true);
        Invoke("ReloadScene", 5f);
    }
    void SuccessSequence()

    {
        waitForIt = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticle.Play();
        Debug.Log("teleporting keystone activated, don't move.");
        Invoke("LoadNextScene", 5f);
    }

    void ReloadScene()
    {
       
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void LoadNextScene()
    {
        //gameOver.SetActive(false);
        playerController.enabled = false;
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        int followScene = activeScene + 1;
        if (followScene == SceneManager.sceneCountInBuildSettings)
        {
            followScene = 0;
        }
        SceneManager.LoadScene(followScene);
    }


}
