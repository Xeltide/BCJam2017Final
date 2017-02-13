using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public float Delay;
    private bool DelayDone = false;

    private void Update()
    {
        StartCoroutine(Wait());

        if (DelayDone)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Credits");
            }
            
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("JoshBox");
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Delay);
        DelayDone = true;

    }
}
