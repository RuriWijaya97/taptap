using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameObject gameOverText;
	public GameObject playText;
	public float scrollSpeed = -1f;
	public bool gameOver = false;
	public int score = 0;
	public Text scoreText;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Update ()
	{
		if ((gameOver == true) && (Input.GetMouseButtonDown(0)))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void Score()
	{
		if (gameOver) {
			return;
		} else {
			score++;
			scoreText.text = "Score : " + score.ToString ();
		}
	}

	public void BeginGame()
	{
		playText.SetActive(false);
	}

	public void Died()
	{
		gameOverText.SetActive (true);
		gameOver = true;
	}
}
