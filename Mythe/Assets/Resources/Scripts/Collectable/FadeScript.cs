using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {

	public float ratio = 2;

	void Update(){
		ratio +=  Time.deltaTime;
		Color col = renderer.material.color;
		col.a = Mathf.Lerp (col.a,0f,ratio);
		renderer.material.color = col;

		this.transform.Translate(0,0.01f,0);
	}
		
}