using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

	public GameObject obstaclePrefab;
	public int obstaclePoolSize = 5;
	public float spawnRate = 4f;
	public float obsMin = -1f;
	public float obsMax = 3.5f;

	private GameObject container;
    private GameObject[] obstacles;
    //List<GameObject> obstacles = new List<GameObject>();
    private Vector2 objPoolPosition = new Vector2 (-15f, -25f);
	private float timeSinceLastSpawned;
	private float spawnXPosition = 10f;
	private int currentObsColumn = 0;

	void Start () {
		timeSinceLastSpawned = 0f;
		//obstacles = new List<GameObject>(obstaclePoolSize);

		obstacles = new GameObject[obstaclePoolSize];
		for (int i = 0; i < obstaclePoolSize; i++)
		{
			obstacles[i] = (GameObject)Instantiate(obstaclePrefab, objPoolPosition, Quaternion.identity, transform);
		}

	}

	void Update () {
		timeSinceLastSpawned += Time.deltaTime;
		if (GameManager.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{
			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range (obsMin, obsMax);
			obstacles [currentObsColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
			currentObsColumn++;

			if (currentObsColumn >= obstaclePoolSize) 
			{
				currentObsColumn = 0;
			}
		}
	}
}
