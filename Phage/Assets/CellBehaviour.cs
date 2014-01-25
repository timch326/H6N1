using UnityEngine;
using System.Collections;

public class CellBehaviour : MonoBehaviour {

	static public bool isInitialState = true;

	// Use this for initialization
	void Start () {
		startGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Destroy overlapping cells 
	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.CompareTag ("Cell")) {
						Debug.Log ("Collision!", coll.gameObject);
						Destroy (gameObject);
				}
	}

}
