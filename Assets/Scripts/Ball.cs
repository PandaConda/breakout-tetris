using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed = 1f;
	public Vector2 startPosition;



	void Start() {
		gameObject.tag = "Ball";

		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

		rigidbody.position = startPosition;
		rigidbody.velocity = Vector2.zero;

		// Give it a random starting direction;
		if(Random.Range(0, 2) == 0) {
			rigidbody.AddForce((-transform.up + 0.1f * transform.right).normalized * speed);
		} else {
			rigidbody.AddForce((-transform.up - 0.1f * transform.right).normalized * speed);
		}

	}


	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "Bottom Wall") {
			Start();
		}
	}

}
