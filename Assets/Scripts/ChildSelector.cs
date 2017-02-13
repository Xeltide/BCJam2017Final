using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        childSelector();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void childSelector()
    {
        int RiseOrNot = Random.Range(0, 2);
        if (RiseOrNot == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
