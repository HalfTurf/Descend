using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    private GameState gameState;

    private void Awake()
    {
        gameState = FindObjectOfType<GameState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!gameState.IsFailure())
            {
                gameState.GameVictory();
            }
        }
    }
}
