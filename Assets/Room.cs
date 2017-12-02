using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Room : MonoBehaviour {

	public AudioClip backgroundSound;
	public new AudioSource audio;
	public float maxBackgrVolume;
	public float fadeInOutSpeed;

	bool fadein = false;
	bool fadeout = false;
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
			this.audio.volume = Mathf.Min(this.audio.volume + this.fadeInOutSpeed, maxBackgrVolume);
		}
		if (this.fadein == true && this.audio.volume == maxBackgrVolume) {
			this.fadein = false;
		}

		if (this.fadeout) {
			this.audio.volume = Mathf.Max(this.audio.volume - this.fadeInOutSpeed, 0.0f);
		}
		if (this.fadeout == true && this.audio.volume == 0.0f) {
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

		this.fadein = false;
		this.fadeout = true;
	}


	void PlaySound() {

		audio.Play();
	}

}
