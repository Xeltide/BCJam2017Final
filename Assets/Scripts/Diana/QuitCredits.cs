using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitCredits : MonoBehaviour
{

    public float Delay;
    private bool DelayDone = false;

    private void Update()
    {
        StartCoroutine(Wait());

        if (DelayDone) {
            SceneManager.LoadScene("Return Menu");
        }
    }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(Delay);
            DelayDone = true;

        }
}
