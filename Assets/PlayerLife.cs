using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

	public int lifes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void decreaseLives() {
		this.lifes -= 1;
		Debug.Log(this.lifes + " life points left");

		if (this.lifes <= 0) {
			Debug.Log("Game Over");
		}
	}

	public void increaseLives() {
		this.lifes += 1;
		Debug.Log(this.lifes + " life points left");
	}
}
