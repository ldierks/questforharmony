using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : StateMachineBehaviour {

	public AudioClip clip;
	private float startTime;
	private float clipLength;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameObject.Find("Player").GetComponent<PlayerMovement>().setDisabled(true, 0);
		GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
		animator.gameObject.GetComponent<AudioSource>().clip = this.clip;
		this.clipLength = clip.length;
		animator.gameObject.GetComponent<AudioSource>().Play();
		this.startTime = Time.time;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (Time.time - this.startTime >= this.clipLength) {
			animator.SetBool("ClipFinished", true);
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
		animator.SetBool("ClipFinished", false);
		animator.SetBool("RoomEntered", false);
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
