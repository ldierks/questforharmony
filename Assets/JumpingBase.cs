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

		if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0) {
			collider.gameObject.transform.position = this.gameObject.transform.Find("JumpingGoal").gameObject.transform.position;

			this.gameObject.GetComponentInParent<BarrierCollision>().collisionEnabled = false;
		}
	}

}
