using UnityEngine;
using System.Collections;

public class CellBehaviour : MonoBehaviour {
	
	public GameObject spawn;
	
	static public bool isInitialState = true;
	public GameObject Virus;
	int VirusCount = 1;
	public float circularSpreadValue = 0.1f;
	public float virusExplosionSpeed = 1000;
	public float CellDuplicationInterval = 10; //seconds
	public float VirusAttachTimeLimit = 6; //seconds
	
	public int life = 2;
	
	private float TimeElapsed = 0;
	private float CellDuplicationTime;
	
	private bool hasVirus = false;
	private Animator anim;

	public int cureCount = 5;
	private int cureTapsMade = 0;
	
	float random_min = -1.0f;
	float random_max = 1.0f;
	// global counter for max number of performing duplication actions allowed
	public static int duplicateLimit = 14;
	
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		float random_rotate_z = Random.Range(random_min, random_max);
		transform.Rotate(0f, 0.0f, random_rotate_z);
		VirusCount = Random.Range(5, 8);
		gameObject.GetComponentsInChildren<Timer>()[0].UpdateTimerText("" );
		GameMonitor.cellCount += 1;
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
				//uninfectCell();
				killCell(true);
				TimeElapsed = 0;
			} else {
				gameObject.GetComponentsInChildren<Timer>()[0].UpdateTimerText((Mathf.FloorToInt(VirusAttachTimeLimit-TimeElapsed).ToString()) );
				
			}
		}
		
		CellDuplicationTime += Time.deltaTime;
		if ((life >= 0) && (CellDuplicationInterval <= CellDuplicationTime)) {
			duplicate(life--);
		}
	}
	
	void OnMouseDown() {
		if (hasVirus) {
			if (cureTapsMade >= cureCount) {
				uninfectCell ();
			}
			cureTapsMade++;
		}
	}
	
	public void killCell(bool makeVirus) {
		Destroy (gameObject);
		GameMonitor.cellCount-= 1;

		if (!makeVirus)
			return;
		else 
			spreadVirus ();
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
		cureTapsMade = 0;
		TimeElapsed = 0;
		gameObject.GetComponentsInChildren<Timer>()[0].UpdateTimerText("" );
		// Set the sprite from "infected" to "healthy"
	}

	public bool isInfected() {
		return hasVirus;
	}

	private void spreadVirus () {
		float currVirusCount = VirusCount * TimeElapsed / VirusAttachTimeLimit;
		// Reproduce viruses
		for (int i = 0; i < currVirusCount; i++) {
			GameObject clone;
			//a clone of the virus
			Vector2 cellPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y);
			float angle = i * 360 / currVirusCount;
			Vector2 virusPosition = cellPosition + circularSpreadValue * new Vector2 (Mathf.Cos (angle * Mathf.Deg2Rad), Mathf.Sin (angle * Mathf.Deg2Rad));
			// make new clone and change its facing diunirection
			clone = Instantiate (Virus, virusPosition, Quaternion.identity) as GameObject;
			virus_bounce newVirusObject = clone.GetComponent<virus_bounce> ();
			newVirusObject.GoInDirection (angle, virusExplosionSpeed);
		}
	}
	
	private void jitter() {
		float dx = Random.Range(-10, 10);
		float dy = Random.Range(-10, 10);
		float d = 10;
		
		// if the cell collides with a wall we bounce the cell off the wall 
		transform.Translate ((dx / d), (dy / d), 0); 
	}
	
	private void duplicate(int life){
		if(duplicateLimit <= 0){
			return;
		}
		
		if (life >= 0) {
			Vector3 temp_spawn_location =  transform.position; 
			temp_spawn_location.x += 1;
			Vector3 spawn_location = temp_spawn_location;
			
			GameObject temp_spawn_cell = (GameObject)Instantiate (spawn, spawn_location, transform.rotation);
			// decrement the duplicateLimit as weve just splitted a cell
			--duplicateLimit;
		}
	}
}