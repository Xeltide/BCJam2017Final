using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{

    public static Controls Instance { set; get; }

    public Text runText;
    private bool isInTransition = true;
    private float transitionIn = 0;
    private float duration = 3.0f;
    public float delayIn;
    private bool fadeIn = false;

    private void Awake()
    {
        Instance = this;
        Invoke("setFadeIn", delayIn);

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

    }

    public void setFadeIn()
    {
        fadeIn = !fadeIn;
    }

}


