﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballFollow : MonoBehaviour {

    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Eggsy");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x + 500, transform.position.y, transform.position.z);
	}
}
