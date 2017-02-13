using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private GameObject player;

    void Start() {
        player = GameObject.Find("Eggsy");
    }
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x - 1 > transform.position.x) {
            Rigidbody[] bodies = transform.GetComponentsInChildren<Rigidbody>();
            BoxCollider[] colliders = transform.GetComponentsInChildren<BoxCollider>();
            for (int i = 0; i < bodies.Length; i++) {
                bodies[i].constraints = RigidbodyConstraints.None;
                colliders[i].isTrigger = true;
            }
        }
        if (transform.position.y < -15) {
            Destroy(this.gameObject);
        }
	}
}
