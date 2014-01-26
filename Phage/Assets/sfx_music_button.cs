using UnityEngine;
using System.Collections;

public class sfx_music_button : MonoBehaviour {

	public Sprite on;
	public Sprite off;
	public bool isOn = true;



	void OnMouseDown(){
	if(isOn){
			gameObject.GetComponent<SpriteRenderer>().sprite = off;
			AudioListener.pause = true;

	}else{
			gameObject.GetComponent<SpriteRenderer>().sprite = on;
			AudioListener.pause = false;

		}
		isOn = !isOn;
}
}