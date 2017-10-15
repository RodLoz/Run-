using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour {

	public static EnemyFollow sharedInstance;

	public Transform player;
	static Animator anim;

	void Awake(){
		sharedInstance = this;		
	}
	void Start () {
		
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
		if (GameManager.sharedInstance.currentGameState == GameState.InTheGame) {
			if (Vector3.Distance (player.position, this.transform.position) < 10) {
				Vector3 direction = player.position - this.transform.position;
				direction.y = 0;
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);

				anim.SetBool ("isIdle", false);
				if (direction.magnitude > 1) {
					this.transform.Translate (0, 0, 0.01f);
					anim.SetBool ("isWalking", true);
					anim.SetBool ("isAttacking", false);
				} else {
					anim.SetBool ("isWalking", false);
					anim.SetBool ("isAttacking", true);
				}
			}else{
				anim.SetBool ("isIdle", true);
				anim.SetBool ("isWalking", false);
				anim.SetBool ("isAttacking", false);
	}


}
}
}