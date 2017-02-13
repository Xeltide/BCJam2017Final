using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {


    public static FadeText Instance { set; get; }

    public Text runText;
    private bool isInTransition = true;
    private float transitionOut = 0;
    public float duration = 3.0f;
    public float delayOut;
    private bool fadeOut = false;

    private void Awake() {
        Instance = this;
        Invoke("setFadeOut", delayOut);

    }

    private void Update() {

        if (fadeOut) {

            if (!isInTransition)
                return;

            transitionOut += Time.deltaTime * (1 / duration);
            runText.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), transitionOut);

            if (transitionOut > 1 || transitionOut < 0)
                setFadeOut();
        }

    }

    public void setFadeOut() {
        fadeOut = !fadeOut;
    }

}

