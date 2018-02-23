using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
	public bool moveleft;
	public LayerMask groundLayer;
	public Transform wallCheck;
	public float wallCheckRadius;
	private bool wallCollision;
	public float speed;
	public Rigidbody2D player;
	public float hitPoints;
	public float playerX;
	public float bossOvershoot;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate() {
		wallCollision = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, groundLayer);
	}

	// Update is called once per frame 
	void Update () {
		if (hitPoints <= 0) {
//		Debug.Log ("kill boss");	
		}


		playerX = player.position.x;
		var boss = GetComponent<Rigidbody2D> ();
		var bossX = boss.position.x;

		if (moveleft && playerX > bossX + bossOvershoot) {
			moveleft = false;
		} else if (!moveleft && playerX + bossOvershoot < bossX) {
			moveleft = true;
		}

//		if (wallCollision) {
//					Debug.Log ("hit the wall");
//			moveleft = !moveleft;
//		}
		var horizontalFlip = System.Math.Abs(transform.localScale.x);
		var verticalFlip = transform.localScale.y;
		if (moveleft) {
			transform.localScale = new Vector2 (horizontalFlip, verticalFlip);
			boss.velocity = new Vector2 (-speed, boss.velocity.y);
		} else {
			transform.localScale = new Vector2 (-horizontalFlip, verticalFlip);
			boss.velocity = new Vector2 (speed, boss.velocity.y);
		}
	}		
}
