using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float upForce = 200f;
	private bool isDead = false;
	bool isStarted = false;
	private Rigidbody2D rbody;
	private Animator anim;

	void Awake () 
	{
		rbody = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		Time.timeScale = 0;
	}

	void Start() 
	{
		anim.Play("Fly");
	}

	void Update () 
	{
		if (isDead == false) 
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (!isStarted)
				{
					isStarted = true;
					Time.timeScale = 1;
					GameManager.instance.BeginGame();
				}

				rbody.velocity = Vector2.zero;
				rbody.AddForce (new Vector2( 0, upForce));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		rbody.velocity = Vector2.zero;
		GameManager.instance.Died ();
 		anim.enabled = false;
		isDead = true;
	}

}
