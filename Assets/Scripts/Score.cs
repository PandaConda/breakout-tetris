using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int pointsPerBrickSpawned;
	public int pointsPerRowCleared;
	private int currentScore;
	private Text textbox;

	// Use this for initialization
	void Start () {
		textbox = GetComponent<Text>();
		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset() {
		currentScore = 0;
		textbox.text = currentScore.ToString();
	}

	public void SpawnBrick() {
		currentScore += pointsPerBrickSpawned;
		textbox.text = currentScore.ToString();
	}

	public void RemoveRow() {
		currentScore += pointsPerRowCleared;
		textbox.text = currentScore.ToString();
	}
}
