using UnityEngine;
using System.Collections;

public class CellBehaviour : MonoBehaviour {

	public GameObject spawn;

	static public bool isInitialState = true;
	public GameObject Virus;
	public int VirusCount = 1;
	public float circularSpreadValue = 0.1f;
	public float virusExplosionSpeed = 1000;
	public float CellDuplicationInterval = 10; //seconds
	float VirusAttachTimeLimit ; //seconds
	public int life = 1;

	private float TimeElapsed = 0;
	private float CellDuplicationTime;

	private bool hasVirus = false;
	private Animator anim;

	float random_min = -1.0f;
	float random_max = 1.0f;
	int duplicateLimit = 3;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		float random_rotate_z = Random.Range(random_min, random_max);
		transform.Rotate(0f, 0.0f, random_rotate_z);

		VirusAttachTimeLimit = Random.Range (5,8);
	}

	void Start () {
		//startGame ();

	}
	
	// Update is called once per frame
	void Update() {
		jitter ();
		if (hasVirus) {
			TimeElapsed += Time.deltaTime;

			if (VirusAttachTimeLimit <= TimeElapsed) {
				uninfectCell();
				Debug.Log ("Hello Time Elapsed!", this);
				TimeElapsed = 0;
			}
		}

		CellDuplicationTime += Time.deltaTime;
		if (CellDuplicationInterval <= CellDuplicationTime) {
			duplicate(--life);
		}
	}



	void OnMouseDown() {
		if (hasVirus) {
			killCell ();
			Debug.Log ("RIP");
		} else {
			Debug.Log ("I'm Healthy!");
		}
	}

	void killCell() {
		Destroy (gameObject);

	
		// Time Elapsed is portionally to the virusattachtimelimit 
		//

		for (int i = 0; i < (TimeElapsed*2); i++) {
				GameObject clone;//a clone of the virus
				Vector2 cellPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y);
	
			float angle = i * 360 / TimeElapsed;
				Vector2 virusPosition = cellPosition + circularSpreadValue * new Vector2 (Mathf.Cos (angle * Mathf.Deg2Rad),
	                                                                         Mathf.Sin (angle * Mathf.Deg2Rad));
				//GameObject virusCollider = coll.gameObject;
				//Vector2 virusColliderDirection = virusCollider.rigidbody2D.velocity;
	
				// make new clone and change its facing diunirection
				//Quaternion rotation = Quaternion.Euler(CloneRotationVector);
				clone = Instantiate (Virus, virusPosition, Quaternion.identity) as GameObject;
				virus_bounce newVirusObject = clone.GetComponent<virus_bounce> ();
		
				newVirusObject.GoInDirection (angle, virusExplosionSpeed);
			}
		}
		
	public void infectCell() {
		if (hasVirus)
			return;
		hasVirus = true;
		anim.SetTrigger ("toInfected");
		Debug.Log ("Infect Cell");
		// Set the sprite from "healthy" to "infected"
	}

	public void uninfectCell() {
		hasVirus = false;
		anim.SetTrigger ("toHealthy");
		Debug.Log ("Uninfect Cell");
		// Set the sprite from "infected" to "healthy"

	}

	private void jitter() {
		float dx = Random.Range(-10, 10);
		float dy = Random.Range(-10, 10);
		float d = 10;

		// if the cell collides with a wall we bounce the cell off the wall 
		transform.Translate ((dx / d), (dy / d), 0); 
	}

	void duplicate(int life){
		if (life >= 0) {
			Vector3 temp_spawn_location =  transform.position; 
			temp_spawn_location.x += 1;
			Vector3 spawn_location = temp_spawn_location;

			GameObject temp_spawn_cell = (GameObject)Instantiate (spawn, spawn_location, transform.rotation);
		}
	}
}