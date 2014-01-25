using UnityEngine;
using System.Collections;

public class Initialize : MonoBehaviour {

	public GameObject Cell;

	// Use this for initialization
	void Start () {
		ArrayList clones = new ArrayList();
		
		for (int i = 0; i < 10; i++) {
			GameObject clone;//a clone of the bullet
			int x = Random.Range(-1,1);
			int y = Random.Range(-1,1);
			Vector2 clonePosition = new Vector2 (transform.localPosition.x + x, transform.localPosition.y + y);
			clone = Instantiate(Cell, clonePosition, transform.rotation) as GameObject;
			clones.Add(clone);
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
