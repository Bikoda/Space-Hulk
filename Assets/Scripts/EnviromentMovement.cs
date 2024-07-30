using UnityEngine;

public class EnviromentMovement : MonoBehaviour
{

    private Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame 
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        //goes from -1 to 1, i need it to go from 0 to 1.

        movementFactor = (rawSinWave + 1) / 2;

        Vector3 offSet = movementVector * movementFactor;
        transform.position = startingPosition + offSet;
    }
}
