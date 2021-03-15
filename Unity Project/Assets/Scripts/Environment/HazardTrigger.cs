using UnityEngine;

public class HazardTrigger : MonoBehaviour
{
    [Header("Members")]
    [SerializeField] private ParticleSystem hitParticle = null;
    [SerializeField] private SpriteRenderer sprite = null;
    private Collider2D trigger;
    

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<Collider2D>();
    }

    private void ActivateAndDetachParticle(ParticleSystem particles)
    {
        particles.gameObject.SetActive(true);
        particles.Play();
        particles.transform.parent = transform.parent.parent;
    }

    public void HitHazard()
    {
        ActivateAndDetachParticle(hitParticle);
        //gameObject.SetActive(false);
        trigger.enabled = false;
        sprite.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            HitHazard();
            //print("Hazard hit Player");
        }

    }

    
}
