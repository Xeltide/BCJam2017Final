using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicFadeIn : MonoBehaviour
{

    public static GraphicFadeIn Instance { set; get; }

    public Image Panel;
    private bool isInTransition = true;
    private float transitionIn = 0;
    public float duration = 2.0f;
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
            Panel.color = Color.Lerp( new Color(0, 0, 0, 0), Color.black, transitionIn);

            if (transitionIn > 1 || transitionIn < 0)
                setFadeIn();

        }

    }

    public void setFadeIn()
    {
        fadeIn = !fadeIn;
    }
}

