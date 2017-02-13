using UnityEngine;
using System.Collections;

public class eyeball: MonoBehaviour
{


    public Material material;

    void Beat()
    {
        

        material.SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }

         

}




