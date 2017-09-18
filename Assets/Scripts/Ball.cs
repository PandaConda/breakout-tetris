using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector2 startPosition;
	public float startSpeed;
	public float speedUpFactor;
	private float speed;
	private Lives lives;
	private Rigidbody2D body;

	void Start() {
		gameObject.tag = "Ball";
		lives = (Lives)GameObject.Find("Lives Value").GetComponent(typeof(Lives));
		StartGame();

	}

	private void StartGame() {
		body = GetComponent<Rigidbody2D>();
		body.position = startPosition;
		body.velocity = Vector2.zero;
		speed = startSpeed;

		// Give it a random starting direction;
		int rnd = Random.Range(0, 3);
		if (rnd == 0) {
			// left
			body.AddForce((transform.up - transform.right) * speed);
		} else if (rnd == 1) {
			// up
			body.AddForce(transform.up * speed);
		} else {
			// right
			body.AddForce((transform.up + transform.right) * speed);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "Bottom Wall") {
			lives.Die();
			StartGame();
		}
	}

	public void SpeedUp() {
		Vector2 v = body.velocity / speed;
		speed += speedUpFactor;
		body.velocity = v * speed;
	}
}
