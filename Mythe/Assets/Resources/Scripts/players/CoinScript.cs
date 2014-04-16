using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	private int sides = 1;
	private int walkingSide = 0;
	private int coins = 3;
	private int throwForce;
	public Animator throwcoinanim;
	private Vector3 coinpos;
	public static GameObject coin;
	void Start(){
	

	}
	public void Coin(){

		Debug.Log(coins);
		if(coins > 0){
			StartCoroutine(CheckSide());
			Debug.Log("Checked Side");
			throwcoinanim.SetInteger("throwcoin",sides);
			StartCoroutine(StopAnim());
			GameObject coin = Instantiate(Resources.Load("Prefabs/Coin"), coinpos = new Vector3(transform.position.x + throwForce,transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
			StartCoroutine(moveCoin());
			coin.name = "coin";
			coins --;
			coin.rigidbody.AddRelativeForce(throwForce * 300,0,0);
			Debug.Log(throwForce);
			Physics.IgnoreCollision(this.collider, coin.collider);
			Physics.IgnoreCollision(coin.collider, playerScript.player2.collider);
			Physics.IgnoreCollision(coin.collider, playerScript.player1.collider);
			Physics.IgnoreCollision(coin.collider, playerScript.player3.collider);



		}


	}

	IEnumerator moveCoin(){
		coin.rigidbody.AddRelativeForce(throwForce * 10,0,0);

		yield return new WaitForSeconds(0f);
	}

	IEnumerator StopAnim(){
		yield return new WaitForSeconds(1);
		throwcoinanim.SetInteger("throwcoin",0);
		

	}

	IEnumerator CheckSide(){
		Debug.Log("Checking sides");
		if(playerScript.playerWalking2){
			sides = 2;
			throwForce = -1;
			walkingSide = 0;
		}

		else if(!playerScript.playerWalking2){	
			sides = 1;
			throwForce = 1;
			walkingSide = 4;
		}
		throwcoinanim.SetInteger("walking2",walkingSide);
		yield return new WaitForSeconds(0f);

	}
}
