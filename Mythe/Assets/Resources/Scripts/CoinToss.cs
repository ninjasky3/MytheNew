using UnityEngine;
using System.Collections;

public class CoinToss : MonoBehaviour {
	public static bool onButton = false;
	private bool throwcoin;
	private float timer;
	private int coins;
	// Update is called once per frame

	void Start (){

		coins = 2;
	}
	void Update () {
		for (var i = 0; i < Input.touchCount; ++i) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				onButton = false;
				if (hit.collider.tag ==  "tossButton" && coins > 2){
					onButton = true;
					throwcoin = true;
					
				}
			}
		}

		if(throwcoin == true){
			GameObject datcoin = Instantiate (Resources.Load("Prefabs/Coin"),transform.position,Quaternion.identity) as GameObject;
			throwcoin = false;
			coins --;
		}
	}
}
