using UnityEngine;
using System.Collections;

public class cell : MonoBehaviour {

	float x1 = -30.00f;
	float x2 = 30.00f;
	float y1 = -16f;
	float y2 = 16f ; 
	float random_rotate_z;
	int random_reset_threshold;
	float random_min = -2.0f;
	float random_max = 3.0f;
	int threshold = 100;

	public GameObject spawn;


	Vector3 spawn_location;
	int num_spawn  = 0;
	int num_life; 
	float timer = 0f; 


	public float smooth = 2.0F;
	public float tiltAngle = 30.0F;
	// Use this for initialization
	void Start () {
		
		random_rotate_z = Random.Range(random_min, random_max);
		random_reset_threshold = threshold;
		Vector3 temp_spawn_location =  transform.position; 
		temp_spawn_location.x += 1;
		spawn_location = temp_spawn_location;
		num_life = 3; 


	}
	
	// Update is called once per frame
	void Update () {
		timer ++; 

		if (timer > 500) {
			num_life-- ;
			duplicate(num_life);
			timer = 0.0f;

		}
//		float rand = Random.Range (-100, 100);
//		if (rand > 97) {
//			num_life-- ;
//			duplicate(num_life);
//			 
//		}

		float dx = Random.Range(-10, 10);
		float dy = Random.Range(-10, 10);
		float d = 2000f;
		//transform.Translate (Vector2.right * Input.GetAxis("Horizontal"));
	
		// if the cell collides with a wall we bounce the cell off the wall 
		if(transform.position.x < x1  || transform.position.x > x2  ){
			transform.Translate(0,(dy/d),0); 
		}
		else if( transform.position.y < y1 || transform.position.y > y2 ) {
			transform.Translate((dx/d),0,0); 
		}else{
			transform.Translate((dx/d),(dy/d),0); 
		}

	
		transform.Rotate(0 , 0.0f, 1);

		//transform.rotation(Vector3.zero, Vector3.zero ,1);  // does nothing, just a bad guess
		
		if (random_reset_threshold < 0) {
			random_reset_threshold = threshold;
			random_rotate_z = - Random.Range(random_min, random_max);
		} else {
			random_reset_threshold--;	
		}
	}


	void duplicate(int life){
		if (life >= 0) {
			GameObject temp_spawn_cell = (GameObject)Instantiate (spawn, spawn_location, transform.rotation);
		}

	}
}
