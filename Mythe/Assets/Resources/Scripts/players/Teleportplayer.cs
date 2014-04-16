using UnityEngine;
using System.Collections;

public class Teleportplayer : MonoBehaviour {

	// Use this for initialization
	private GameObject player2;
	void Start () {
		player2 = GameObject.Find("Player2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnTriggerEnter(Collider col){
	if(col.collider.tag == "Player");
	
	player2.transform.position = this.transform.position;
	}
}
