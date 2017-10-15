using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameState
{
    Menu,
    InTheGame,
    GameOver

}



public class GameManager : MonoBehaviour {
	
	public static GameManager sharedInstance;

    public GameState currentGameState = GameState.Menu;

	public Canvas menuCanvas;
	public Canvas gameCanvas;
	public Canvas gameOverCanvas;
	public Slider healthBar;

	public int collectedCoinGreen = 0;
	public int collectedCoinBlue = 0;



	void Awake (){
		sharedInstance = this;
	
	}

    void Start()    {
		currentGameState = GameState.Menu;
		menuCanvas.enabled = true;
		gameCanvas.enabled = false;
		gameOverCanvas.enabled = false;
    }

	void Update(){

	}

    public void StartGame() {
		PlayerController.sharedInstance.StartGame();
		ChangeGameState (GameState.InTheGame);
		ViewInGame.sharedInstanced.UpdateHighScoreLabel ();
		healthBar.value = 100;

	}
    
    public void GameOver()  {
        ChangeGameState(GameState.GameOver);
		ViewGameOver.sharedInstance.UpdateUI ();

    }

    public void BackToMainMenu()  {
	    ChangeGameState(GameState.Menu);
		healthBar.value = 100;

    }	

	public void LoadGame(){
		ChangeGameState (GameState.InTheGame);
		GameObject.Find ("ManagerSAL").GetComponent<SaveAndLoadGame> ().Load ();
	
	}

    void ChangeGameState(GameState newGameState)  {

		if (newGameState == GameState.Menu) {
			menuCanvas.enabled = true;
			gameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
		} else if (newGameState == GameState.InTheGame) {
			Cursor.lockState = CursorLockMode.Locked;
			menuCanvas.enabled = false;
			gameCanvas.enabled = true;
			gameOverCanvas.enabled = false;	
		} else if (newGameState == GameState.GameOver) {
			Cursor.lockState = CursorLockMode.None;
			menuCanvas.enabled = false;
			gameCanvas.enabled = false;
			gameOverCanvas.enabled = true;
		} 



		currentGameState = newGameState;
    }


	public void CollectCoinBlue(){
		collectedCoinBlue = collectedCoinBlue + 100;
		ViewInGame.sharedInstanced.UpdateCoinsLabel (); 
}
	public void CollectCoinGreen(){
		collectedCoinGreen = collectedCoinGreen + 40;
		ViewInGame.sharedInstanced.UpdateCoinsLabel (); 
	}

	public int MaxScore(){
		int maxScore = collectedCoinGreen + collectedCoinBlue;
		return maxScore;
	}
}