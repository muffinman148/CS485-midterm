using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	private float timeLeft = 120;
	public int playerScore = 0;
	public GameObject timeLeftUI;
	public GameObject playerScoreUI;
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timeLeftUI.gameObject.GetComponent<Text> ().text = ("Time: " + (int)timeLeft);
		playerScoreUI.gameObject.GetComponent<Text> ().text = ("Score: " + playerScore);
		if (timeLeft < 0.1f) {
			SceneManager.LoadScene ("Scene_1");
		}
	}

	// Enter Event Triggers
	void OnTriggerEnter2D (Collider2D trig) {
		if (trig.gameObject.tag == "EndLevel") {
			CountScore();
			Destroy (GameObject.FindWithTag("EndLevel"));
		}

		if (trig.gameObject.tag == "diamond") {
			playerScore += 100;
			Destroy (trig.gameObject);
		}
	}

	// Score at End
	void CountScore() {
		playerScore += (int)(timeLeft * 100);
		Debug.Log (playerScore);
	}
		
}
