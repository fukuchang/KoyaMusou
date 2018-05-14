using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChanger : MonoBehaviour {

	public Animator anim;

	public int speed;
	public int high;

	public int PlayerATK;
	GoalScript GS;

	private bool jab;
	private bool run;
	private bool jump;
	private bool goal;
	private bool atk1;
	private bool atk2;
	private bool atk3;
	private bool dead;

	bool life;

	//EnemyScript ES;
	PlayerScript PS;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		//ES = GameObject.Find ("Enemy").GetComponent<EnemyScript> ();
		PS = GameObject.Find("player").GetComponent<PlayerScript>();
		PlayerATK = 1;
		GS = GameObject.Find ("Goal").GetComponent<GoalScript> ();
		//Debug.Log (GS.goal);
		life = true;
		speed = 8;
		high = 2;
	}
	
	// Update is called once per frame
	void Update () {

		if (life == true) {
			if (Input.GetMouseButton (0)) {
				//Debug.Log ("Debug");

				if (PS.ATKlv == 0) {
					anim.SetBool ("jab", true);
				} else if (PS.ATKlv == 1) {
					anim.SetBool ("atk1", true);
				} else if (PS.ATKlv == 2) {
					anim.SetBool ("atk2", true);
				} else {
					anim.SetBool ("atk3", true);
				}

			} else {
				if (PS.ATKlv == 0) {
					anim.SetBool ("jab", false);
				} else if (PS.ATKlv == 1) {
					anim.SetBool ("atk1", false);
				} else if (PS.ATKlv == 2) {
					anim.SetBool ("atk2", false);
				} else {
					anim.SetBool ("atk3", false);
				}
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (new Vector3 (0, -90, 0) * Time.deltaTime, Space.Self);
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (new Vector3 (0, 90, 0) * Time.deltaTime, Space.Self);
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				//Debug.Log(transform.forward);
				anim.SetBool ("run", true);
				transform.position += transform.forward * speed * Time.deltaTime;
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				anim.SetBool ("run", true);
				transform.position += transform.forward * -speed * Time.deltaTime;
			} else {
				anim.SetBool ("run", false);
			}

			if (Input.GetKey (KeyCode.Space)) {
				transform.position += transform.transform.up * high * Time.deltaTime;
				anim.SetBool ("jump", true);
			} else {
				anim.SetBool ("jump", false);
			}

			if (GS.goal == true) {
				anim.SetBool ("goal", true);
			}

			if (PS.PlayerHP <= 0) {
				life = false;
				anim.SetBool ("dead", true);
			}
		}
			
	}
	/*
	void OnCollisionEnter(Collision other){
		if (other.collider.tag == "Enemy") {
			//if (jab == true) {
			Destroy (other.gameObject);
			//}
		}
	}
	*/
}
