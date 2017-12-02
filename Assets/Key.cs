using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {
	public float inhibTime = 1;
	public float currInhibTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currInhibTime > 0) {
			currInhibTime -= Time.deltaTime;
		}
		else {
			currInhibTime = inhibTime;
			if(Input.GetAxis("Horizontal") > 0.2) {
				gameObject.GetComponent<Button>().onClick.Invoke();
			}
		}
	}
}
