using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {
    
    public GameObject[] easyObstacles;
    public GameObject[] hardObstacles;
    public GameObject collect;
    public GameObject floor;
    public GameObject player;

    private int floorX;
    public float difficulty = 4f; //change to private after
    // Use this for initialization
    void Start () {
        InitFloor();
        InvokeRepeating("SpawnFloor", 0, 0.25f);
        Invoke("GenerateEasyObstacle", 2);
        //Instantiate(player, new Vector3(1, 4, -11), Quaternion.identity);
        InvokeRepeating("IncrementDifficulty", 4, 4);
	}

    void Update() {
        if (difficulty < 1) {
            difficulty = 1;
        }
    }

    private void InitFloor() {
        GameObject tempFloor;
        float time = 0.25f;
        for (int i = 0; i < 10; i++) {
            floorX = i * 3;
            tempFloor = (GameObject)Instantiate(floor, new Vector3(floorX, 0, 0), Quaternion.identity);
            tempFloor.GetComponent<FloorController>().fallTime = time;
            time += 0.25f;
        }
    }

    private void SpawnFloor() {
        GameObject tempFloor;
        floorX += 3;
        tempFloor = (GameObject)Instantiate(floor, new Vector3(floorX, 0, 0), Quaternion.identity);
        tempFloor.GetComponent<FloorController>().fallTime = 2.75f;
    }

    private void GenerateEasyObstacle() {
        int rolled = Random.Range(0, easyObstacles.Length);
        SpawnCollectEasy(rolled);
        Instantiate(easyObstacles[rolled], new Vector3(floorX, 2.5f, 1), Quaternion.identity);
        if (difficulty < 3) {
            switch (Random.Range(0, 2)) {
                case 0:
                    Invoke("GenerateEasyObstacle", difficulty);
                    break;
                case 1:
                    Invoke("GenerateHardObstacle", difficulty);
                    break;
            }
        } else {
            Invoke("GenerateEasyObstacle", difficulty);
        }
    }

    private void GenerateHardObstacle() {
        int rolled = Random.Range(0, hardObstacles.Length);
        SpawnCollectHard(rolled);
        Instantiate(hardObstacles[rolled], new Vector3(floorX, 2.5f, 1), Quaternion.identity);
        if (difficulty < 3) {
            switch (Random.Range(0, 2)) {
                case 0:
                    Invoke("GenerateEasyObstacle", difficulty);
                    break;
                case 1:
                    Invoke("GenerateHardObstacle", difficulty);
                    break;
            }
        } else if (difficulty < 2) {
            Invoke("GenerateHardObstacle", difficulty);
        }
    }

    private void SpawnCollectEasy(int arrayLoc) {
        if (arrayLoc == 0) {
            int choice = Random.Range(0, 2);
            switch (choice) {
                case 0:
                    // No prize for you!
                    break;
                case 1:
                    Instantiate(collect, new Vector3(floorX, 4.65f, -11f), Quaternion.identity);
                    break;
            }
        } else if (arrayLoc == 1) {
            int choice = Random.Range(0, 2);
            switch (choice) {
                case 0:
                    // No prize for you!
                    break;
                case 1:
                    Instantiate(collect, new Vector3(floorX, 3.5f, 0.75f), Quaternion.identity);
                    break;
            }
        } else if (arrayLoc == 2) {
            int choice = Random.Range(0, 2);
            switch (choice) {
                case 0:
                    Instantiate(collect, new Vector3(floorX, 3.5f, 6.75f), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(collect, new Vector3(floorX, 3.5f, -5), Quaternion.identity);
                    break;
            }
        }
    }

    private void SpawnCollectHard(int arrayLoc) {
        if (arrayLoc == 0) {
            switch (Random.Range(0, 2)) {
                case 0:
                    // No prize for you!
                    break;
                case 1:
                    Instantiate(collect, new Vector3(floorX, 3.5f, 0.75f), Quaternion.identity);
                    break;
            }
        } else if (arrayLoc == 1) {
            switch (Random.Range(0, 2)) {
                case 0:
                    Instantiate(collect, new Vector3(floorX, 3.5f, -6f), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(collect, new Vector3(floorX, 3.5f, 7f), Quaternion.identity);
                    break;
            }
        }
    }

    private void IncrementDifficulty() {
        if (Random.Range(0, 2) == 0) {
            difficulty -= 0.25f;
        }
    }
}
