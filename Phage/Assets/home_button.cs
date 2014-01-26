using UnityEngine;
using System.Collections;

public class home_button : MonoBehaviour {

	
	public void OnMouseEnter(){
		//change text color
		GetComponent<SpriteRenderer>().color = Color.grey;
	}
	
	public void OnMouseExit(){
		//change text color
		GetComponent<SpriteRenderer>().color = Color.white;	
	}
	
	public void OnMouseUp(){
		
		Application.LoadLevel(0);
		
	}
	
	public void Update(){
		
	}
}
