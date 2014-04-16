using UnityEngine;
using System.Collections;

public class ButtonSwitching : MonoBehaviour {
	private GameObject actionButton;
	private GameObject breakButton;
	private GameObject coinButton;

	public static bool actionButtonBool = true;
	public static bool breakButtonBool = false;
	public static bool coinButtonBool = false;

	void Start(){
		actionButton = GameObject.FindWithTag("actionButton");
		breakButton = GameObject.FindWithTag("breakButton");
		coinButton = GameObject.FindWithTag("cointossButton");
		actionButton.renderer.enabled = actionButtonBool;
		breakButton.renderer.enabled = breakButtonBool;
		coinButton.renderer.enabled = coinButtonBool;
		coinButton.renderer.renderer.enabled = coinButtonBool;

		actionButton.collider.enabled = actionButtonBool;
		breakButton.collider.enabled = breakButtonBool;
		coinButton.collider.enabled = coinButtonBool;
	}
	void Update(){
		actionButton.collider.enabled = actionButtonBool;
		breakButton.collider.enabled = breakButtonBool;
		coinButton.collider.enabled = coinButtonBool;
		coinButton.renderer.renderer.enabled = coinButtonBool;
		breakButton.renderer.renderer.enabled = breakButtonBool;
		actionButton.renderer.renderer.enabled = actionButtonBool;
	}


}
