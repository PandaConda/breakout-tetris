using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private const int THRUST = 1;

	public Rigidbody2D body;

	void Start () {
		Rigidbody2D body = GetComponent<Rigidbody2D>();
		body.position = new Vector2(0, -525);
		body.velocity = Vector2.zero;
		if (Random.Range(0, 2) == 0) {
			body.AddForce(transform.up + transform.right * THRUST);
		} else {
			body.AddForce(transform.up - transform.right * THRUST);

		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.name == "Bottom Wall") {
			Start();
		}
	}
}
