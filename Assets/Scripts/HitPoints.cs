using UnityEngine;
using UnityEngine.SceneManagement;

public class HitPoints : MonoBehaviour
{
    
    [SerializeField] Rigidbody playerRb;
    public PlayerMovement playerMovement;
    private GameObject gameOver;
    private GameObject level1Completed;
    private int hitPoints = 5;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Component playerAudio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
       
    }



    private void OnCollisionEnter(Collision other)
    {
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
    void SuccessSequence()
    {   //FX Audio
        //Particle Effects
        Debug.Log("teleporting keystone activated, don't move.");
        Invoke("LoadNextScene", 5f);
    }
    void LoadNextScene()
    {
        GetComponent<PlayerMovement>().enabled = false;
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        int followScene = activeScene + 1;
        if (followScene == SceneManager.sceneCountInBuildSettings) 
        {
            followScene = 0;
        }
        SceneManager.LoadScene(followScene);
    }

    void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void Damange()
    {
        hitPoints--;
        Debug.Log("You've lost a Hit Point, you've got " + hitPoints + " left");

        if (hitPoints <= 0)
        {

            StartCrashSequence();
        }
    }
    void StartCrashSequence()
    {
        //FX Audio
        //Particle Effects
        Debug.Log("You are dead.");
        Invoke("ReloadScene", 5f);
    }
}
