using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offSet = new Vector3(10,0,0);
    public GameObject player;
    public Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
