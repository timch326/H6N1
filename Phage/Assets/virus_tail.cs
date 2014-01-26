using UnityEngine;
using System.Collections;

public class virus_tail : MonoBehaviour {
	
	
	// used for testing bounce
	
	public float  x_force = 0f;
	public float  y_force = 1000f;
	
	public float fadeValue = 125;
	public float currentTime = 0;
	public float timeItTakesToFade = 1;
	public bool isFading  = false;
	
	
	void Start () {
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Cell")
		{
			collision.gameObject.GetComponent<CellBehaviour>().infectCell();
			transform.parent.gameObject.GetComponent<virus_behaviour>().virusFade();
		}
	}
}









