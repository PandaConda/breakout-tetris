using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public void Update() {
		if (Input.anyKeyDown) {
			StartGame();
		}
	}

	public static void StartGame() {
		SceneManager.LoadScene("Level", LoadSceneMode.Single);
	}

	public static void StopGame() {
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
}
