using UnityEngine;
using System.Collections;

public class Winportal : MonoBehaviour {

	public static int level = 0;
	private GameObject scorescreen;
	public Camera camera2;
	public Camera maincamera;
	// Use this for initialization
	void Start () {
		scorescreen = GameObject.Find("ScoreScreen");

	}


	void OnTriggerEnter(Collider col){


			if(col.collider.tag == "Player"){
			Debug.Log("touchindoor");
			StartCoroutine(scorescreen.GetComponent<ScoreScript1>().levelisdone());
			scorescreen.GetComponent<Fader>().readytofade = true;
			StartCoroutine(scorescreen.GetComponent<ScoreScreen>().StartScoreScreen());
	
			maincamera.camera.active = false;
			camera2.camera.active = true;
			StartCoroutine(NextLevel());

			}
			
			Debug.Log (level);
		}
		IEnumerator NextLevel(){
			yield return new WaitForSeconds(10);
			Application.LoadLevel(level);
			level ++;
		}
	}

