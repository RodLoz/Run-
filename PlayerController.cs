using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public static PlayerController sharedInstance;


	public float speed;
	public float jumpForce;
	public Transform groundCheck;
	public LayerMask layer;

	private Vector3 startPosition;
	private string highScoreKey = "highScore";


	void Awake(){
		sharedInstance = this;
		startPosition = this.transform.position;

	}

	public void StartGame () {
		this.transform.position = startPosition;

	}
	


	public void Update () {	

	if (GameManager.sharedInstance.currentGameState == GameState.InTheGame){

	float forward = Input.GetAxis ("Vertical") * speed;
	float sides = Input.GetAxis ("Horizontal") * speed;

	transform.Translate (sides, 0, forward);


	if (Physics.Linecast (transform.position, groundCheck.position, layer)) {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody> ().AddForce (0, jumpForce, 0);
		}

								
		if (Input.GetKeyDown ("escape")) {			
			Cursor.lockState = CursorLockMode.None;
		}
		if (Input.GetKeyDown ("mouse 0") && !EventSystem.current.IsPointerOverGameObject(-1)) {			
			Cursor.lockState = CursorLockMode.Locked;
		}	
				}

	}
}

	void OnTriggerEnter (Collider Other){
		if (GameManager.sharedInstance.currentGameState == GameState.InTheGame){
			if (Other.gameObject.name == "SavePoint") {
				GameObject.Find ("ManagerSAL").GetComponent<SaveAndLoadGame> ().Save ();

			}
		}
	}


	public void KillPlayer (){
		GameManager.sharedInstance.GameOver();
		if (PlayerPrefs.GetInt(highScoreKey , 0) < GameManager.sharedInstance.MaxScore()){
			PlayerPrefs.SetInt(highScoreKey, GameManager.sharedInstance.MaxScore());
	
		}
	}


}


