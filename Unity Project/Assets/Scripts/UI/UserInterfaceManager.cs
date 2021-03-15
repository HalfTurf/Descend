using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    private GameState gameState;
    private IGameStateUIResponse gameStateUIResponse;


    private void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        gameStateUIResponse = GetComponent<IGameStateUIResponse>();
    }

    private void OnEnable()
    {
        gameState.OnVictory += GameVictory;
        gameState.OnFailure += GameFailure;
        gameState.OnFinished += GameFinished;
        gameState.OnPlay += GamePlay;
    }

    private void OnDisable()
    {
        gameState.OnVictory -= GameVictory;
        gameState.OnFailure -= GameFailure;
        gameState.OnFinished -= GameFinished;
        gameState.OnPlay -= GamePlay;
    }

    public void GamePlay()
    {
        gameStateUIResponse.GamePlay();
    }

    public void GameVictory()
    {
        gameStateUIResponse.GameVictory();
    }

    public void GameFailure()
    {
        gameStateUIResponse.GameFailure();
    }

    public void GameFinished()
    {
        gameStateUIResponse.GameFinished();
    }
}
