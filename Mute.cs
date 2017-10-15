using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {


	public Toggle check;
	public Toggle check2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<AudioSource> ().mute = check.isOn;
		GetComponent<AudioSource> ().mute = check2.isOn;
	}
}
