using UnityEngine;

public class BrickManager : MonoBehaviour {
	#region Singelton Pattern
	private static BrickManager brickManager;

	public static BrickManager instance {
		get {
			if(!brickManager) {
				brickManager = FindObjectOfType(typeof(BrickManager)) as BrickManager;

				if(!brickManager) {
					Debug.LogError("There needs to be one active BrickManager script on a GameObject in your scene.");
				} else {
					brickManager.Init();
				}
			}

			return brickManager;
		}
	}
	#endregion

	public int rowSize = 5;         // Maximum number of block that can be in a row
	public int columnSize = 6;		// Maximum number of blocks that can be in a column
	public Vector2 startPosition;	// Position where block [0,0] is placed

	public float horizontalOffset = 200f;	// Distance between blocks that are placed (horizontally) next to each other
	public float verticalOffset = 50f;		// Distance between blocks that are placed above or below each other

	public GameObject brickPrefab;

	private Brick[,] brickMatrix;
	private Ball ball;
	private Score score;

	void Start () {
		ball = (Ball)GameObject.Find("Ball_Particles").GetComponent(typeof(Ball));
		score = (Score)GameObject.Find("Score Value").GetComponent(typeof(Score));
		brickMatrix = new Brick[rowSize, columnSize];
		Init();
	}

	public void Init() {
		SpawnBrick(0, 0, false);
		SpawnBrick(1, 0, false);
		SpawnBrick(2, 0, false);
		SpawnBrick(3, 0, false);
		SpawnBrick(1, 1, false);
		SpawnBrick(2, 1, false);
		SpawnBrick(3, 1, false);
		SpawnBrick(4, 1, false);
	}

	public void Reset() {
		// Clean up removed row, plus move everything below up
		for (int y = 0; y < columnSize; y++) {
			for (int x = 0; x < rowSize; x++) {
				if (brickMatrix[x, y] != null) {
					Destroy(brickMatrix[x, y].gameObject);
					brickMatrix[x, y] = null;
				}
			}
		}
		Init();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnBrick(int x, int y, bool givePoint) {
		Debug.Log("expanding" + x + " - " + y);
		// Check if were within bounds
		if(x >= 0 && x < rowSize && y >= 0 && y < columnSize) {
			// Check if cell already contains a brick, if so stop
			if(brickMatrix[x, y] != null)
				return;

			// Else spawn a block
			GameObject brick = Instantiate(brickPrefab, new Vector2(startPosition.x + x * horizontalOffset, startPosition.y + -y * verticalOffset), Quaternion.identity, transform) as GameObject;
			brickMatrix[x, y] = brick.GetComponent<Brick>();
			brickMatrix[x, y].x = x;
			brickMatrix[x, y].y = y;

			if (givePoint) {
				score.SpawnBrick();
			}

			// Since we spawned a new brick we need to check if it has filled the row
			CheckFullRows();
		}
	}

	// #TODO atm bruteforce by checking whole field, could be done more efficiently
	void CheckFullRows() {
		for(int y = 0; y < columnSize; y++) {
			for(int x = 0; x < rowSize; x++) {
				if(brickMatrix[x, y] == null)
					break;

				if(x == rowSize - 1)
					RemoveRow(y);
			}
		}
	}


	void RemoveRow(int height) {
		Debug.Log("Row removed at height: " + height);
		score.RemoveRow();
		ball.SpeedUp();

		// Clean up removed row, plus move everything below up
		for(int x = 0; x < rowSize; x++) {
			Destroy(brickMatrix[x, height].gameObject);
		}

		// Move all rows below, one up
		for(int y = height + 1; y < columnSize; y++) {
			for(int x = 0; x < rowSize; x++) {
				if(brickMatrix[x, y] == null)
					continue;

				brickMatrix[x, y].y -= 1;
				brickMatrix[x, y].transform.position = new Vector2(startPosition.x + x * horizontalOffset, startPosition.y + -(y -1) * verticalOffset);
				brickMatrix[x, y - 1] = brickMatrix[x, y];
				brickMatrix[x, y] = null;
			}
		}
	}
}
