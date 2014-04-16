using UnityEngine;
using System.Collections;

public class InputScreenMenu : MonoBehaviour {


	private int level = 1;

	void Start(){

		level = PlayerPrefs.GetInt("Level", level);
	}
	// Update is called once per frame	
		void Update(){
			foreach(Touch touch in Input.touches){
				for (var i = 0; i < Input.touchCount; ++i) {
					Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
					RaycastHit hit;
					if(touch.phase == TouchPhase.Began){
						if (Physics.Raycast(ray, out hit))
						{
							if(hit.collider.tag == "Resume"){
								Application.LoadLevel(level);
							}else if(hit.collider.tag == "LevelSelect"){
								
							}else if(hit.collider.tag == "Instruction"){
								
							}else if(hit.collider.tag == "Quit"){
								Application.Quit();
							}
					
						}
					}
				}
			}
		}
}