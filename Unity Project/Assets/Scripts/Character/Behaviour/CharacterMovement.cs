using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Members")]

    private float inputHorizontal;
    private float inputVertical;

    [Header("Movement Data")]
    [SerializeField] private Vector2 inputVector;
    [SerializeField] private Vector2 movementVelocity;
    [Header("Movement Modifiers")]
    [Tooltip("Multiplies the input value for movement logic")]
    [SerializeField] [Range(0, 100f)] private float movementMultiplier = 50f;
    [SerializeField] private bool limitVerticalVelocity = true;
    [SerializeField] [Range(0, 250f)] private float maxVerticalVelocity = 100f;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called once per physics update
    private void Update()
    {
        SetInputData(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void SetInputData(float inputX, float inputY)
    {
        //input vector is set so it may be used for movement.
        inputVector = new Vector2(inputX, inputY);

        //Set serialized float fields to their respective input values
        inputHorizontal = inputX;
        inputVertical = inputY;
    }

    // FixedUpdate is called once per physics update
    private void FixedUpdate()
    {
        SetVelocityValues(maxVerticalVelocity);
    }

    private void SetVelocityValues(float maxVSpeed)
    {
        //For now the sole input is for the horizontal axis, 
        //effecting the x-axis rigidbody velocity.
        float horizontalVelocity = inputVector.x * movementMultiplier;

        float clampedVertical = Mathf.Clamp(rigidBody.velocity.y, -maxVSpeed, maxVSpeed);

        //The y-axis velocity is limited to prevent
        //players being overwhelmed.
        float verticalVelocity = limitVerticalVelocity ? clampedVertical : rigidBody.velocity.y;

        movementVelocity = new Vector2(horizontalVelocity, verticalVelocity);
        rigidBody.velocity = movementVelocity;
    }
}
