using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float boostUp = 1000.0f;
    [SerializeField] float rotateSpeed = 1.0f;
    [SerializeField] ParticleSystem thrustersParticle;
    private Rigidbody playerRigidbody;
    private AudioSource audioSource;
    private GameObject player;
    [SerializeField] AudioClip engine;
    [SerializeField] GameObject ligght;
    private float rotateCalculated;
    private float timeSinceStarTime;
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
            StartThrusting(thrustitup);
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        ligght.SetActive(false);
        thrustersParticle.Stop();
        audioSource.Stop();
    }

    private void StartThrusting(float thrustitup)
    {
        Debug.Log("space has been pressed");
        playerRigidbody.AddRelativeForce(Vector3.up * thrustitup * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            ligght.SetActive(true);
            thrustersParticle.Play();
            audioSource.PlayOneShot(engine);
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
