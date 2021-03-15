using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeImageTransition : MonoBehaviour
{
    [SerializeField] private Color desiredColor = Color.black;
    [SerializeField] private float duration = 1f;
    private float desiredAlpha = 1;
    public bool fadeTransition = false;
    public bool fadingIn = true;
    
    private float fadeTime = 0f;
    private float fadeAlpha = 0f;
    [SerializeField] private Image transitionImage = null;
    [Space]
    [SerializeField] private UnityEvent OnComplete = null;

    // Start is called before the first frame update
    private void Start()
    {
        //fadingIn = fadeAlpha < desiredAlpha ? true : false;
        ResetDataFields();
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        desiredAlpha = desiredColor.a;
        float newDeltaTime = Time.deltaTime / duration;
        fadeTime = fadingIn ? -newDeltaTime : newDeltaTime;

        UpdateTransition();
    }

    public void SetTransitionActive(bool value)
    {
        fadeTransition = value;
    }

    private void ResetDataFields()
    {
        fadeAlpha = transitionImage.color.a;
    }

    private void UpdateTransition()
    {
        if (fadeTransition)
        {
            if (fadingIn ? fadeAlpha < desiredAlpha : fadeAlpha > desiredAlpha)
            {
                fadeAlpha -= fadeTime;
            }
            else
            {
                ResetDataFields();
                OnComplete.Invoke();
                fadeTransition = false;
            }

            float red = desiredColor.r;
            float green = desiredColor.g;
            float blue = desiredColor.b;

            transitionImage.color = new Color(red, green, blue, fadeAlpha);
        }
        else
        {
            //fadingIn = fadeAlpha < desiredAlpha ? true : false;
            ResetDataFields();
        }
    }


}
