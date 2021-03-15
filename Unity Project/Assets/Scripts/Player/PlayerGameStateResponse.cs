using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameStateResponse : MonoBehaviour
{
    [SerializeField] private Transform victoryLine = null;
    [SerializeField] private CameraMovement cameraMovement = null;
    [SerializeField] private Turbulence cameraQuake = null;
    [SerializeField] private Turbulence cameraShake = null;
    private bool gameIsFinished = false;

    private Rigidbody2D rigidBody = null;
    private GameState gameState;

    private void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        gameState.OnFinished += GameFinished;
    }

    private void OnDisable()
    {
        gameState.OnFinished -= GameFinished;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsFinished)
        {
            EnforcePlayerBounds();
            PermitSceneRestart();
        }
    }

    private void GameFinished()
    {
        gameIsFinished = true;
        cameraMovement.followY = false;
        cameraQuake.SetTurbulenceActive(false);
        cameraShake.SetTurbulenceActive(false);
    }

    private void EnforcePlayerBounds()
    {
        bool playerIsOutOfBounds = transform.position.y < (victoryLine.position.y - 100f);
        if (playerIsOutOfBounds)
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.simulated = false;
        }
    }

    private void PermitSceneRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
