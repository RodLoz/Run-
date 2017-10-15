using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadGame : MonoBehaviour {
	

	public void Load(){
			
			GameObject.Find ("ManagerSAL").GetComponent<SaveAndLoadGame> ().Load ();
		GameManager.sharedInstance.gameCanvas.enabled = true;
		    		}
	}


	