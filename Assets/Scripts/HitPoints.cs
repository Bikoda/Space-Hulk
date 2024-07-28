using UnityEngine;

public class HitPoints : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] Rigidbody playerRb;
    //[SerializeField] GameObject gameOver;
    //[SerializeField] GameObject level1Completed;
 

    void Start()
    {
        //gameOver = GameObject.FindWithTag("GameOver");
        //level1Completed = GameObject.FindWithTag("Level1");
        //gameOver.SetActive(false);
        //level1Completed.SetActive(false);

        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (hitPoints == 0)
        {
            GameOver();
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
                Debug.Log("YOU'VE COMPLETED THE LEVEL, biotch!");
                //level1Completed.SetActive(true);
                break;
            default:
                hitPoints--;
                Debug.Log("You've lost a Hit Point, you've got " + hitPoints + " left");
                //Debug.Log('You have lost a "structural" point, you have ' + hitPoints + ' left');  esto deberia funcionar guachin.
                break;
        }
    }

    public void GameOver()
    {
        Debug.Log("You are dead, dude");
        transform.position = Vector3.zero;
        //gameOver.SetActive(true);
        
    }
}
