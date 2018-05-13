using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	//public GameObject enemy;
	public int MaxHP = 100;
	public int PlayerHP;
	public int RecoveryNum = 0;
	public int ATKlv = 0;
	public int KeyNum = 0;
	public int PlayerATK;
	EnemyScript ES;
	Slider HPslider;
	Text HPtext;
	Text Recoverytext;
	Text KeyText;

	// Use this for initialization
	void Start () {

		PlayerATK = 1;
		PlayerHP = MaxHP;
		//ES = enemy.GetComponent<EnemyScript> ();
		HPslider = GameObject.Find ("Slider").GetComponent<Slider> ();
		HPtext = GameObject.Find ("PlayerHP").GetComponent<Text> ();
		Recoverytext = GameObject.Find ("RecoveryNum").GetComponent<Text> ();
		KeyText = GameObject.Find ("KeyNum").GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		//-----Player HP----------
		if (PlayerHP <= 0) {
			Debug.Log ("死亡しました。");
		} else if (PlayerHP >= 100) {
			PlayerHP = 100;
		}

		//-----Recovery Num--------
		if (RecoveryNum < 0) {
			RecoveryNum = 0;
		}

		//-----ATK Level----------
		if (ATKlv == 0) {
			PlayerATK = 1;
		} else if (ATKlv == 1) {
			PlayerATK = 3;
		} else if (ATKlv == 2) {
			PlayerATK = 5;
		} else {
			PlayerATK = 10;
		}


		//-----Input KeyBord---------
		if (Input.GetKeyDown ("s")) {
			RecoveryNum--;
			PlayerHP += 10;
		}

		HPslider.value = PlayerHP;
		HPtext.text = PlayerHP.ToString();
		Recoverytext.text = RecoveryNum.ToString ();
		KeyText.text = KeyNum.ToString ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Sword") {
			ES = other.gameObject.transform.parent.gameObject.GetComponent<EnemyScript> ();
			PlayerHP -= ES.ATKpower;
			//Debug.Log (PlayerHP);
		}
		if (other.tag == "Sword1") {
			ES = GameObject.Find ("samurai lv2").GetComponent<EnemyScript> ();
			PlayerHP -= ES.ATKpower;
		}

		if (other.tag == "Recovery") {
			RecoveryNum++;
			Destroy (other.gameObject);
		}
			
		if (other.tag == "PowerUp") {
			ATKlv++;
			Destroy (other.gameObject);
		}

		if (other.tag == "Key") {
			KeyNum++;
			Destroy (other.gameObject);
		}
	}

}
