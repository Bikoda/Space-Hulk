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
    private bool collideOff = false;
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
        //gameOver = GameObject.FindWithTag("GameOver");
        audioSource = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Component playerAudio = gameObject.GetComponent<AudioSource>();
        
    }

    void Update()
    {
        DebugKeys();

    }

    private void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Load next scene");
            LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            collideOff = !collideOff;
            Debug.Log("Collisions are turned off " + collideOff);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (waitForIt || collideOff)
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
             playerController.enabled = false;
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
        playerController.enabled = false;
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
        
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        int followScene = activeScene + 1;
        if (followScene == SceneManager.sceneCountInBuildSettings)
        {
            followScene = 0;
        }
        SceneManager.LoadScene(followScene);
    }


}
