using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMesh : MonoBehaviour {

    private GameObject player;

    void Start() {
        player = GameObject.Find("Eggsy");
    }

    void Update() {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

	void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Eye"))
            Destroy(other.gameObject);
    }
}
