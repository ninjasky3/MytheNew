using UnityEngine;
using System.Collections;

public class jumpscare : MonoBehaviour {
	public GameObject ted;
	public GameObject cumrah;
	public AudioClip scream;
	void Start(){
		ted.SetActive(false);
	}
	// Use this for initialization
	void OnCollisionEnter(Collision col){
		if(col.collider.tag == "Player"){
			ted.SetActive(true);
			audio.PlayOneShot(scream);
			cumrah.GetComponent<ShakeScript>().DoShake();
			Debug.Log(cumrah);

		}
	}
}
