using UnityEngine;
using System.Collections;

public class GameMonitor : MonoBehaviour {

	static public int cellCount = 0;
	static public int cellCountLimit = 12;
	
	// Use this for initialization
	void Awake () {
		Debug.Log ("Count is currently : " + cellCount);
		cellCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (cellCount <= 0) {
			Debug.Log ("Game Over");
			Application.LoadLevel ("test_level_select_ck");
		}
	}

	static public bool HasReachedCellLimit() {
		return cellCount >= cellCountLimit;
	}

}
