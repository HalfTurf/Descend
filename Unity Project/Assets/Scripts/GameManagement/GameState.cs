using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum StateType { Start, Play, Won, Lost }

    private StateType currentGameState = StateType.Start;

    public delegate void StateAction();
    public event StateAction OnPlay;
    public event StateAction OnFinished;
    public event StateAction OnVictory;
    public event StateAction OnFailure;

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        currentGameState = StateType.Play;
        OnPlay();
    }

    public void GameVictory()
    {
        currentGameState = StateType.Won;
        OnVictory();
        OnFinished();
    }

    public void GameFailure()
    {
        currentGameState = StateType.Lost;
        OnFailure();
        OnFinished();
    }

    //Returns true if game state is 'play'
    public bool IsPlaying()
    {
        return currentGameState == StateType.Play;
    }

    //Returns true if game is 'won'
    public bool IsVictory()
    {
        return currentGameState == StateType.Won;
    }

    //Returns true if game is 'lost'
    public bool IsFailure()
    {
        return currentGameState == StateType.Lost;
    }
}
