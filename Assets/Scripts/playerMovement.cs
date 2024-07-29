using UnityEngine;
public class playerMovement : MonoBehaviour
{
    
    [SerializeField] float boostUp = 0.1f;
    [SerializeField] float rotateSpeed = 70.0f;
    private float rotateCalculated;
    private float timeSinceStarTime;
    private Rigidbody playerRigidbody;
    private GameObject player;
    private AudioSource engine;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();
        timeSinceStarTime = Time.time;
        engine = player.GetComponent<AudioSource>();
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
            if (!engine.isPlaying) 
            {
                engine.Play();
            } 
        }else
        {
            engine.Stop();
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
