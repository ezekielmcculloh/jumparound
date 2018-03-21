using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float fireRate = 0;
	public float damage = 1;
	public LayerMask whatToHit;

	public SpriteRenderer sprite;
	// Use this for initialization
	public bool canShootHorns;
	public float hornShotDistance;
	public float hornShotSpeed;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float hitPoints;
	public float groundCheckRadius;
	private bool grounded;
	public float maxHitPoints;
	public bool facingRight = true;
	public float SuperTime;
	float timeToFire = 0;
	Transform firePoint;

	void Start () {
		maxHitPoints = 10;
		hitPoints = maxHitPoints;
		hornShotDistance = 5;
		hornShotSpeed = 15;

		firePoint = transform.Find ("hornFirepoint");
		if (firePoint == null) {
			Debug.LogError ("no firepoint found");
		}
	}
	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
	}

	// Update is called once per frame
	void Update () {
		manageHP ();
		stopPlayer();
		handleInput ();
	}

	void manageHP () {
		var transform = GetComponent<Transform> ();
		if (hitPoints <= 0) {
			hitPoints = maxHitPoints;
			transform.position = new Vector2 (2, 1);
		}
	}

	void stopPlayer () {
		var rigidBody = GetComponent<Rigidbody2D> ();
		var currentVector = rigidBody.velocity;
		var originalY = currentVector.y;
		rigidBody.velocity = new Vector2 (0, originalY);
	}

	void moveDirection (string direction) {
		var rigidBody = GetComponent<Rigidbody2D> ();
		var currentVector = rigidBody.velocity;
		var originalY = currentVector.y;

		rigidBody.velocity = new Vector2 (0, originalY);

		if (direction == "right") {
			sprite.flipX = false;
			rigidBody.velocity = new Vector2 (5, originalY);
			facingRight = true;
		} else if (direction == "left"){
			sprite.flipX = true;
			rigidBody.velocity = new Vector2 (-5, originalY);
			facingRight = false;
		}
	}

	void jump () {
		if (grounded) {
			var rigidBody = GetComponent<Rigidbody2D> ();
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, 9);
		}
	}

	void sink () {
		var rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.velocity = new Vector2 (rigidBody.velocity.x, -5);
	}

	void handleInput () {
		if (Input.GetKey ("d")) {
			moveDirection ("right");
		} else if (Input.GetKey ("a")) {
			moveDirection ("left");
		}
		if (Input.GetKeyDown ("space")) {
			jump ();
		}
		if (Input.GetKey ("down")) {
			sink ();
		}
		if (Input.GetKeyDown ("j")) {
			AttemptShot ();
		}
	}

	void Shoot () {
		float x = hornShotSpeed;
		if (!facingRight) {
			x = -hornShotSpeed;
		}
			
		Vector2 shotDirection = new Vector2 (x, 0);
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition, shotDirection, hornShotDistance, whatToHit);
		Debug.DrawLine (firePointPosition, (firePointPosition + shotDirection));
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("hit " + hit.collider.name);
		}
	}

	void AttemptShot () {
		if (canShootHorns) {
			if (fireRate == 0) {	
				Debug.Log ("SHOOT THE HORN YO!!!!!");
				Shoot ();
			} else if (Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Debug.Log ("SHOOT THE HORN YO!!!!!");
				Shoot ();
			}
		}
	}

	public void OnTriggerEnter2D (Collider2D other) {
		var transform = GetComponent<Transform> ();

		if (other.name == "EnemyDamage") {
			hitPoints = hitPoints - 1;
		} else if (other.name == "flower") {
				hitPoints = hitPoints - 1;
		} else if (other.name == "boss ") {
				hitPoints = hitPoints - 2;
		} else if (other.name == "elivaiter") {
			Debug.Log ("use the elivaiter");
			transform.position = new Vector2 (2743,-299);
		} else if (other.name == "PowerUp") {
			Debug.Log ("get power up");
			canShootHorns = true;
		} else if (other.name == "Elivaiter (1)") {
			Debug.Log ("use the elivaiter");
			transform.position = new Vector2 (1396,-496);
		} else if (other.name == "energyTank") {
			hitPoints = maxHitPoints + 10;
		} else if (other.name == "asid") {
//			hitPoints = hitPoints - 5;
			hitPoints = hitPoints - 10;
		} else	if (other.name == "superTime") {
			SuperTime = SuperTime - 1;
		} else {
			//			Debug.Log (other.name);
			//			Debug.Log (other.name == "elivaiter");
		}
	}
}
