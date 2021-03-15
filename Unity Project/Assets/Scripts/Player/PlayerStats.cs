using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Attribute Values")]
    [SerializeField] private int maxHealthPoints = 10;

    [HideInInspector] public HealthAttribute healthPoints;

    [SerializeField] private PlayerVisualEffects visualEffects = null;
    [SerializeField] private SpriteRenderer playerSprite = null;
    private Rigidbody2D playerRigidbody;
    private GameState gameState;

    private void Awake()
    {
        AssignComponentFields();
    }

    private void AssignComponentFields()
    {
        gameState = FindObjectOfType<GameState>();
        healthPoints = gameObject.AddComponent<HealthAttribute>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeHealth();
    }

    private void InitializeHealth()
    {
        healthPoints.OnHealthDepleted += KillPlayer;
        healthPoints.MaxValue = maxHealthPoints;
    }

    private void KillPlayer()
    {
        visualEffects.PlayDeathEffects();
        playerSprite.enabled = false;
        playerRigidbody.simulated = false;
        gameState.GameFailure();
    }

    //Called by external source (PlayerTrigger)
    public void DamageHealthPoints(int damage)
    {
        healthPoints.Value -= damage;
    }
}
