using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	
	private int count;
	private int maxColectables;
	// Use this for initialization
	void Start () {
		GameObject[] collectables = GameObject.FindGameObjectsWithTag("Familypickups");
		maxColectables = collectables.Length;
		
		count = 0;
		
		
		Debug.Log (maxColectables);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
	}
	void OnCollisionEnter(Collision col){
		Debug.Log("boop");
		if(col.collider.tag == "Familypickups")
		{
			col.gameObject.SetActive(false);
			count += 1;
			
		}

	}
	
	public void NextLevel() {
		if (count == maxColectables){
			Application.LoadLevel ("WinScreen");

		}

		
	}
	

}
