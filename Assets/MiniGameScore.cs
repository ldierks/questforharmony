using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameScore : MonoBehaviour {

	public int maxFailures;
	public float gameLength;

	private int currentFailures = 0;
	private float startTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	 * Returns true if the number of maximal failures is not reached yet
	 */
	public void increaseFailures() {
		this.currentFailures += 1;
	}

	public bool gameOver() {
		return this.currentFailures <= this.maxFailures;
	}

	public void startTimer() {
		this.startTime = Time.time;
	}

	public bool getTimeIsUp() {
		return Time.time - this.startTime >= this.gameLength;
	}

}
