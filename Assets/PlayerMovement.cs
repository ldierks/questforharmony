using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float timeDisabled;
	public bool disabled = false;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {

		if (this.disabled) {
			if (this.timer == 0.0f) {
				this.timer = Time.time;
			}
			if (Time.time - this.timer > timeDisabled) {
				this.disabled = false;
				this.timer = 0.0f;
			}
		} else {

			if (Input.GetAxis("Vertical") > 0) {
				Debug.Log("Key up");
			} else if (Input.GetAxis("Vertical") < 0) {
				Debug.Log("Key down");
			}

			this.GetComponent<Rigidbody>().AddForce(new Vector3(speed * Input.GetAxis("Horizontal"),0,0));
			if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1) {
				this.gameObject.GetComponent<Animator>().SetBool("Walk", true);
			} else {
				this.gameObject.GetComponent<Animator>().SetBool("Walk", false);
			}
		}
	}
}
