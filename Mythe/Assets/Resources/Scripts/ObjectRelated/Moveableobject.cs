using UnityEngine;
using System.Collections;

public class Moveableobject : MonoBehaviour {

	private GameObject player3;
	public Animator pushinganimator;
	// Use this for initialization
	void Start () {
		player3 = GameObject.Find("Player3");
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

	void OnCollisionEnter(Collision col){
		if(col.collider.name == "Player3"){
			rigidbody.mass = 0.0000001f;
			if(playerScript.playerWalking3){
				pushinganimator.SetInteger("pushing",1);
			}
			else{
				pushinganimator.SetInteger("pushing",3);
			}
		}



	}

	void OnCollisionStay(Collision col){
		if(col.collider.name == "Player3")
		{
			rigidbody.mass = 0.0000001f;
		
	}
		
	}
	void OnCollisionExit(Collision col){
		if(col.collider.name == "Player3")
		{
			rigidbody.mass = 1000;
			if(playerScript.playerWalking3){
				pushinganimator.SetInteger("pushing",2);
			}
			else{
				pushinganimator.SetInteger("pushing",4);
			}
		}
	}
}
