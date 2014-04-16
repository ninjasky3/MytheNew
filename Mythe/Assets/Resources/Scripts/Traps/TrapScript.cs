using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {
	public GameObject trap;

	// Use this for initialization
	void Awake () {
		trap.SetActive(true);

	}
	void OnCollisionEnter(Collision col) {
		if(col.collider.tag == "Player"){
			gameObject.SetActive(false);
			//enabled = false;
			trap.SetActive(false);
			
		}
		
	}
}
