using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melody : StateMachineBehaviour {

	public AudioClip[] audioclips;

	private float clipLength;
	private float startTime;
	private int currentClip = 0;
	private float maxClipLength = 0.5f;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.gameObject.GetComponent<AudioSource>().clip = this.audioclips[currentClip];
		this.clipLength = this.audioclips[currentClip].length;
		animator.gameObject.GetComponent<AudioSource>().Play();
		this.startTime = Time.time;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		if (Time.time - this.startTime >= this.maxClipLength) {
			if (currentClip < this.audioclips.Length - 1) {
				currentClip += 1;
				animator.gameObject.GetComponent<AudioSource>().clip = this.audioclips[currentClip];
				this.clipLength = this.audioclips[currentClip].length;
				animator.gameObject.GetComponent<AudioSource>().Play();
				this.startTime = Time.time;
			} else {
				animator.SetBool("ClipFinished", true);
			}
		}

//		if (Time.time - this.startTime >= this.clipLength) {
//			if (currentClip < this.audioclips.Length - 1) {
//				currentClip += 1;
//				animator.gameObject.GetComponent<AudioSource>().clip = this.audioclips[currentClip];
//				this.clipLength = this.audioclips[currentClip].length;
//				animator.gameObject.GetComponent<AudioSource>().Play();
//				this.startTime = Time.time;
//			} else {
//				animator.SetBool("ClipFinished", true);
//			}
//		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool("ClipFinished", false);
		animator.SetBool("RoomEntered", false);
		this.currentClip = 0;
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
