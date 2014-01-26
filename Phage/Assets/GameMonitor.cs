using UnityEngine;
using System.Collections;

public class GameMonitor : MonoBehaviour {

	public int cellCount = 0;
	public int virusCount = 0;
	public int infectedCellCount = 0;
	public int cellCountLimit = 25;
	private static GameMonitor instance;

	
	// Use this for initialization
	void Awake () {
		instance = this;
		cellCount = 0;
		infectedCellCount = 0;
		virusCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (cellCount <= 0) {
			Debug.Log ("Game Over");
			Application.LoadLevel ("test_level_select_ck");
		}

		if (virusCount <= 0 && infectedCellCount <= 0) {
			Debug.Log ("You Win!");
			Application.LoadLevel ("test_level_select_ck");
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

}
