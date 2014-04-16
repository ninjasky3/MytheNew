using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	public AudioClip[] walkingClips;


	void OnCollisionEnter(Collision col){
		if(col.collider.tag == "platforms"){
			audio.PlayOneShot(walkingClips[Random.Range(0,walkingClips.Length)]);
		}

	}
}
