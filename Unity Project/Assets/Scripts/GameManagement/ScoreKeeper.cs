using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private PlayerStats playerStats;
    public Transform playerTransform = null;
    private float startPositionY = 0f;

    private float fallDistance = 0f;
    [HideInInspector] public int roundedFallDistance = 0;
    private int winHeight = 0;

    public Transform victoryLine = null;
    private GameState gameState;

    private void Awake()
    {
        playerStats = playerTransform.GetComponent<PlayerStats>();
        gameState = FindObjectOfType<GameState>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPositionY = playerTransform.position.y;
        winHeight = (int)victoryLine.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFallDistance();
    }

    private void UpdateFallDistance()
    {
        fallDistance = startPositionY - playerTransform.position.y;
        roundedFallDistance = Mathf.RoundToInt(fallDistance);
    }

    public int HighScore
    {
        get
        {
            int healthPoints = playerStats.healthPoints.Value;
            int scoreMultiplier = healthPoints >= 1 ? healthPoints : 1;
            return gameState.IsFailure() ? roundedFallDistance : Mathf.Abs(winHeight) * scoreMultiplier;
        }
    }
}
