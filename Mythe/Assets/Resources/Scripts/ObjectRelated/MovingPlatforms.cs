using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour {
	public GameObject currentPlatform;
	public GameObject otherPlatform;
	public GameObject platform1;
	public GameObject platform2;
	public float platformSpeed = 1;
	public int maxLength = 100;
	
	private int currentLength = 0;
	
	void Start(){
		platform1 = GameObject.Find("kleineplatform1");
		platform2 = GameObject.Find("kleineplatform2");

	}
	void OnCollisionEnter(Collision col){
		if(platform1.collider.name == "Moveableobject" || platform2.collider.name == "Moveableobject"){
			Debug.Log(collider.name);
			currentPlatform = col.collider.gameObject;

			if(col.collider == platform1){
				otherPlatform = platform2;
			}else{
				otherPlatform = platform1;
			}
			StartCoroutine(MovePlatforms());
		}
	}

	IEnumerator MovePlatforms(){
		if(maxLength >= currentLength){
			currentPlatform.transform.Translate(0,platformSpeed,0);
			otherPlatform.transform.Translate(0,-platformSpeed,0);
		}
		currentLength += 1;
		yield return new WaitForSeconds(0.1f); 
	}
}
