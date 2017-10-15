using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGreen : MonoBehaviour {

	bool isCollected = false;

	void ShowCoin() {
		this.GetComponent<SpriteRenderer>().enabled = true;
		this.GetComponent<BoxCollider> ().enabled = true;
		isCollected = false;
	}


	void HideCoin () {
		this.GetComponent<MeshRenderer>().enabled = false;
		this.GetComponent<BoxCollider> ().enabled = false;

	}

	void CollectCoin () {
		isCollected = true;
		HideCoin ();

		GameManager.sharedInstance.CollectCoinGreen ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			CollectCoin ();

		}

	}
}