using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingObject : MonoBehaviour {

    private Vector3 targetPos;
    public float speed;
    private int initY;
    
    //is it rise
    private bool rise = false;

    public const int addY = 5;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Eggsy");
        initY = (int) transform.position.y + addY;
        targetPos = new Vector3(transform.position.x, transform.position.y + addY, transform.position.z);
    }

    //is a trigger

    void Update()
    {
        if ((player.transform.position.x - 1 > transform.position.x)) {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
        //Will make wall rise if triggered
        if (rise && (transform.position.y < initY))
        {
              liftOff();
        }
    }

    //Makes the wall rise
    void liftOff()
    {
        transform.Translate(Vector3.up * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rise = true;
        }
    }
}
