using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopWall : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we collide with ball
        // If thats the case determine on what side and spawn a brick at that location
        if (collision.gameObject.CompareTag("Ball"))        {
            float x = collision.gameObject.transform.position.x;
            Debug.Log("raw "+ x);
            x -= BrickManager.instance.startPosition.x;
            Debug.Log("rel " + x);
            x /= BrickManager.instance.horizontalOffset;
            Debug.Log("res " + x);

            BrickManager.instance.SpawnBrick((int)x, 0);
        }
    }
}