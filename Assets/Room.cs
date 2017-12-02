using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Room : MonoBehaviour {

	public AudioClip backgroundSound;
	public new AudioSource audio;

	bool fadein = false;
	bool fadeout = false;
	public float fadeInOutSpeed;
	//public bool preloadAudioData;

	// Use this for initialization
	void Start () {
		this.audio = this.gameObject.GetComponent<AudioSource>();
		this.audio.clip = this.backgroundSound;
		this.audio.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.fadein) {
			Debug.Log("Increase volume");
			this.audio.volume = Mathf.Min(this.audio.volume + this.fadeInOutSpeed, 1.0f);
		}
		if (this.fadein == true && this.audio.volume == 1.0f) {
			Debug.Log("fadein stop");
			this.fadein = false;
		}

		if (this.fadeout) {
			this.audio.volume = Mathf.Max(this.audio.volume - this.fadeInOutSpeed, 0.0f);
			Debug.Log("Decrease stop");
		}
		if (this.fadeout == true && this.audio.volume == 0.0f) {
			Debug.Log("fadeout stop");
			this.fadeout = false;
			this.audio.Stop();
		}
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log("Enter " + this.gameObject.name + " " + collider.name);

		this.PlaySound();
		this.fadeout = false;
		this.fadein = true;
	}

	void OnTriggerExit(Collider collider) {
		Debug.Log("Exit " + this.gameObject.name + " " + collider.name);

		this.fadein = false;
		this.fadeout = true;
	}


	void PlaySound() {
		Debug.Log("Play sound");

		audio.Play();
	}

}
