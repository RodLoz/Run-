using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour {


	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity;
	public float smoothing;

	GameObject character;

	// Use this for initialization
	void Start () {
		character = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.sharedInstance.currentGameState == GameState.InTheGame){	
		Vector2 mD = new Vector2 (Input.GetAxisRaw ("Mouse X"),
			                      Input.GetAxisRaw ("Mouse Y"));

		mD = Vector2.Scale (mD, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));

		smoothV.x = Mathf.Lerp (smoothV.x, mD.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, mD.y, 1f / smoothing);
		mouseLook += smoothV;

		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);
	}
}
}