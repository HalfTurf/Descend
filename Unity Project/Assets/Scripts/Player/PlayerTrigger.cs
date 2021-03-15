using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerStats playerStats;
    [SerializeField] private Turbulence cameraShake = null;

    [SerializeField] private bool recieveDamage = true;
    [SerializeField] private bool effectsTurbulence = true;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<HazardTrigger>())
        {
            if(recieveDamage)
            {
                playerStats.DamageHealthPoints(1);
            }
            
            if(effectsTurbulence)
            {
                cameraShake.ResetDurations();
                cameraShake.isActive = true;
            }
        }
    }
}
