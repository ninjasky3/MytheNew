using UnityEngine;
using System.Collections;

public class ShakeScript : MonoBehaviour {
	public bool Shaking; 
	public float ShakeDecay;
	public float ShakeIntensity;   
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;
	private bool isshaking;
	
	void Start()
	{
		Shaking = false;   
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(ShakeIntensity > 0)
		{
			transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
			transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
			                                    OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
			                                    OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
			                                    OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f);
			
			ShakeIntensity -= ShakeDecay;
		}
		else if (Shaking)
		{
			Shaking = false;  
		}
	}
	
	
	void OnGUI() {
		
		if (GUI.Button(new Rect(10, 200, 50, 30), "Shake"))
			DoShake();
	
		
	}     
	
	
	
	
	
	
	public void DoShake()
	{
		if(!isshaking){
		OriginalPos = transform.position;
		OriginalRot = transform.rotation;
		
		ShakeIntensity = 0.4f;
		ShakeDecay = 0.004f;
		Shaking = true;
			isshaking = true;
		}
	}   
	
	
}