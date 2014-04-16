using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	private Actionscript actionscript;
	private CoinScript coinscript;
	private GameObject target;
	private GameObject player1;
	private GameObject pauzeButton;

	void Start(){

		pauzeButton = GameObject.Find("PauzeButton");
		player1 = GameObject.Find("Player1");
		Debug.Log(this.gameObject.name);
	}

	void Update(){
		if(target != Newswitch.player.gameObject || target == null){
			target = Newswitch.player.gameObject;
			Debug.Log(target);
		}

		if(Input.touchCount == 0){
			playerScript.walking1 = false;
			playerScript.walking2 = false;
		}
		foreach(Touch touch in Input.touches){
			for (var i = 0; i < Input.touchCount; ++i) {
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				RaycastHit hit;
				if(touch.phase == TouchPhase.Began){
					if (Physics.Raycast(ray, out hit,10, 1<<12))
					{
						Debug.Log("hits layer 12");

						if(Time.timeScale == 1){

							if(hit.collider.tag == "cointossButton"){
								CoinToss();
							}else if(hit.collider.tag == "breakButton"){
								BreakWall();
							}else if(hit.collider.tag == "pauzeButton"){
								Pauze();
							}else if(hit.collider.tag == "actionButton"){
							//Debug.Log("Hitt button");
							DoingAction();
							}


							
						}else{
							if(hit.collider.tag == "pauzeButton"){
								Pauze();
							}else if(hit.collider.tag == "Resume"){
								Pauze();
							}else if(hit.collider.tag == "Restart"){
								Application.LoadLevel(Winportal.level);
							}else if(hit.collider.tag == "Quit"){
								Application.Quit();
							}
						}
					}else
					{
						if(Time.timeScale == 1){
						//if(hit.collider.name == "BackGround"){
							
							MovingPlayer(touch);
						//}else 
						}
					}
				}
				
			}
			
		}
	}
	void Pauze(){
		StartCoroutine(pauzeButton.GetComponent<PauzeScript>().Pause());

	}
	void BreakWall(){
		target.GetComponent<BreakWallScript>().startroutine();
	}
	void CoinToss(){
		target.GetComponent<CoinScript>().Coin();
	}

	void MovingPlayer(Touch touch){
	
	//	foreach(Touch touch in Input.touches){
	//		for (var i = 0; i < Input.touchCount; ++i){
			//	Debug.Log(touch.position.x);
		if(Input.touchCount <= 1){
					if(touch.position.x > Screen.width/2)
					{
						playerScript.walking1 = true;
						playerScript.walking2 = false;
					}
					else if(touch.position.x < Screen.width/2)
					{
						playerScript.walking2 = true;
						playerScript.walking1 = false;

					}
		}

	//		}

	//}
	}
	void DoingAction(){

		target.GetComponent<Actionscript>().Action();
		//GetComponent<Actionscript>().Action();
	}
}

