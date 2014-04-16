
using UnityEngine;
using System.Collections;

public class ObjectMove : MonoBehaviour {
	//public
	public Transform PointA;
	public Transform PointB;
	public float Speed = 1;
	//private
	private bool startgame = true;
	private bool MovingToB = false;
	private bool direction;
	void Start(){

	}
	// switch direction
	void FixedUpdate () {
		if(transform.position == PointA.position){	startgame = false;	}
		if(transform.position == PointA.position){	MovingToB = true;	}
		if(transform.position == PointB.position){	MovingToB = false; 	}
		if(transform.position == PointB.position){	startgame = true; 	}

		//move platform to point A or B
		if(startgame){
			transform.position = Vector3.MoveTowards(transform.position, PointA.position, Speed);
		}
		if(MovingToB){
			transform.position = Vector3.MoveTowards(transform.position, PointB.position, Speed);
		}
	}

}
