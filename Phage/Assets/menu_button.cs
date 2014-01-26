using UnityEngine;
using System.Collections;

public class menu_button : MonoBehaviour {

	public bool isQuit=false;
	
	public void OnMouseEnter(){
		GetComponent<SpriteRenderer> ().color = Color.grey;
	}
	
	public void OnMouseExit(){
		//change text color
		GetComponent<SpriteRenderer> ().color =Color.white;
	}
	
	public void OnMouseUp(){
		//is this quit
		if (isQuit==true) {
			//quit the game
			Application.Quit();
		}
		else {
			//load level
			Application.LoadLevel(1);
		}
	}
	
	public void Update(){
		//quit game if escape key is pressed
		if (Input.GetKey(KeyCode.Escape)) { Application.Quit();
		}
	}
}
