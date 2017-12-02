using UnityEngine;
using System.Collections;

public class RoomEvent : MonoBehaviour
{

	public AudioClip backgroundSound;
	public new AudioSource audio;

	bool fadein = false;
	bool fadeout = false;
	public float fadeInOutSpeed;
	bool eventEnabled;
	//public bool preloadAudioData;

	// Use this for initialization
	void Start () {
		this.audio = this.gameObject.GetComponent<AudioSource>();
		this.audio.clip = this.backgroundSound;
		this.audio.volume = 0;
		this.eventEnabled = true;
	}

	// Update is called once per frame
	void Update () {
		//if (this.eventEnabled) {
			if (this.fadein) {
				this.audio.volume = Mathf.Min(this.audio.volume + this.fadeInOutSpeed, 1.0f);
			}
			if (this.fadein == true && this.audio.volume == 1.0f) {
				this.fadein = false;
			}

			if (this.fadeout) {
				this.audio.volume = Mathf.Max(this.audio.volume - this.fadeInOutSpeed, 0.0f);
			}
			if (this.fadeout == true && this.audio.volume == 0.0f) {
				this.fadeout = false;
				this.audio.Stop();
			}
		//}
	}

	void OnTriggerEnter(Collider collider) {
		if (this.eventEnabled) {
			Debug.Log("Enter " + this.gameObject.name + " " + collider.name);

			//this.PlaySound();
			this.fadeout = false;
			this.fadein = true;
			this.eventEnabled = false;
			//collider.GetComponent<PlayerMovement>().setDisabled(true, this.audio.clip.length + 0.5f);
			this.gameObject.GetComponent<Animator>().SetTrigger("RoomEntered");
			Debug.Log(this.gameObject.GetComponent<Animator>().name);
		}
	}

	void OnTriggerExit(Collider collider) {

		this.fadein = false;
		this.fadeout = true;
	}


	void PlaySound() {
		audio.Play();
	}

}
