using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResponse : StateMachineBehaviour {

	public int correctKey;

	private float startTime;
	private float waitingTime;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.startTime = Time.time;
		this.waitingTime = 10;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (Input.GetAxis("Vertical") > 0) {
			animator.gameObject.GetComponent<AudioSource>().clip = GameObject.Find("Player").GetComponent<PlayerKeytones>().keytones[0];
			animator.gameObject.GetComponent<AudioSource>().Play();
		} else if (Input.GetAxis("Vertical") < 0) {
			animator.gameObject.GetComponent<AudioSource>().clip = GameObject.Find("Player").GetComponent<PlayerKeytones>().keytones[2];
			animator.gameObject.GetComponent<AudioSource>().Play();
		} else if (Input.GetAxis("Horizontal") > 0) {
			animator.gameObject.GetComponent<AudioSource>().clip = GameObject.Find("Player").GetComponent<PlayerKeytones>().keytones[1];
			animator.gameObject.GetComponent<AudioSource>().Play();
		} else if (Input.GetAxis("Horizontal") < 0) {
			animator.gameObject.GetComponent<AudioSource>().clip = GameObject.Find("Player").GetComponent<PlayerKeytones>().keytones[3];
			animator.gameObject.GetComponent<AudioSource>().Play();
		}
			

		if (Time.time - this.startTime >= this.waitingTime) {
			animator.SetBool("Timeout", true);
		} else if (	(Input.GetAxis("Vertical") > 0 && this.correctKey == 0)   ||
			(Input.GetAxis("Horizontal") > 0 && this.correctKey == 1) ||
			(Input.GetAxis("Vertical") < 0 && this.correctKey == 2)	  ||
			(Input.GetAxis("Horizontal") < 0 && this.correctKey == 3)) {
			animator.SetBool("Correct", true);
		} else if (	(Input.GetAxis("Vertical") > 0 && this.correctKey != 0)   ||
			(Input.GetAxis("Horizontal") > 0 && this.correctKey != 1) ||
			(Input.GetAxis("Vertical") < 0 && this.correctKey != 2)	  ||
			(Input.GetAxis("Horizontal") < 0 && this.correctKey != 3)) {

			animator.gameObject.GetComponent<MiniGameScore>().increaseFailures();
			animator.SetBool("Incorrect", true);
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool("Timeout", false);
		animator.SetBool("Correct", false);
		animator.SetBool("Incorrect", false);

	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
