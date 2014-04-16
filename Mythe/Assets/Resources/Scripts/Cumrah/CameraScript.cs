using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 delta = new Vector3(0,0,0);
	private Vector3 velocity = Vector3.zero;
	private float viewDistance = 0f;
	public static float viewX = 0.5f;
	public static float viewY = 0.4f;

	public static Transform target;

	// Update is called once per frame
	void Start(){
		target = Newswitch.player;

	}
	IEnumerator ZoomingOut(){
		//Debug.Log("ZoomingOut");
		yield return new WaitForSeconds(1f);
		if(viewDistance <= 4){

			viewDistance += 1f;

		}

	}
	IEnumerator ZoomingIn(){
		if(viewDistance >= 3){

			Debug.Log("ZoomingIn");
			viewDistance -= 1f;



		}
		yield return new WaitForSeconds(0.001f);
	}

	void Update () 
	{
		//Debug.Log(playerScript.moving);
		if(playerScript.moving == true || Actionscript.onLadder || Actionscript.jump){
			StartCoroutine(ZoomingIn());

		}else if(playerScript.moving == false){
			StartCoroutine(ZoomingOut());
		}
		target = Newswitch.player;
		//Debug.Log(target);
		if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(viewX, viewY, viewDistance)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		
	}
}

