using UnityEngine;
using System.Collections;

public class ReverseTP : MonoBehaviour {

	private GameObject returnableplayer;
	private GameObject spawner;
	// Use this for initialization
	void Start () {
		
		spawner = GameObject.Find("spawner");
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision col){
		returnableplayer = col.collider.gameObject;
		StartCoroutine(returning());
	}
	
	IEnumerator returning(){
		returnableplayer.transform.position = spawner.transform.position;
		yield return new WaitForSeconds(2);
	}
}
