using UnityEngine;

public class UIMainMenuStateResponse : MonoBehaviour, IGameStateUIResponse
{
    [SerializeField] private Canvas transitionCanvas = null;
    [SerializeField] private FadeImageTransition fadeBackground = null;

    public void GamePlay()
    {
        transitionCanvas.enabled = true;
        fadeBackground.fadeTransition = true;
    }

    public void GameVictory()
    {
        
    }

    public void GameFailure()
    {
        
    }

    public void GameFinished()
    {
        
    }
}
