using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public float enableColliderDelay = 2f;
	public int x,y;

//	private Rigidbody2D _mRigidbody;
//	private Renderer _mRenderer;
//	private float _width;
//	private float _height;

	void Awake() {
		GetComponent<Collider2D>().enabled = false;

		Invoke("EnableCollider", enableColliderDelay);
	}


	void OnDisable() {
		CancelInvoke();
	}


	void Start() {
//		_mRigidbody = GetComponent<Rigidbody2D>();
//		_mRenderer = GetComponent<Renderer>();

//		_width = _mRenderer.bounds.size.x;
//		_height = _mRenderer.bounds.size.y;
	}


	void EnableCollider() {
		GetComponent<Collider2D>().enabled = true;
	}


	void OnCollisionEnter2D(Collision2D collision) {
		// Check if we collide with ball
		// If thats the case determine on what side and spawn a brick at that location
		if(collision.gameObject.CompareTag("Ball")) {
			float angle = Vector2.Angle(collision.contacts[0].normal, Vector2.up);

			if(Mathf.Approximately(angle, 180)) {
				SpawnBrick(Vector2.up);
//				Debug.Log("hit on top");
			} else if(Mathf.Approximately(angle, 0)) {
				SpawnBrick(Vector2.down);
//				Debug.Log("hit on bottom");
			} else if(Mathf.Approximately(angle, 90)){
				ContactPoint2D contact = collision.contacts[0];

				if(contact.collider.transform.position.x > contact.otherCollider.transform.position.x) {
					SpawnBrick(Vector2.right);
//					Debug.Log("hit on right");
				} else {
					SpawnBrick(Vector2.left);
//					Debug.Log("hit on left");
				}
			}
		}
	}


	void SpawnBrick(Vector2 direction) {
		if(direction == Vector2.up) {
			BrickManager.instance.SpawnBrick(x, y - 1);
		} else if(direction == Vector2.right) {
			BrickManager.instance.SpawnBrick(x + 1, y);
		} else if(direction == Vector2.down) {
			BrickManager.instance.SpawnBrick(x, y + 1);
		} else if(direction == Vector2.left) {
			BrickManager.instance.SpawnBrick(x - 1, y);
		}
	}

}
