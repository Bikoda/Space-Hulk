using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float boostUp = 0.1f;
    [SerializeField] float rotateSpeed = 70.0f;
    private float rotateCalculated;
    private float timeSinceStarTime;
    private Rigidbody playerRigidbody;
    private GameObject player;
    public AudioClip engine;
    private AudioSource audioSource;
    private int hitPoints;


    void Start()
    {
        //hitPoints = GetComponent<HitPoints>().HitPointsTotal();
        player = GameObject.FindWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();
        timeSinceStarTime = Time.time;
        audioSource = player.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
       
        rotateCalculated = rotateSpeed * Time.deltaTime;

        ProcessThrust(boostUp);
        ProcessRotation();
         
    }

    private void ProcessThrust(float thrustitup)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space has been pressed");
            playerRigidbody.AddRelativeForce(Vector3.up * thrustitup * Time.deltaTime);
            if (!audioSource.isPlaying) 
            {
                audioSource.PlayOneShot(engine);
            } 
        }else
        {
            audioSource.Stop();
            
        }
    }
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateRocket(-rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateRocket(rotateSpeed);
        }
    }

    private void RotateRocket(float rotatethis)
    {
        playerRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.right * rotatethis);
        playerRigidbody.freezeRotation = false;
    }
}
