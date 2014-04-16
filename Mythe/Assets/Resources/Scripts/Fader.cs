using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	public float ratio;
	private float up = -1;
	public bool readytofade;



	void Start(){
		readytofade = false;

	}
	void Update(){
		if(readytofade){
		ratio += Time.deltaTime;
		Color col = renderer.material.color;
		col.a = Mathf.Lerp (col.a,up,ratio);
		renderer.material.color = col;
		up += 0.05f;
		}
	}
}