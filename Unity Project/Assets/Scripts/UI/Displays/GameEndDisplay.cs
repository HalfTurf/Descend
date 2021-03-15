using UnityEngine;
using UnityEngine.UI;

public class GameEndDisplay : MonoBehaviour
{
    [Header("GED Data References")]
    [SerializeField] private ScoreKeeper scoreKeeper = null;

    [Header("GED Canvases")]
    [SerializeField] private Canvas gameEndCanvas = null;
    [SerializeField] private Canvas victoryCanvas = null;
    [SerializeField] private Canvas loseCanvas = null;

    [Header("GED Text")]
    [SerializeField] private Text highScoreText = null;

    public void ShowEndContent(bool value)
    {
        UpdateHighScore();
        gameEndCanvas.enabled = true;
    }

    public void ShowVictoryContent(bool value)
    {
        victoryCanvas.enabled = value;
    }

    public void ShowFailureContent(bool value)
    {
        loseCanvas.enabled = value;
    }

    public void UpdateHighScore()
    {
        highScoreText.text = "High Score: " + scoreKeeper.HighScore.ToString();
    }
}
