﻿using UnityEngine;
using System.Collections;

public class Switchscript : MonoBehaviour {

	public GameObject[] ladders;
	private int maxladders;
	// Use this for initialization

	void Awake () {


		for(int i=0; i< ladders.Length; i++) {
			maxladders = i;
			ladders[i].SetActive(false);
		}
	}
	void OnTriggerEnter(Collider col) {
		if(col.collider.tag == "Player"){
			gameObject.SetActive(false);
			enabled = false;
			for(int i=0; i< ladders.Length; i++) {
				ladders[i].SetActive(true);
			}


		}

		if(col.collider.tag == "objects"){
			gameObject.SetActive(false);
			enabled = false;
			for(int i=0; i< ladders.Length; i++) {
				ladders[i].SetActive(true);
			}
			
			
		}

		
	}
}
