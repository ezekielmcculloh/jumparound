using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class superTime : MonoBehaviour {
	public float SuperTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (other.name == "HeadStomper") {
			SuperTime = SuperTime - 1;
	}
}
}