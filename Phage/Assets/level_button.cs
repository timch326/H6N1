using UnityEngine;
using System.Collections;

public class level_button : MonoBehaviour {
	
	public int level;
	
	public void OnMouseEnter(){
		//change text color
		renderer.material.color=Color.red;
	}
	
	public void OnMouseExit(){
		//change text color
		renderer.material.color=Color.white;
	}
	
	public void OnMouseUp(){

			Application.LoadLevel(level);

	}
	
	public void Update(){

	}
}
