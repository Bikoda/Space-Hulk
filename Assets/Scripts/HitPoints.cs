using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    public int hitPoints = 10;
    public bool isGameOver = false;
    public GameObject gameOver;
    public GameObject startZone;
    public GameObject endZone;
    // Start is called before the first frame update
    void Start()
    {
         gameOver = GameObject.FindWithTag("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints == 0)
        {
           
            GameOver();
            
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != startZone && collision.gameObject != endZone)
        {
            hitPoints--;
            Debug.Log("You've lost a Hit Point, you've got " + hitPoints + " left");
        }
       
    }

    public void GameOver()
    {
        Debug.Log("You are dead.");
        //gameOver = GameObject.FindWithTag("GameOver");
        isGameOver = true;
        //gameOver.SetActive(true);
    }
}
