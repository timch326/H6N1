using UnityEngine;
using System.Collections;

public class CellBehaviour : MonoBehaviour {
	
	public GameObject spawn;
	public GameObject Virus;
	public GameMonitor monitor;
	
	public float circularSpreadValue = 0.1f;
	public float virusExplosionSpeed = 1000;
	public float CellDuplicationInterval = 10; //seconds
	public float InfectionTimeLimit = 3; //seconds
	//public int life = 2;

	private Animator anim;
	private float InfectionTime = 0;
	private float LastDuplicationTime = 0;
	private int VirusCount = 1;
	private bool hasVirus = false;

	public int cureCount = 5;
	private int cureTapsMade = 0;
	
	float random_min = -1.0f;
	float random_max = 1.0f;
	// global counter for max number of performing duplication actions allowed

	public AudioClip squish;
	
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		monitor = GameMonitor.getInstance ();
		float random_rotate_z = Random.Range(random_min, random_max);
		transform.Rotate(0f, 0.0f, random_rotate_z);
		VirusCount = Random.Range(5, 8);
		gameObject.GetComponentsInChildren<Timer>()[0].UpdateTimerText("" );
		monitor.cellCount++;
	}
	
	void Start () {
	}
	 
	// Update is called once per frame
	void Update() {
		jitter ();
		if (hasVirus) {
			InfectionTime += Time.deltaTime;
			gameObject.GetComponentsInChildren<Timer>()[0].UpdateTimerText((Mathf.FloorToInt(InfectionTimeLimit-InfectionTime).ToString()));

			if (InfectionTimeLimit <= InfectionTime) {
				killCell(true);
				InfectionTime = 0;
			}
		}
		
		LastDuplicationTime += Time.deltaTime;
		if (CellDuplicationInterval <= LastDuplicationTime) {

			if (!monitor.HasReachedCellLimit()){
				duplicate();
			}
			LastDuplicationTime = 0;
		}
	}
	
	void OnMouseDown() { 


		if (hasVirus) {
			anim.SetTrigger ("cure_click");

			Debug.Log ("Playing Squish Sound");
			audio.PlayOneShot(squish);
			if (cureTapsMade >= cureCount) {
				uninfectCell ();
			}
			cureTapsMade++;
		}
	}
	
	public void killCell(bool makeVirus) {
		Destroy (gameObject);
		monitor.cellCount -= 1;
		if (hasVirus) {
			monitor.infectedCellCount -= 1;
		}

		if (makeVirus == true) {
			spreadVirus();
		}
	}
	
	public void infectCell() {
		if (!hasVirus) {
			hasVirus = true;
			anim.SetTrigger ("toInfected");
			monitor.infectedCellCount++;
		}
	}
	
	public void uninfectCell() {
		hasVirus = false;
		//anim.SetTrigger ("toHealthy");
		Debug.Log ("Uninfect Cell");
		cureTapsMade = 0;
		InfectionTime = 0;
		gameObject.GetComponentsInChildren<Timer>()[0].UpdateTimerText("" );
		monitor.infectedCellCount--;
	}

	public bool isInfected() {
		return hasVirus;
	}

	private void spreadVirus () {
		float currVirusCount = VirusCount * InfectionTime / InfectionTimeLimit;
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
	
	private void duplicate(){
		Vector3 ChildCellPosition =  transform.position; 
		ChildCellPosition.x += 1;

		GameObject ChildCell = (GameObject) Instantiate (spawn, ChildCellPosition, transform.rotation);
		if (isInfected ()) {
			ChildCell.GetComponent<CellBehaviour>().infectCell();
		}
	}
}