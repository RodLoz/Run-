using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {


	public Slider healthBar;

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player" && healthBar.value <= 90) {
			healthBar.value += 30 ;
			Destroy (gameObject);

		}
	}


}

