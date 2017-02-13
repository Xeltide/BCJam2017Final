using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundGenerator : MonoBehaviour {

    public GameObject wallBlock;
    public Transform player;
    public Transform sponer;
    public float HorDistBetweenSpons;
    public float VertDistBetweenSpons;
    public float fallAwayDelay;
    public float torquRandomRange;
    public float forceRandomRange;
    public float deathTime;
    public float distInitBackCover;

    List<GameObject> wallsResicle;

    Vector3 sponDinemnetion;
    Vector3 sponPosition;

    float lastPlayerDist;
    int numLines;
    int backCoverLines;

	void Awake()
    {
        lastPlayerDist = player.position.x;
        sponDinemnetion = sponer.transform.localScale;
        sponPosition = sponer.transform.position;

        wallsResicle = new List<GameObject>();

        numLines = (int)(sponDinemnetion.y / VertDistBetweenSpons);
        backCoverLines = (int)(distInitBackCover / HorDistBetweenSpons);

        for (int i = 0; i < backCoverLines; i++)
        {
           instantiateLine(new Vector3(sponPosition.x - (i * HorDistBetweenSpons), sponPosition.y, sponPosition.z));
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(player.transform.position.x > lastPlayerDist + HorDistBetweenSpons)
        {
            recicleLine(new Vector3( player.transform.position.x + sponPosition.x, sponPosition.y, sponPosition.z));
            lastPlayerDist = player.transform.position.x;
        }
    }

    void instantiateLine(Vector3 position)
    {
        for (int i = 0; i < numLines; ++i)
        {
            StartCoroutine(blockFallAwayInit( Instantiate(wallBlock, new Vector3(position.x + Random.Range(-sponDinemnetion.x / 2, sponDinemnetion.x / 2), position.y - (sponer.localScale.y / 2) + (i * VertDistBetweenSpons), position.z + Random.Range(-sponDinemnetion.z / 2, sponDinemnetion.z / 2)), sponer.rotation).GetComponent<Rigidbody>()));
        }
    }

    void recicleLine(Vector3 position)
    {
        int LastIndex;
        for (int i = 0; i < numLines; ++i)
        {
            if (wallsResicle.Count >=1)
            {
                LastIndex = wallsResicle.Count - 1;
                wallsResicle[LastIndex].transform.position = new Vector3(position.x + Random.Range(-sponDinemnetion.x / 2, sponDinemnetion.x / 2), position.y - (sponer.localScale.y / 2) + (i * VertDistBetweenSpons), position.z + Random.Range(-sponDinemnetion.z / 2, sponDinemnetion.z / 2));
                wallsResicle[LastIndex].transform.rotation = sponer.rotation;
                StartCoroutine(blockFallAway(wallsResicle[LastIndex].GetComponent<Rigidbody>()));
                wallsResicle.RemoveAt(LastIndex);
            }
        }
    }

    IEnumerator blockFallAwayInit(Rigidbody blockBody) 
    {
        wallsResicle.Add(blockBody.gameObject);
        blockBody.isKinematic = true;
        yield return new WaitForSeconds(fallAwayDelay);
        blockBody.isKinematic = false;
        blockBody.AddTorque(new Vector3(Random.Range(-torquRandomRange, torquRandomRange), Random.Range(-torquRandomRange, torquRandomRange), Random.Range(-torquRandomRange, torquRandomRange)));
        blockBody.AddForce(new Vector3(Random.Range(0f, forceRandomRange), Random.Range(0f, forceRandomRange), 0f));
    }

    IEnumerator blockFallAway(Rigidbody blockBody)
    {
        blockBody.isKinematic = true;
        yield return new WaitForSeconds(fallAwayDelay);
        blockBody.isKinematic = false;
        blockBody.AddTorque(new Vector3(Random.Range(-torquRandomRange, torquRandomRange), Random.Range(-torquRandomRange, torquRandomRange), Random.Range(-torquRandomRange, torquRandomRange)));
        blockBody.AddForce(new Vector3(Random.Range(0f, forceRandomRange), Random.Range(0f, forceRandomRange), 0f));
        yield return new WaitForSeconds(deathTime); 
        wallsResicle.Add(blockBody.gameObject);
    }
}
