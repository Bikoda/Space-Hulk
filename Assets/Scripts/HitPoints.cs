using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitPoints : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] Rigidbody playerRb;
    private GameObject gameOver;
    private GameObject level1Completed;
    private bool isGameOver = false; 
    private bool levelOneComplete = false;
    private bool levelTwoComplete = false;
    private bool levelThreeComplete = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (hitPoints <= 0)
        {
            GameOver();
            ReloadScene();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("I am friendly");
                break;
            case "Finish":
                LoadNextScene();
                break;
            default:
                Damange();
                break;
        }
    }

    void LoadNextScene()
    {
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

    public void GameOver()
    {
        if (levelOneComplete == false)
        {
            Debug.Log("You are dead, dude");
            isGameOver = true;
        }
    }

    void Level2Complete()
    {
        if (isGameOver == false)
        {
            Debug.Log("YOU'VE COMPLETED THE LEVEL 2!");
            levelTwoComplete = true;
        }
    }

    void Level1Complete()
    {
        if (isGameOver == false)
        {
            Debug.Log("YOU'VE COMPLETED THE LEVEL!");
            levelOneComplete = true;
        }
    }

    void Damange()
    {
        hitPoints--;
        Debug.Log("You've lost a Hit Point, you've got " + hitPoints + " left");
    }
}
