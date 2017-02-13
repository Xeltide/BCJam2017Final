using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{

    public static FadeManager Instance { set; get; }

    public Text runText;
    private bool isInTransition = true;
    private float transitionIn = 0;
    private float transitionOut = 0;
    public float duration = 2.0f;
    public float delayIn;
    public float delayOut;
    private bool fadeIn = false;
    private bool fadeOut = false;

    public AudioSource ChangSound;

    private void Awake()
    {
        Instance = this;
        Invoke("setFadeIn", delayIn);
        Invoke("setFadeOut", delayOut);
    }

    private void Update()
    {

        if (fadeIn)
        {

            if (!isInTransition)
                return;

            transitionIn += Time.deltaTime * (1 / duration);
            runText.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transitionIn);

            if (transitionIn > 1 || transitionIn < 0)
                setFadeIn();
        }

        else if (fadeOut)
        {
            if (!isInTransition)
                return;

            transitionOut += Time.deltaTime * (1 / duration);
            runText.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), transitionOut);

            if (transitionOut > 1 || transitionOut < 0)
                setFadeOut();

        }

    }

    public void setFadeIn()
    {
        fadeIn = !fadeIn;
    }

    public void setFadeOut()
    {
        fadeOut = !fadeOut;
    }
}


