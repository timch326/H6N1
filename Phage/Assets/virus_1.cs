using UnityEngine;
using System.Collections;

public class virus_1 : MonoBehaviour {

	float random_rotate_z;
	int random_reset_threshold;
	int threshold = 100;
	float random_min = -2.0f;
	float random_max = 2.0f;
	// Use this for initialization
	void Start () {
	
		random_rotate_z = Random.Range(random_min, random_max);
		random_reset_threshold = threshold;
	}
	
	// Update is called once per frame
	void Update () {

			transform.Rotate(0f, 0.0f, random_rotate_z);  // does nothing, just a bad guess
			
			if (random_reset_threshold < 0) {
				random_reset_threshold = threshold;
				random_rotate_z = Random.Range(random_min, random_max);
			} else {
				random_reset_threshold--;	
			}

	}
}
