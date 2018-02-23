using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPad : MonoBehaviour {
	public bool toggled;
	public float initialX;
	public float initialY;

	// Use this for initialization
	void Start () {
		toggled = false;
		var transform = GetComponent<Transform> ();
		initialX = transform.position.x;
		initialY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		var transform = GetComponent<Transform> ();
		if (toggled) {
			transform.position = new Vector2 (initialX, initialY - 44);
		} else {
			transform.position = new Vector2 (initialX, initialY);
		}
	}

	public void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "HeadStomper") {
			toggled = true;
		}
	}
}
