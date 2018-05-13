using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

	public Collider col;

	// Use this for initialization
	void Start () {
		col = GetComponent<SphereCollider> ();
		col.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			col.enabled = true;
		} else {
			col.enabled = false;
		}
	}
}
