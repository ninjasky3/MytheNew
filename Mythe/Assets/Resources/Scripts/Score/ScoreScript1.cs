using UnityEngine;
using System.Collections;

public class ScoreScript1 : MonoBehaviour {

	public GUIText scoreText;
	public static int timerScore;
	public float timer;
	// Use this for initialization
	void Start () {
		timer = 0;
		timerScore = 0;

	}
	
	// Update is called once per frame
	void Update () {
		SetscoreText();
		timer += 1 * Time.deltaTime;
		Debug.Log(timer);

	}
	
	void SetscoreText() {
		scoreText.text = "score "+ timerScore;
		
		
		
		
	}

	public IEnumerator levelisdone(){
		if(timer < 15){
			timerScore = 300;
		}
		if(timer > 30){
			timerScore = 250;
		}
		if(timer > 45){
			timerScore = 200;
		}
		if(timer > 60){
			timerScore = 150;
		}
		if(timer > 75){
			timerScore = 100;
		}
		if(timer > 90){
			timerScore = 50;
		}

		yield return new WaitForSeconds(0);
	}

}
