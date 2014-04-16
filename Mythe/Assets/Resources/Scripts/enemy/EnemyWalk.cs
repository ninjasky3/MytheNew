using UnityEngine;
using System.Collections;

public class EnemyWalk : MonoBehaviour {
	
	public bool alife = true;
	private bool lookingLeft;
	public static int enemyscore;
	private GameObject destroyablegobj;
	public Animator enemyanimator;
	bool aggroLeft;
	bool aggroRight;
	int speed = 6;
	

	
	void Start(){
		enemyscore = 0;
	} 
	
	void walk(bool left,float speedMultiplayer = 1){
		Debug.Log("walkvoid");
		float walkSpeed = speed*speedMultiplayer;

			if(left){
				rigidbody.AddForce(-walkSpeed,0,0);	
			}else{
				rigidbody.AddForce(walkSpeed,0,0);	
			}

	}
	

	
	void FixedUpdate () {
			
			//follow player
			if(aggroLeft){
			Debug.Log("walkvoid2");
				walk (true,2.0f);	
			}else if (aggroRight){
			Debug.Log("walkvoid2");
				walk (false,2.0f);	
			}
			//normal walk
			if(!aggroLeft&&!aggroRight){
			//Debug.Log("walkvoid3");
					//walk (true);

			}
		
			Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.left));
			RaycastHit hit;
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);	
	
			if (Physics.Raycast(ray, out hit, 10))
			{
			if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Coin" )
				{
					aggroLeft = true;
				enemyanimator.SetInteger("IdleAnim",1);
				enemyanimator.SetInteger("EnemieWalking",2);
				lookingLeft = true;
				}else{
					aggroLeft = false;	
					if(lookingLeft){
						enemyanimator.SetInteger("EnemieWalking",4);
					}
				}
			}else{
				aggroLeft = false;	
			if(lookingLeft){
				enemyanimator.SetInteger("EnemieWalking",4);
			}
			}
			
			Ray ray2 = new Ray(transform.position, transform.TransformDirection(Vector3.right));
			RaycastHit hit2;
			Debug.DrawRay(ray2.origin, ray2.direction * 10, Color.red);	
	
			if (Physics.Raycast(ray2, out hit2, 10))
			{
			if (hit2.collider.gameObject.tag == "Player" || hit2.collider.gameObject.tag == "Coin" )
				{
					aggroRight = true;
				enemyanimator.SetInteger("IdleAnim", 0);
				enemyanimator.SetInteger("EnemieWalking", 1);
				lookingLeft = false;
				
				}else{

				aggroRight = false;	
				if(!lookingLeft){
					enemyanimator.SetInteger("EnemieWalking", 0);
					}
				}
			}else{
				aggroRight = false;	
			if(!lookingLeft){
				enemyanimator.SetInteger("EnemieWalking", 0);
			}
			}	
		}

	void OnCollisionEnter(Collision col){
		if(col.collider.gameObject.tag == "Coin"){
			StartCoroutine(StartAnim());
			destroyablegobj = col.gameObject;

		}

	}

	IEnumerator StartAnim(){
		yield return new WaitForSeconds(1);
		if(lookingLeft){
			enemyanimator.SetInteger("EnemieWalking", 9);
		}
		if(!lookingLeft){
			enemyanimator.SetInteger("EnemieWalking", 8);
		}
		enemyscore += 100;
		Destroy(destroyablegobj);
	}

}
