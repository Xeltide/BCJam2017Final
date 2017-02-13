using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public int highScore = 0;
	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(transform.gameObject);
	}

    void Start() {
        if (GameObject.Find("HighScore") != this.gameObject) {
            GameObject.Find("HighScore").GetComponent<HighScore>().UpdateScore();
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        int currentScore = (int)GameObject.Find("Eggsy").GetComponent<Player3>().score;
        if (currentScore > highScore) {
            highScore = currentScore;
            UpdateScore();
        }
	}

    public void UpdateScore() {
        GameObject.Find("Canvas").transform.GetChild(2).GetComponent<Text>().text = "High: " + highScore;
    }
}
