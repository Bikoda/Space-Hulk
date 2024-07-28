using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    
    public Rigidbody playerRigidbody;
    public float boostUp = 0.1f;
    private float timeSinceStarTime;
    public float rotateSpeed = 70.0f;
    private float rotateCalculated;
    // Start is called before the first frame update



    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        timeSinceStarTime = Time.time;
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
