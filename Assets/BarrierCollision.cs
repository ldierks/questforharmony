using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCollision : MonoBehaviour {

	public bool collisionEnabled;
	public bool disableCollisionOnStart;
	public bool jump;

	// Use this for initialization
	void Start () {
		if (!disableCollisionOnStart) {
			this.collisionEnabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collider) {
		Debug.Log("OnCollisionEnter");

		GameObject player = collider.gameObject;

		if (this.collisionEnabled) {
			Debug.Log("Collision enabled");
			player.transform.position = this.gameObject.transform.Find("Base").gameObject.transform.position;
			player.GetComponent<PlayerLife>().decreaseLives();
		} else {
			Debug.Log("Collision disabled");
		}

		player.GetComponent<PlayerMovement>().setDisabled(true, 0.2f);

		this.GetComponent<AudioSource>().clip = player.GetComponent<PlayerTones>().ouch;
		this.GetComponent<AudioSource>().Play();
	}

	void OnCollisionStay(Collision collider) {
		Debug.Log("OnCollisionEnter");

		GameObject player = collider.gameObject;

		if (this.collisionEnabled) {
		} else {
			player.GetComponent<PlayerMovement>().setDisabled(true, 0.5f);
		}
	}

}
