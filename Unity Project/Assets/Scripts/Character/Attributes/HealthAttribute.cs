using UnityEngine;

public class HealthAttribute : MonoBehaviour
{
    public delegate void HealthAction();
    public event HealthAction OnHealthChanged;
    public event HealthAction OnHealthDepleted;

    private void UpdateHealthCondition()
    {
        bool healthIsNil = Value == 0;
        if (healthIsNil)
        {
            OnHealthDepleted();
        }
    }

    public void ResetHealthValue()
    {
        Value = MaxValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        OnHealthChanged += UpdateHealthCondition;
        ResetHealthValue();
    }

    private int maxHealthValue;
    public int MaxValue
    {
        get
        {
            return maxHealthValue;
        }
        set
        {
            if(value < 0)
            {
                maxHealthValue = 0;
            }
            else
            {
                maxHealthValue = value;
            }
        }
    }

    private int healthValue;
    public int Value
    {
        get
        {
            return healthValue;
        }
        set
        {
            if (value > MaxValue)
            {
                healthValue = MaxValue;
            }
            else if (value < 0)
            {
                healthValue = 0;
            }
            else
            {
                healthValue = value;
            }

            OnHealthChanged();
        }
    }
}
