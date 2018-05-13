using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

	public bool goal;

	// Use this for initialization
	void Start () {
		goal = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			goal = true;
			Debug.Log ("Goooooooooal!");
		}
	}
}
