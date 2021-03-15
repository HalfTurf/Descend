using UnityEngine;

public class HazardMovement : MonoBehaviour
{
    private enum MovementType { PingPong, };

    [Header("Movement Parameters")]
    [SerializeField] private bool isMobile = true;
    [SerializeField] private MovementType movement = MovementType.PingPong;
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private float pingPongSpeed = 0.5f;

    [Header("Movement Status")]
    [SerializeField] private bool toRight = false;

    private void FixedUpdate()
    {
        if (isMobile)
        {
            MoveHazard();
        }
    }

    private void MoveHazard()
    {
        float speed = pingPongSpeed * Time.deltaTime;
        float horizontalPosition = transform.position.x;

        if (movement == MovementType.PingPong)
        {
            if (toRight)
            {
                transform.position = transform.position + Vector3.right * speed;
                if (horizontalPosition > maxDistance)
                {
                    toRight = false;
                }
            }
            else if (!toRight)
            {
                transform.position = transform.position + Vector3.right * -speed;
                if (horizontalPosition < -maxDistance)
                {
                    toRight = true;
                }
            }
        }
    }
}
