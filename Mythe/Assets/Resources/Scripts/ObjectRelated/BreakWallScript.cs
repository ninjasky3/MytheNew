using UnityEngine;
using System.Collections;

public class BreakWallScript : MonoBehaviour {

	private GameObject player3;
	private bool touchedrock;
	// Use this for initialization
	void Start () {
		player3 = GameObject.Find("player3");

	}
	
	// Update is called once per frame
	void Update () {
	 
	}

	private IEnumerator breakwall(){
		if(touchedrock == true){
			Destroy(gameObject);
		}
		yield return new WaitForSeconds(2);
	}

	void OnCollisionEnter(Collision col){
		if(col.collider.name == "Player3"){
			touchedrock = true;
		}
		else{
			touchedrock = false;
		}
	}

	public void startroutine(){
		StartCoroutine(breakwall());
	}
}
