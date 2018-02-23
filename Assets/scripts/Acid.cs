using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour {
	public string position;
	public float initialX;
	public float initialY;

	// Use this for initialization
	void Start () {
		position = "raised";
		var transform = GetComponent<Transform> ();
		initialX = transform.position.x;
		initialY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () { 

	}
}
