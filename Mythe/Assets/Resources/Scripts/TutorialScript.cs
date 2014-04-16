using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		renderer.enabled = true;

	}
	void OnTriggerExit(Collider col){
		renderer.enabled = false;
	}

}