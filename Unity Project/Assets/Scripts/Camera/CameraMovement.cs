using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float tugSpeed = 0f;
    [SerializeField] [Range(0, 10f)] private float defaultTugSpeed = 1f;
    [SerializeField] [Range(0, 50f)] private float maxTugSpeed = 25f;

    [SerializeField] private bool useVelocityOffset = true;
    [SerializeField] private float xOffset = 0f;
    [SerializeField] private float yOffset = -5f;

    public bool followX = true;
    public bool followY = true;

    public GameObject playerObject;
    private Rigidbody2D playerRigidbody;
    //private GameState gameState;

    private void Awake()
    {
        //gameState = FindObjectOfType<GameState>();
        playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCamera(playerObject.transform.position);
    }

    private void MoveCamera(Vector3 playerPosition)
    {
        Vector3 myPosition = transform.position;
        float maxTug = maxTugSpeed;

        //'tug speed' is set to the absolute value of the players y-axis velocity, which is then clamped and added- 
        //to the default speed. When at max, the player will 'tug' at the camera's 'leash' catching it up with-
        //the player.
        tugSpeed = defaultTugSpeed + Mathf.Abs(Mathf.Clamp(playerRigidbody.velocity.y, -maxTug, maxTug));
        float offsetV = useVelocityOffset ? -tugSpeed : 0f;

        float targetX = followX ? playerPosition.x + xOffset : myPosition.x;
        float targetY = followY ? playerPosition.y + yOffset + offsetV : myPosition.y;

        Vector3 targetVector = new Vector3(targetX, targetY, myPosition.z);


        transform.position = Vector3.Lerp(myPosition, targetVector, Time.deltaTime * tugSpeed);
    }
}
