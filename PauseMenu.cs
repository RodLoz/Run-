using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour {


	public Transform canvas;
	private CamaraMovement camera;


	public void Start(){
		camera = GameObject.Find ("Main Camera").GetComponent<CamaraMovement> ();
	}

	public void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
				Pause ();


	   }
	}

	public void Pause(){
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			camera.enabled = false;
		} else {
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			camera.enabled = true;
		}
	}

	public void Quit(){
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
