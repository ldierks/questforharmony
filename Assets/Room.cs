using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Room : MonoBehaviour {

	public AudioClip backgroundSound;
	//public bool preloadAudioData;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log("Enter " + this.gameObject.name + " " + collider.name);

		this.gameObject.GetComponent<AudioSource>().clip = this.backgroundSound;
	}

	void OnTriggerExit(Collider collider) {
		Debug.Log("Exit " + this.gameObject.name + " " + collider.name);
	}


	IEnumerator PlaySound() {
		Debug.Log("Play sound");

		AudioSource audio = GetComponent<AudioSource>();

		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		audio.clip = this.backgroundSound;
		audio.Play();
	}

}
