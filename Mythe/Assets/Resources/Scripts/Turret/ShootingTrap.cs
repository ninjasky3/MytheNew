using UnityEngine;
using System.Collections;

public class ShootingTrap : MonoBehaviour {

	// Use this for initialization
	public Animator shootinganimator;
	private Vector3 bulletransformright;
	private Vector3 bulletransformleft;
	public bool lookingleft;
	private float timer;
	void Start () {
	
		if(lookingleft){
			shootinganimator.SetInteger("idle",1);
		}
		else{
			shootinganimator.SetInteger("idle",0);
		}
		bulletransformright = this.transform.position;
		bulletransformright.x += -0.35f;
		bulletransformright.y += 0.4f;
			
		bulletransformleft = this.transform.position;
		bulletransformleft.x += 0.35f;
		bulletransformleft.y += 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1 * Time.deltaTime;
		if(timer > 4){
			if(lookingleft){

	GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet"),bulletransformright,Quaternion.identity) as GameObject;
				bullet.rigidbody.AddForce(300,0,0);
				shootinganimator.SetInteger("Shooting",1);
				StartCoroutine(StopShooting());
			}
			else{
				shootinganimator.SetInteger("Shooting",3);
				GameObject bullet2 = GameObject.Instantiate(Resources.Load("Prefabs/Bullet2"),bulletransformleft,Quaternion.identity) as GameObject;
				bullet2.rigidbody.AddForce(-300,0,0);
				StartCoroutine(StopShooting());
			}

			timer = 0;
		}
	}

	IEnumerator StopShooting(){
		yield return new WaitForEndOfFrame();;
		if(lookingleft){
	shootinganimator.SetInteger("Shooting",2);
		}
		else{
		shootinganimator.SetInteger("Shooting",0);
		}

	}
	
}
