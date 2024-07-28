using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offSet = new Vector3(10,0,0);
    public GameObject player;
    public Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
