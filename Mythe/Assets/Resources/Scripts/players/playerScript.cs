using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerScript : MonoBehaviour {
	public float speed = 0.9F;
	private float speedDenominator = 100;
	public Animator animator;
	public static bool walking1 = false;
	public static bool walking2 = false;
	public static bool moving = false;
	private RigidbodyConstraints originalConstraints;
	public static GameObject player1;
	public static GameObject player2;
	public static GameObject player3;
	public static bool islookingleft = false;
	public static bool islookingright = false;
	public static bool playerWalking1 = false;
	public static bool playerWalking2 = false;
	public static bool playerWalking3 = false;
	public static bool[] playingguys = new bool[3];
	// Update is called once per frame
	void Start (){
		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");
		player3 = GameObject.Find("Player3");
		Physics.IgnoreCollision(player1.collider, player2.collider);
		Physics.IgnoreCollision(player1.collider, player3.collider);
		Physics.IgnoreCollision(player2.collider, player3.collider);

	}

	void Awake()
	{
		originalConstraints = rigidbody.constraints;
	}
	void Update() {		

	if(walking1)
	{
	if(playingguys[0]){
		player1.transform.Translate(speed / speedDenominator,0,0);
		animator.SetInteger("walking1",1);
		playerWalking1 = false;
		
	}else if(playingguys[1]){
		player2.transform.Translate(speed / speedDenominator,0,0);
		animator.SetInteger("walking2",1);
		playerWalking2 = false;

	}else if(playingguys[2]){
		player3.transform.Translate(speed / speedDenominator,0,0);
		animator.SetInteger("walking3",1);
		playerWalking3 = false;

	}

		
		moving = true;

		
	}
	
	else if(walking2)
	{

		if(playingguys[0]){
			player1.transform.Translate(-speed / speedDenominator,0,0);
			animator.SetInteger("walking1",2);
			playerWalking1 = true;
		}else if(playingguys[1]){
			player2.transform.Translate(-speed / speedDenominator,0,0);
			animator.SetInteger("walking2",2);
			playerWalking2 = true;
		}else if(playingguys[2]){
			player3.transform.Translate(-speed / speedDenominator,0,0);
			animator.SetInteger("walking3",2);
			playerWalking3 = true;
		}
		
		
		moving = true;
	}
	else{
		if(playerWalking1){
			animator.SetInteger("walking1", 0);
		}else{
			animator.SetInteger("walking1", 4);
		}
		if(playerWalking2){
			animator.SetInteger("walking2", 0);
		}else{
			animator.SetInteger("walking2", 4);
		}
		if(playerWalking3){
			animator.SetInteger("walking3", 0);
		}else{
			animator.SetInteger("walking3", 4);
		}
		
		moving = false;
		walking1 = false;
		walking2 = false;
		
		
		}

	}
	void OnTriggerEnter(Collider col){
		if(col.collider.tag == "Stairs"){
			ButtonSwitching.actionButtonBool = true;
			ButtonSwitching.breakButtonBool = false;
			ButtonSwitching.coinButtonBool = false;
		}
	}
	void OnTriggerStay(Collider col){
		if(col.collider.tag == "Stairs"){
			ButtonSwitching.actionButtonBool = true;
			ButtonSwitching.breakButtonBool = false;
			ButtonSwitching.coinButtonBool = false;
		}
	}
	
}
