using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KillTrigger : MonoBehaviour {

	public static KillTrigger sharedInstance;
	public Slider slider;

	void Awake(){
		sharedInstance = this;
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			slider.value -= 30;
		}
	
		if (slider.value <= 0) {
			PlayerController.sharedInstance.KillPlayer ();

			}

			
	}


}
	
