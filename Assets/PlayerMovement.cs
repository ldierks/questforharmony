using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {



		if (Input.GetAxis("Vertical") > 0) {
			print("vertical > 0");
		} else if (Input.GetAxis("Vertical") < 0) {
			print("vertical < 0");
		}

			this.GetComponent<Rigidbody>().AddForce(new Vector3(speed * Input.GetAxis("Horizontal"),0,0));
	}
}
