using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFade : MonoBehaviour {

    public static ButtonFade Instance { set; get; }

    public Graphic panel;
    private bool isInTransition = true;
    private float transitionOut = 0;
    public float duration = 1.0f;
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
            panel.color = Color.Lerp( Color.black, new Color(0, 0, 0, 0), transitionOut);

            if (transitionOut > 1 || transitionOut < 0)
                setFadeOut();
        }

    }

    public void setFadeOut()
    {
        fadeOut = !fadeOut;
    }

}

