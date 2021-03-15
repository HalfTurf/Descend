using UnityEngine;

public class UILevelStateResponse : MonoBehaviour, IGameStateUIResponse
{
    [SerializeField] private Canvas fadeCanvas = null;
    [SerializeField] private FadeImageTransition fadeIntro = null;
    [SerializeField] private FadeImageTransition fadeOutro = null;
    [SerializeField] private GameEndDisplay gameEndDisplay = null;
    [SerializeField] private HeadsUpDisplay headsUpDisplay = null;

    public void GamePlay()
    {
        headsUpDisplay.enabled = true;
        fadeCanvas.enabled = true;
        fadeIntro.fadeTransition = true;
    }

    public void GameVictory()
    {
        gameEndDisplay.ShowVictoryContent(true);
    }

    public void GameFailure()
    {
        gameEndDisplay.ShowFailureContent(true);
    }

    public void GameFinished()
    {
        gameEndDisplay.ShowEndContent(true);
        fadeOutro.fadeTransition = true;
    }
}
