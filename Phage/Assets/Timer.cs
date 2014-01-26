using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization

	void Awake() {
		gameObject.renderer.sortingLayerName = "Text";

	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateTimerText(string t) {


		GetComponent<TextMesh>().text = t;

		}
}
