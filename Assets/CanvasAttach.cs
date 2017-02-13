using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAttach : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Canvas>().worldCamera != Camera.main) {
            GetComponent<Canvas>().worldCamera = Camera.main;
        }
	}
}
