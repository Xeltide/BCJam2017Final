using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitIntro : MonoBehaviour {

    public float Delay;
    private bool DelayDone = false;

    private void Update()
    {
        StartCoroutine(Wait());

        if (DelayDone)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Return Menu");
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Delay);
        DelayDone = true;

    }
}

