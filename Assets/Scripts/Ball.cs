using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Rigidbody2D body;

	// Use this for initialization
	void Start () {
		Debug.Log("ball start");
		Rigidbody2D body = GetComponent<Rigidbody2D>();
		body.position = new Vector2(0, -525);
		body.velocity = Vector2.zero;
		//body.MovePosition(new Vector2(0, -525));
		const int thrust = 1;
		if (Random.Range(0, 2) == 0) {
			body.AddForce(transform.up + transform.right * thrust);
		} else {
			body.AddForce(transform.up - transform.right * thrust);

		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.name == "Bottom Wall") {
			Start();
		}
	}
}
