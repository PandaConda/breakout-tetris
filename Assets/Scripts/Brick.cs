using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public float enableColliderDelay = 2f;
	public int x,y;
	public GameObject brickSpawn;
    public int emitParticlesAtSpawn = 100;

    private ParticleSystem _particleSystem;

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

// #STEFFEN spawn on destroy particle effect here!
    }


	void Start() {
        //		_mRigidbody = GetComponent<Rigidbody2D>();
        //		_mRenderer = GetComponent<Renderer>();

        //		_width = _mRenderer.bounds.size.x;
        //		_height = _mRenderer.bounds.size.y;

        _particleSystem = GetComponent<ParticleSystem>();

        if (_particleSystem)
            _particleSystem.Emit(emitParticlesAtSpawn);
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
				Instantiate(brickSpawn, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal, Vector3.up));
			} else if(Mathf.Approximately(angle, 0)) {
				SpawnBrick(Vector2.down);
//				Debug.Log("hit on bottom");
				Instantiate(brickSpawn, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal, Vector3.up));
			} else if(Mathf.Approximately(angle, 90)){
				ContactPoint2D contact = collision.contacts[0];

				if(contact.collider.transform.position.x > contact.otherCollider.transform.position.x) {
					SpawnBrick(Vector2.right);
//					Debug.Log("hit on right");
					Instantiate(brickSpawn, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal, Vector3.up));
				} else {
					SpawnBrick(Vector2.left);
//					Debug.Log("hit on left");
					Instantiate(brickSpawn, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal, Vector3.up));
				}
			}
		}
	}


	void SpawnBrick(Vector2 direction) {
		if(direction == Vector2.up) {
<<<<<<< HEAD
			BrickManager.instance.SpawnBrick(x, y - 1);
			//Instantiate(brickSpawn, x, y, -1);
		} else if(direction == Vector2.right) {
			BrickManager.instance.SpawnBrick(x + 1, y);
			//Instantiate(brickSpawn, x, +1, y);
		} else if(direction == Vector2.down) {
			BrickManager.instance.SpawnBrick(x, y + 1);
			//Instantiate(brickSpawn, x, y, +1);
		} else if(direction == Vector2.left) {
			BrickManager.instance.SpawnBrick(x - 1, y);
			//Instantiate(brickSpawn, x, -1, y);
=======
			BrickManager.instance.SpawnBrick(x, y - 1, true);
		} else if(direction == Vector2.right) {
			BrickManager.instance.SpawnBrick(x + 1, y, true);
		} else if(direction == Vector2.down) {
			BrickManager.instance.SpawnBrick(x, y + 1, true);
		} else if(direction == Vector2.left) {
			BrickManager.instance.SpawnBrick(x - 1, y, true);
>>>>>>> 6994059390fa630d29b89d260b3c7f0eadc2a421
		}
	}

}
