using UnityEngine;
using UnityEngine.UI;

public class HeadsUpDisplay : MonoBehaviour
{
    [Header("HUD Data References")]
    [SerializeField] private PlayerStats playerStats = null;
    [SerializeField] private ScoreKeeper scoreKeeper = null;
    private float victoryDistance = 0f;

    [Header("HUD Text")]
    [SerializeField] private Text healthPointText = null;
    [SerializeField] private Text fallDistanceText = null;

    private string fallTextPrefix;
    private string fallTextSuffix;

    private GameState gameState;

    private void Awake()
    {
        gameState = FindObjectOfType<GameState>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerStats.healthPoints.OnHealthChanged += UpdateHealthPointText;
        UpdateHealthPointText();

        victoryDistance = Mathf.Abs(scoreKeeper.victoryLine.position.y);
        fallTextPrefix = "Fallen: ";
        fallTextSuffix = "M";

    }
    // Update is called once per frame
    void Update()
    {
        UpdateFallDistanceText();
    }

    private void UpdateFallDistanceText()
    {
        string fallDistance = scoreKeeper.roundedFallDistance.ToString();

        fallDistanceText.text = fallTextPrefix + (gameState.IsVictory() ? victoryDistance.ToString() : fallDistance) + fallTextSuffix;
    }

    private void UpdateHealthPointText()
    {
        healthPointText.text = "HP: " + playerStats.healthPoints.Value.ToString();
    }
}
