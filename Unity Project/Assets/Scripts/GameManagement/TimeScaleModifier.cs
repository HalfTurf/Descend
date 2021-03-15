using UnityEngine;

public class TimeScaleModifier : MonoBehaviour
{
    [SerializeField, Range(0f, 2f)] private float modifierValue = 1f;
    [SerializeField, Range(0f, 0.02f)] private float newFixedDeltaTime = 0.02f;

    //For Changing values in inspector
    private void OnValidate()
    {
        Time.timeScale = modifierValue;
        Time.fixedDeltaTime = Mathf.Clamp(newFixedDeltaTime * Time.timeScale, 0, 0.02f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


}
