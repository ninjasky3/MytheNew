
using UnityEngine;
using System.Collections;

public class Newswitch : MonoBehaviour {
	public static Transform player;
	public static int currentplayer = 1;
	public GameObject startingplayer;
	public static GameObject player1;
	public static GameObject player2;
	public static GameObject player3;
	public static GameObject player1Pic;
	public static GameObject player2Pic;
	public static GameObject player3Pic;
	private bool player2start = false;
	private float timer;
	private GameObject camerabutton;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");
		player3 = GameObject.Find("Player3");

		player1Pic = GameObject.Find("GreenPlayer");
		player2Pic = GameObject.Find("BluePlayer");
		player3Pic = GameObject.Find("PinkPlayer");
		startingplayer = player1.gameObject;
		player = startingplayer.transform;
	


	}
	
	// Update is called once per frame

	void Update () {
		//Debug.Log(startingplayer);
		if(startingplayer == null){
			startingplayer = GameObject.FindWithTag("Player"); 
			player = startingplayer.transform;
			if(startingplayer.name == "Player2"){
				currentplayer = 2;
			}
			else
			{
				currentplayer = 3;
			}
		}
		if(currentplayer == 1){
			if(player1 != null){
				playerScript.playingguys[0] = true;
				playerScript.playingguys[1] = false;
				playerScript.playingguys[2] = false;
				player = player1.transform;
				ButtonSwitching.actionButtonBool = true;
				ButtonSwitching.breakButtonBool = false;
				ButtonSwitching.coinButtonBool = false;
				player1Pic.renderer.enabled = true;
				player2Pic.renderer.enabled = false;
				player3Pic.renderer.enabled = false;
			}

		}
		if( currentplayer == 2 ){
			if(player2 != null){
				playerScript.playingguys[1] = true;
				playerScript.playingguys[0] = false;
				playerScript.playingguys[2] = false;
				player = player2.transform;
				ButtonSwitching.actionButtonBool = false;
				ButtonSwitching.breakButtonBool = false;
				ButtonSwitching.coinButtonBool = true;
				player1Pic.renderer.enabled = false;
				player2Pic.renderer.enabled = true;
				player3Pic.renderer.enabled = false;
			}
		
		}

		if(currentplayer == 3){
			if(player3 != null){
				playerScript.playingguys[2] = true;
				playerScript.playingguys[1] = false;
				playerScript.playingguys[0] =	false;
				player = player3.transform;
				ButtonSwitching.actionButtonBool = false;
				ButtonSwitching.breakButtonBool = true;
				ButtonSwitching.coinButtonBool = false;
				player1Pic.renderer.enabled = false;
				player2Pic.renderer.enabled = false;
				player3Pic.renderer.enabled = true;
				}
		}

		if(currentplayer == 3){
			
			currentplayer = 0;
		}
	}

	void OnMouseDown(){
			if(currentplayer > 3){
			
			currentplayer = 0;
		}
		currentplayer++;

	}


	
}
