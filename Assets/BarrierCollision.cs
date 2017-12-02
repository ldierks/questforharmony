using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCollision : MonoBehaviour {

	public bool enabled;

	// Use this for initialization
	void Start () {
		this.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collider) {
		Debug.Log("OnCollisionEnter");

		if (this.enabled) {
			Debug.Log("Collision enabled");
			collider.gameObject.transform.position = this.gameObject.transform.Find("JumpingBase").gameObject.transform.position;
			collider.gameObject.GetComponent<PlayerMovement>().disabled = true;
		}
	}
}
