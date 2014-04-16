using UnityEngine;
using System.Collections;

public class Actionscript : MonoBehaviour {
	public float jumpheights;
	private GameObject player3;
	public Animator jumpanimator;
	private bool isjumping = false;
	private bool onground = true;
	public static bool jump = false;
	public static bool onLadder = false;
	private bool moveOnLadder = false;
	public static bool onButton = false;
	private bool moveUp = false;

	private void Start(){
		player3 = GameObject.Find("Player3");

	}
	public void Action(){
	
		jump = true;
		if(playerScript.playerWalking1){
		jumpanimator.SetInteger("jumping",1);
		}
		else{
			jumpanimator.SetInteger("jumping",3);
		}
		//player3.GetComponent<BreakWallScript>().startroutine();

		if(onLadder){

			this.collider.isTrigger = true;
			//this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
			moveUp = true;

		}
		else if (jump && onground && !isjumping) {

			if(playerScript.playingguys[0]){
				playerScript.player1.transform.rigidbody.AddRelativeForce(Vector3.up * jumpheights);
			
				Debug.Log(jumpheights);
				jump = false;
				isjumping = true;
				onground = false;

			}
			
		}
	

	}
	//UPDATE ALLEEN VOOR LADDER CLIMB SINDS WE HET ANDERS MOETEN RE-WRITEn
	void Update(){
		if(moveUp){
			this.rigidbody.AddForce(Vector3.up * 125 * Time.deltaTime);

		}

	}
	void OnTriggerExit(Collider col){
		
		if(col.collider.tag == "Stairs"){
			moveUp = false;
			onLadder = false;
			this.collider.isTrigger = false;
			moveOnLadder = false;
			if(playerScript.playingguys[0]){
				playerScript.player1.rigidbody.AddRelativeForce(-Vector3.up * 2700* Time.deltaTime );
			}
			else if(playerScript.playingguys[1]){
				playerScript.player2.rigidbody.AddRelativeForce(-Vector3.up * 2700* Time.deltaTime );
			}
			else if(playerScript.playingguys[2]){
				playerScript.player3.rigidbody.AddRelativeForce(-Vector3.up * 2700* Time.deltaTime );
			}
			rigidbody.AddRelativeForce(-Vector3.up * 1700* Time.deltaTime );
		}
	}
	void onTriggerStay(Collider col){
		if(col.collider.tag == "Stairs"){
			onLadder = true;
			
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.collider.tag == "Stairs"){
			onLadder = true;
			
		}
		if(col.collider.tag == "Jumppads"){
			rigidbody.AddRelativeForce(Vector3.up * 3000 * Time.deltaTime );
			
		}
	}
	void OnCollisionEnter(Collision col){
		if(col.collider.tag == "Stairs"){
			onLadder = true;
			
		}

		if(col.collider.tag == "platforms"){
			onButton = false;
			jump = false;
			onground = true;
			isjumping = false;
			this.rigidbody.velocity = (Vector3.zero);
			if(playerScript.playerWalking1){
				jumpanimator.SetInteger("jumping",2);
			}
			else{
				jumpanimator.SetInteger("jumping",4);
			}

		}
	}


}