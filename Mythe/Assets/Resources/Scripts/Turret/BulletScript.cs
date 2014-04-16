using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	private GameObject turret;
	private int bulletspeed = 200;
	private GameObject spawner;
	void Start () {
		spawner = GameObject.Find("spawner");
		turret = GameObject.Find("Turret");
	}
	
	// Update is called once per frame
	void Update () {
		//rigidbody.velocity = Vector3.zero;
		//rigidbody.AddRelativeForce(Vector3.right * bulletspeed);
	
	

	}


	void OnTriggerEnter(Collider col){
		if(col.collider.tag == "platforms"){
		Destroy(gameObject);
		}
		if(col.collider.tag == "objects"){
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
		if(col.collider.tag == "Player"){
			col.gameObject.transform.position = spawner.transform.position;
			Destroy(gameObject);
		}
	}
}
