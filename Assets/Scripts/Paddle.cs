using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private const int SPEED = 10;

	Rigidbody2D body;
	bool leftPressed, rightPressed;
	bool leftEdge, rightEdge;
	int vx; // x velocity

	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
		leftPressed = false;
		rightPressed = false;
		leftEdge = false;
		rightEdge = false;
		vx = 0;
	}
	
	void Update () {
		if (Input.GetKey("left") && !leftEdge) {
			leftPressed = true;
			rightEdge = false;
			vx = -1;
		} else if (Input.GetKeyUp("left")) {
			leftPressed = false;
			vx = rightPressed ? 1 : 0;
		} else if (Input.GetKey("right") & !rightEdge) {
			rightPressed = true;
			leftEdge = false;
			vx = 1;
		} else if (Input.GetKeyUp("right")) {
			rightPressed = false;
			vx = leftPressed ? -1 : 0;
		}

		if (vx != 0) {
			body.position += Vector2.right * vx * SPEED;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name == "Left Wall") {
			leftEdge = true;
			Vector2 p = body.position;
			p.x = col.bounds.max.x
				+ (body.GetComponent<Renderer>()
						.bounds.size.x / 2);
			body.position = p;
			vx = 0;
		} else if (col.gameObject.name == "Right Wall") {
			rightEdge = true;
			Vector2 p = body.position;
			p.x = col.bounds.min.x
				- (body.GetComponent<Renderer>()
						.bounds.size.x / 2);
			body.position = p;
			vx = 0;
		}
	}
}
