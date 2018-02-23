using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
	public bool moveleft;
	public LayerMask groundLayer;
	public Transform wallCheck;
	public float wallCheckRadius;
	public bool wallCollision;
	public float speed;
	// Use this for initialization
	void Start () {
//		Debug.Log ("Start");
		moveleft = true;
	}

	void FixedUpdate() {
		wallCollision = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, groundLayer);
	}

	void extraMoves () {

	}

	// Update is called once per frame
	void Update () {
		var rB = GetComponent<Rigidbody2D> ();
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
			Destroy (gameObject);
		} else if (other.name == "enemeyTelaport") {
			transform.position = new Vector2 (2911,-479);
		}
	}
}
