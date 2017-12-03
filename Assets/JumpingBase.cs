using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider collider) {
		Debug.Log("OnTriggerStay");
		 
		if ((Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0 && this.gameObject.GetComponentInParent<BarrierCollision>().jump) ||
			(Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") > 0 && !this.gameObject.GetComponentInParent<BarrierCollision>().jump)) {
			collider.gameObject.transform.position = this.gameObject.transform.Find("Goal").gameObject.transform.position;

			this.gameObject.GetComponentInParent<BarrierCollision>().collisionEnabled = false;
			this.gameObject.GetComponent<AudioSource>().Play();

		}
	}

}
