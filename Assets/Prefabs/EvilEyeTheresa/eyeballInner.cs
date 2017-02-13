using UnityEngine;
using System.Collections;

public class eyeballInner : MonoBehaviour {

    // Update is called once per frame
    private bool pulseOn = true;
    private bool pulseOff = false;


        void Beat()
    {

            Debug.Log("pulse");

            if (pulseOn)
            {
                transform.localScale += new Vector3(1, 1, 1);
                pulseOn = false;
                pulseOff = true;
            }

            else if (pulseOff)
            {
                transform.localScale -= new Vector3(1, 1, 1);
                pulseOff = false;
                pulseOn = true;
            }
       }
}
