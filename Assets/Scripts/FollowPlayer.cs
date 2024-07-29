using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody playerRigidbody;
    private Vector3 offSet = new Vector3(10, 0, 0);

    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
