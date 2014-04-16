using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {
	private int npcCount = 0;
	public GameObject score;
	public static int PickupScore;
	private int timer;

	void Awake(){
		score.SetActive(false);
	}
	void OnTriggerEnter(Collider col){
		
		if(col.collider.tag == "Familypickups")
		{
			if(playerScript.playingguys[1]){
				col.gameObject.SetActive(false);
				col.collider.renderer.enabled = false;
				PickupScore += 100;
				npcCount += 1;
				score.SetActive(true);
				GameObject scorething =	Instantiate(Resources.Load("Prefabs/Score+"),transform.position,Quaternion.identity) as GameObject;
				score = scorething;
				StartCoroutine(gofalse());


			}


		}
		
	}

		IEnumerator gofalse(){
		yield return new WaitForSeconds(3);
		Debug.Log("ylo");
		score.SetActive(false);

	}
}
