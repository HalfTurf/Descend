using UnityEngine;

public class Turbulence : MonoBehaviour
{
    [SerializeField] private Rigidbody2D targetRigidbody = null;
    [SerializeField] private Transform targetTransform = null;
    private Vector3 velocity;

    [SerializeField] private bool isConstant = false;
    [SerializeField] public bool isActive = false;

    [SerializeField] private float magnitude = 0.5f;
    [Tooltip("How fast this object interpolates towards the turbulence destination.")]
    [SerializeField] private float moveDuration = 1f;
    private float destinationRangeX = 0f;
    private float destinationRangeY = 0f;

    [SerializeField] private float activeDuration = 1f;
    private float activeTimer = 0f;
    
    [SerializeField] private float variationInterval = 1f;
    private float variationTimer = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        activeTimer = activeDuration;
        variationTimer = variationInterval;
    }

    public void ResetDurations()
    {
        activeTimer = activeDuration;
        variationTimer = variationInterval;
    }

    public void SetTurbulenceActive(bool active)
    {
        isActive = active;
        isConstant = active;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        velocity = targetRigidbody.velocity;

        if (isActive)
        {
            SetDestination();

            if (!isConstant)
            {
                activeTimer -= Time.deltaTime;

                if (activeTimer <= 0)
                {
                    activeTimer = activeDuration;
                    destinationRangeX = 0f;
                    destinationRangeY = 0f;
                    isActive = false;
                }
            }
        }

        MoveToDestination();
    }

    private void SetDestination()
    {
        variationTimer -= Time.deltaTime;

        float dynamicMagnitude = magnitude * velocity.magnitude / 150f;

        if (variationTimer <= 0)
        {
            destinationRangeX = Random.Range(-dynamicMagnitude, dynamicMagnitude);
            destinationRangeY = Random.Range(-dynamicMagnitude, dynamicMagnitude);
            variationTimer = variationInterval;
        }
        

    }

    private void MoveToDestination()
    {
        float rangeX = destinationRangeX;
        float rangeY = destinationRangeY;

        //float range = destinationRadius < 0 ? Mathf.Clamp(destinationRadius, );
        Vector3 randomRangeVector = new Vector3(rangeX, rangeY, 0f);
        Vector3 destinationPosition = targetTransform.position + randomRangeVector;
        Vector3 Vel = Vector3.zero;

        Vector3 smoothToDestination = Vector3.SmoothDamp(transform.position, destinationPosition, ref Vel, moveDuration);
        Vector3 snapToOrigin = targetTransform.position;

        transform.position = isActive ? smoothToDestination : snapToOrigin;
    }


}
