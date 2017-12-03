using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameScore : MonoBehaviour {

	public int maxFailures;
	private int currentFailures = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	 * Returns true if the number of maximal failures is not reached yet
	 */
	public bool increaseFailures() {
		this.currentFailures += 1;
		return this.currentFailures <= this.maxFailures;
	}


}
