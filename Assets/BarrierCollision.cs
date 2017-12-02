using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCollision : MonoBehaviour {

	public bool collisionEnabled;

	// Use this for initialization
	void Start () {
		this.collisionEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collider) {
		Debug.Log("OnCollisionEnter");

		GameObject player = collider.gameObject;

		if (this.collisionEnabled) {
			Debug.Log("Collision enabled");
			player.transform.position = this.gameObject.transform.Find("JumpingBase").gameObject.transform.position;
			player.GetComponent<PlayerMovement>().setDisabled(true);
			//player.GetComponent<PlayerMovement>().disabled = true;
			player.GetComponent<PlayerLife>().decreaseLives();
		} else {
			Debug.Log("Collision disabled");
			player.GetComponent<PlayerMovement>().setDisabled(true,0.5f);
		}
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
