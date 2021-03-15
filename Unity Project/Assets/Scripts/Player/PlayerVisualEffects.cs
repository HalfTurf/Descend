using UnityEngine;

public class PlayerVisualEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathExplosion = null;
    [SerializeField] private ParticleSystem windTrail = null;

    public void PlayDeathEffects()
    {
        deathExplosion.gameObject.SetActive(true);
        deathExplosion.Play();
        deathExplosion.transform.parent = null;
        windTrail.gameObject.SetActive(false);
    }
}
