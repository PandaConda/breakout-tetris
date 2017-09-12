using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Rigidbody2D body;

	// Use this for initialization
	void Start () {
		Rigidbody2D body = GetComponent<Rigidbody2D>();
		const int thrust = 1;
		if (Random.Range(0, 2) == 0) {
			body.AddForce(transform.up + transform.right * thrust);
		} else {
			body.AddForce(transform.up - transform.right * thrust);

		}
	}
}
