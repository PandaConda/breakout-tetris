using UnityEngine;



public class Paddle : MonoBehaviour {
	public float maxMovementSpeed = 10f;
	public float paddleScale = 200f;
		
	private Rigidbody2D _mRigidbody;
	private Renderer _mRenderer;
	private float _paddleWidth;
	private bool canGoLeft = true;
	private bool canGoRight = true;



	void Start () {
		_mRigidbody = GetComponent<Rigidbody2D>();
		_mRenderer = GetComponent<Renderer>();

		transform.localScale = new Vector3(paddleScale, paddleScale, 1);

		_paddleWidth = _mRenderer.bounds.size.x;
	}

	
	void Update () {
		float input = Input.GetAxis("Horizontal");

		if(!canGoLeft && input < 0 || !canGoRight && input > 0)
			return;

		if(!canGoLeft && input > 0)
			canGoLeft = true;

		if(!canGoRight && input < 0)
			canGoRight = true;

		_mRigidbody.position = _mRigidbody.position + Vector2.right * input * maxMovementSpeed * Time.deltaTime;
//        transform.position = (Vector2)transform.position + Vector2.right * input * maxMovementSpeed * Time.deltaTime;
    }


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Left Wall") {
			canGoLeft = false;

			Vector2 position = _mRigidbody.position;
			position.x = other.bounds.max.x + (_paddleWidth / 2);
			_mRigidbody.position = position;
		} else if (other.gameObject.name == "Right Wall") {
			canGoRight = false;

			Vector2 position = _mRigidbody.position;
			position.x = other.bounds.min.x - (_paddleWidth / 2);
			_mRigidbody.position = position;
		}
	}

}
