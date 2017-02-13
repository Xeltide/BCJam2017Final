using UnityEngine;
using System.Collections;

public class floatingAnimation : MonoBehaviour {

    // Update is called once per frame
    private bool pulseOn = true;
    private bool pulseOff = false;

    public Material material;

    void Start()
    {
        transform.Rotate(new Vector3(45, 45, 45));
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void Beat () {

        Debug.Log("pulse");

        if (pulseOn)
        {
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            pulseOn = false;
            pulseOff = true;
        }

        else if (pulseOff)
        {
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            pulseOff = false;
            pulseOn = true;
        }

        material.SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));

    }

    

}
