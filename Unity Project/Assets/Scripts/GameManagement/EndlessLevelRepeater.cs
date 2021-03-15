using UnityEngine;

public class EndlessLevelRepeater : MonoBehaviour
{
    [SerializeField] private Transform playerTransform = null;
    private Vector3 playerStartPosition;
    private Vector3 repeatingPoint;

    [SerializeField] private Transform firstBackground = null;
    [SerializeField] private Transform secondBackground = null;

    // Start is called before the first frame update
    void Start()
    {
        playerStartPosition = playerTransform.position;
        repeatingPoint = playerTransform.position - Vector3.up * 500f; 
    }

    // Update is called once per frame
    void Update()
    {
        float repeatDistance = 600f;

        if(playerTransform.position.y < firstBackground.position.y)
        {
            if(playerTransform.position.y > firstBackground.position.y - repeatDistance)
            {
                secondBackground.position = firstBackground.position - Vector3.up * repeatDistance;
            }
            else if(playerTransform.position.y < firstBackground.position.y - repeatDistance)
            {
                firstBackground.position = secondBackground.position - Vector3.up * repeatDistance;
            } 
        }
        else if(playerTransform.position.y > firstBackground.position.y)
        {
            if (playerTransform.position.y < firstBackground.position.y + repeatDistance)
            {
                secondBackground.position = firstBackground.position + Vector3.up * repeatDistance;
            }
            else if (playerTransform.position.y > firstBackground.position.y + repeatDistance)
            {
                firstBackground.position = secondBackground.position + Vector3.up * repeatDistance;
            }
        }
    }
}
