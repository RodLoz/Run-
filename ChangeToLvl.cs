using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToLvl : MonoBehaviour {

	public Transform pointPlayer;

	void OnTriggerEnter(Collider Other){
		if (Other.tag == "Player") {
			GameObject.Find ("Player").transform.position = new Vector3 (pointPlayer.position.x, pointPlayer.position.y, pointPlayer.position.z);
		}
	
	}

}
