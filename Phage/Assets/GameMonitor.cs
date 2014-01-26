using UnityEngine;
using System.Collections;

public class GameMonitor : MonoBehaviour {

	public int cellCount = 0;
	public int virusCount = 0;
	public int infectedCellCount = 0;
	public int cellCountLimit = 25;
	private static GameMonitor instance;
	private bool gameEnded = false;
	
	// Use this for initialization
	void Awake () {
		instance = this;
		gameEnded = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0) && gameEnded) {
			Application.LoadLevel ("test_level_select_ck");

		}
		if (gameEnded) return;

		if (cellCount <= 0) {
			loseGame ();
		}
		if (virusCount <= 0 && infectedCellCount <= 0) {
			winGame ();
		}
	}

	public bool HasReachedCellLimit() {
		if (cellCount >= cellCountLimit) 
			Debug.Log ("Limit Reached!");
		return cellCount >= cellCountLimit;
	}

	public static GameMonitor getInstance() {
		if (instance == null) {
			GameMonitor.instance = new GameMonitor();
		}
		return instance;
	}

	
	public void winGame ()
	{
		Debug.Log ("You Win!");
		GameObject winMessage = GameObject.FindGameObjectWithTag ("Win");
		winMessage.GetComponent<SpriteRenderer> ().enabled = true;
		gameEnded = true;
		endGameCleanUp ();
	}

	public void loseGame ()
	{
		Debug.Log ("Game Over");
		GameObject lossMessage = GameObject.FindGameObjectWithTag ("Loss");
		lossMessage.GetComponent<SpriteRenderer> ().enabled = true;
		gameEnded = true;
		endGameCleanUp ();
	}

	private void endGameCleanUp() {
		cellCount = 0;
		infectedCellCount = 0;
		virusCount = 0;
	}
}
