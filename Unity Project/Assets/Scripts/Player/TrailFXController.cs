using UnityEngine;

public class TrailFXController : MonoBehaviour
{
    private TrailRenderer trailFX = null;
    [SerializeField] private float minTrailTime = 0.05f;
    [SerializeField] private float maxTrailTime = 0.4f;

    private void Awake()
    {
        trailFX = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        trailFX.time = Random.Range(minTrailTime, maxTrailTime);
    }
}
