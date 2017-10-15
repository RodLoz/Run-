using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSave : MonoBehaviour {


	

	void OnTriggerEnter (Collider Other) {

		if (Other.gameObject.name == "Player") {
			Destroy (gameObject);
		}
		
	}
}
