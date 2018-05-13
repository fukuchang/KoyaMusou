using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public int ATKpower = 1;
	public int EnemyHP = 1;
	//AnimationChanger AC;
	PlayerScript PS;



	// Use this for initialization
	void Start () {
		//AC = GameObject.Find ("player").GetComponent<AnimationChanger> ();
		PS = GameObject.Find ("player").GetComponent<PlayerScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
		
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "UniPlayer") {
			Debug.Log ("Collision");
			EnemyHP -= PS.PlayerATK;
			//Debug.Log (EnemyHP);
			if (EnemyHP <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
