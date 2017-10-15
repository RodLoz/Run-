using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour {

	public static ViewInGame sharedInstanced;

	public Text blueGemsScore; 
	public Text greenGemsScore;
	public Text maxScore;

	void Awake(){
	
		sharedInstanced = this;
	}

	public void UpdateCoinsLabel(){
		if (GameManager.sharedInstance.currentGameState == GameState.InTheGame) {

			blueGemsScore.text = GameManager.sharedInstance.collectedCoinBlue.ToString ();
			greenGemsScore.text = GameManager.sharedInstance.collectedCoinGreen.ToString ();
		}
	}

		public void UpdateHighScoreLabel(){
		if (GameManager.sharedInstance.currentGameState == GameState.InTheGame) {
			maxScore.text = PlayerPrefs.GetInt ("highScore", 0).ToString ();
		}
	}
		
		
	}
  

