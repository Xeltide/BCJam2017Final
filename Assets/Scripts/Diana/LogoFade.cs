using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoFade : MonoBehaviour {

    public static LogoFade Instance { set; get; }

    public RawImage Logo;
    private bool isInTransition = true;
    private float transitionOut = 0;
    private float duration = 2.0f;
    public float delayOut;
    private bool fadeOut = false;

    private void Awake()
    {
        Instance = this;
        Invoke("setFadeOut", delayOut);
    }

    private void Update()
    {

        if (fadeOut)
        {
            if (!isInTransition)
                return;

            transitionOut += Time.deltaTime * (1 / duration);
            Logo.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), transitionOut);

            if (transitionOut > 1 || transitionOut < 0)
                setFadeOut();

        }

    }

    public void setFadeOut()
    {
        fadeOut = !fadeOut;
    }
}

