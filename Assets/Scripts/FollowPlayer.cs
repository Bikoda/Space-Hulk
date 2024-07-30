using Unity.Collections;
using UnityEngine;


public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
   
    private Vector3 offSet = new Vector3(10, 0, 0);
    


    void Start()
    {
       
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offSet;
        }
    }
}
