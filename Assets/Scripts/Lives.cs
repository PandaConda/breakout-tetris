using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

	public int livesAtStart;
	private int lives;
	private Score score;
	private BrickManager brickManager;
	private Text textbox;

	// Use this for initialization
	void Start () {
		score = (Score)GameObject.Find("Score Value").GetComponent(typeof(Score));
		brickManager = (BrickManager)GameObject.Find("BrickManager").GetComponent(typeof(BrickManager));
		textbox = GetComponent<Text>();
		lives = livesAtStart;
		textbox.text = lives.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Die() {
		if (--lives < 0) {
			LoadLevel.StopGame();
		} else {
			textbox.text = lives.ToString();
		}
	}
}
