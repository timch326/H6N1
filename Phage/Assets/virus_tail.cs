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
			transform.parent.gameObject.GetComponent<virus_behaviour>().virusFade();
			collision.gameObject.GetComponent<CellBehaviour>().infectCell();
		}
	}

	/*
	void Update() {
		if(isFading){
			
			currentTime += Time.deltaTime;
			
			
			
			if(currentTime/ timeItTakesToFade <= timeItTakesToFade){
				fadeValue = 1 - (currentTime / timeItTakesToFade);
				renderer.material.color = new Color(1,1,1, fadeValue);
			}else{
				isFading = false;
				Destroy(transform.parent.gameObject.transform.parent.gameObject);
			}
			
			
			
			
		}
		
	}
	
	
	void StartFade(float howLong  ) {
		currentTime = 0;
		timeItTakesToFade = howLong;
		isFading = true;
	}

*/
}









