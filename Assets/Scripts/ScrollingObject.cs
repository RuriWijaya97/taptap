using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rbody;

	void Awake ()
	{
		rbody = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Start ()
	{
		rbody.velocity = new Vector2(GameManager.instance.scrollSpeed, 0);
	}

	void Update () {
		if (GameManager.instance.gameOver == true)
		{
			rbody.velocity = Vector2.zero;
		}	
	}
}
