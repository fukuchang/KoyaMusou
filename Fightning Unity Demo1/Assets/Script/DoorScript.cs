using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {


	PlayerScript PS;
	public int SetNumKey = 1;
	Text consoleText;

	int needKey;

	// Use this for initialization
	void Start () {
		PS = GameObject.Find ("player").GetComponent<PlayerScript> ();
		consoleText = GameObject.Find ("ConsoleText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		needKey = SetNumKey - PS.KeyNum;

	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			if (needKey != 0) {
				consoleText.text = "You have to need more  " + needKey.ToString () + "  KEYS!!";
			} else {
				consoleText.text = "Please get down key 'd' !! You can go Next Zone.";
				if (Input.GetKeyDown ("d")) {
					//Debug.Log ("pressKey!");
					SceneManager.LoadScene ("Area2");
				}
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			consoleText.text = "";
		}
	}
}
