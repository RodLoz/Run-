using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : MonoBehaviour {

	public static ViewGameOver sharedInstance;

	public Text blueGemsScore; 
	public Text greenGemsScore;
	public Text maxScore;

	void Awake(){
		sharedInstance = this;
	}

		

	public void UpdateUI(){
		if (GameManager.sharedInstance.currentGameState == GameState.GameOver) {
			blueGemsScore.text = GameManager.sharedInstance.collectedCoinBlue.ToString ();
			greenGemsScore.text = GameManager.sharedInstance.collectedCoinGreen.ToString ();
		}
	}
}
