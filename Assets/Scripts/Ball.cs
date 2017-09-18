using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed;
	public Vector2 startPosition;
	private Lives lives;

	void Start() {
		gameObject.tag = "Ball";
		lives = (Lives)GameObject.Find("Lives Value").GetComponent(typeof(Lives));
		StartGame();

	}

	private void StartGame() {
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.position = startPosition;
		rigidbody.velocity = Vector2.zero;

		// Give it a random starting direction;
		if(Random.Range(0, 2) == 0) {
			rigidbody.AddForce(transform.up + transform.right * speed);
		} else {
			rigidbody.AddForce(transform.up - transform.right * speed);
		}
	}


	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "Bottom Wall") {
			lives.Die();
			StartGame();
		}
	}

}
