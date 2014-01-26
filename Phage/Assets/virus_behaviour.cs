using UnityEngine;
using System.Collections;

public class virus_behaviour : MonoBehaviour {





	public float fadeValue = 125;
	public float currentTime = 0;
	public float timeItTakesToFade = 1f;
	public bool isFading  = false;
	public float fadeTime = 1f;
	public bool stop_rotation = false;

	float random_rotate_z;
	int random_reset_threshold;
	int threshold = 100;
	float random_min = -1.0f;
	float random_max = 1.0f;
	// Use this for initialization
	void Awake () {

				random_rotate_z = Random.Range(random_min, random_max);
				random_reset_threshold = threshold;
	}
	



	
	void Update() {

		if (!stop_rotation) {

						transform.Rotate (0f, 0.0f, random_rotate_z);  // does nothing, just a bad guess
				}


		if (isFading) {
			
						currentTime += Time.deltaTime;
			
			
			
						if (currentTime / timeItTakesToFade <= timeItTakesToFade) {
								fadeValue = 1 - (currentTime / timeItTakesToFade);
								renderer.material.color = new Color (1, 1, 1, fadeValue);
						} else {
								transform.Rotate(0f, 0.0f, 0f); 
								isFading = false;
								Destroy (this.gameObject.transform.parent.gameObject);
						}
			
			
			
			
				} 
	}
	
	
	public void virusFade() {

		isFading = true;
		stop_rotation = true;
		transform.parent.rigidbody2D.velocity = new Vector2 (0,0);
		if (transform.collider2D.enabled) {
			transform.collider2D.enabled = false;
		}
	}

}
