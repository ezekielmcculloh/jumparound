using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBug : NewBehaviourScript1 {
	public LayerMask groundLayer;
	public Transform wallCheck;
	public float wallCheckRadius;
	public bool wallCollision;

	// Use this for initialization
	void Start () {
		//		Debug.Log ("Start");

	}

	void FixedUpdate() {
		wallCollision = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, groundLayer);
	}
		
	void Update () {
		var rB = GetComponent<Rigidbody2D> ();

		rB.velocity = new Vector2 (rB.velocity.x, 3);
		Debug.Log("imn updater");

		if (wallCollision) {
			//		Debug.Log ("hit the wall");
			moveleft = !moveleft;
		}
		if (moveleft) {
			transform.localScale = new Vector2 (1, 1);
			rB.velocity = new Vector2 (-speed, rB.velocity.y);
		} else {
			transform.localScale = new Vector2 (-1, 1);
			rB.velocity = new Vector2 (speed, rB.velocity.y);
		}
	}	

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "HeadStomper") {
			transform.position = new Vector2 (2911,-481);
		} else if (other.name == "enemeyTelaport") {
			transform.position = new Vector2 (2911,-481);
			
	}
}
}