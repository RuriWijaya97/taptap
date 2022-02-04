using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private BoxCollider2D boxCollider;
	private float groundHorizontalLength;

	void Start () {
		boxCollider = gameObject.GetComponent<BoxCollider2D> ();
		groundHorizontalLength = boxCollider.size.x;
	}
	
	void Update () {
		if (transform.position.x < - groundHorizontalLength * 1.5f) 
		{
			RepositionBackground ();
		}
	}

	void RepositionBackground()
	{
		Debug.Log($"Repeat background : {gameObject.name}");
		Vector2 groundOffset = new Vector2 (groundHorizontalLength * 3f, 0);
		Debug.Log (groundOffset);
		transform.position = (Vector2)transform.position + groundOffset;
	}
}
