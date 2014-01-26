using UnityEngine;
using System.Collections;

public class CountDownTimer : MonoBehaviour {

	// Use this for initialization
	public int level_time = 25;// 25 seconds
	public float elasped_time = 0;
	private GameMonitor monitor;

	void Awake() {
		monitor = GameMonitor.getInstance ();
		gameObject.renderer.sortingLayerName = "Text";
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elasped_time += Time.deltaTime;
		UpdateTimerText (Mathf.RoundToInt(level_time-elasped_time) + " sec");
		if (elasped_time >= level_time) {
			Debug.Log("elasped time " + elasped_time);
			monitor.loseGame();
		}
	
	}

	public void UpdateTimerText(string t) {


		GetComponent<TextMesh>().text = t;

		}
}
