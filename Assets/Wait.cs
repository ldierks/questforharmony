using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : StateMachineBehaviour {

	private float startTime;
	private float waitingTime;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.startTime = Time.time;
		this.waitingTime = 8;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (Time.time - this.startTime >= this.waitingTime) {
			animator.SetBool("Timeout", true);
		} else if (Input.GetAxis("Vertical") > 0) {
			animator.SetBool("Yes", true);
		} else if (Input.GetAxis("Vertical") < 0) {
			animator.SetBool("No", true);
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool("Timeout", false);
		animator.SetBool("Yes", false);
		animator.SetBool("No", false);

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
