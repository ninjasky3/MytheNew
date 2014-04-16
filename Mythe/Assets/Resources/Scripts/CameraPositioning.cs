using UnityEngine;
using System.Collections;


public class CameraPositioning : MonoBehaviour {
	public float DistanceY = 0.4f;
	public float DistanceX = 0.4f;
	public static bool NoZoom = false;
	void OnTriggerEnter(Collider col){
		if(col.collider.tag == "Player"){
			CameraScript.viewX = DistanceX;
			CameraScript.viewY = DistanceY;
			NoZoom = true;

		}

	}
	void OnTriggerExit(Collider col){
		if(col.collider.tag == "Player"){
			DistanceY = 0.5f;
			DistanceX = 0.4f;
			CameraScript.viewX = DistanceX;
			CameraScript.viewY = DistanceY;
			NoZoom = false;
		}
	}
}
