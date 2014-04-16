 using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour {

	// Use this for initialization
	private GameObject ScorePlane;
	private int totalscore;
	public TextMesh TimeScore;
	public TextMesh EnemyScore;
	public TextMesh PickupScore;
	public TextMesh TotalScore;


	void Start () {
		ScorePlane = GameObject.Find("ScoreScreen");
		//ScorePlane.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
	
	}

		public IEnumerator StartScoreScreen(){

		TimeScore.text = "" + ScoreScript1.timerScore;
		PickupScore.text = "" + Collectables.PickupScore;
		EnemyScore.text = "" + EnemyWalk.enemyscore;
		totalscore = ScoreScript1.timerScore + Collectables.PickupScore + EnemyWalk.enemyscore;
		TotalScore.text = "" + totalscore;
		yield return new WaitForSeconds(0);
		//ScorePlane.SetActive(true);



	}
}
