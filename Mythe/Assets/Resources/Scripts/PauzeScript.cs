using UnityEngine;
using System.Collections;

public class PauzeScript : MonoBehaviour {
	private GameObject resume;
	private GameObject restart;
	private GameObject quit;
	private bool pauseOn = false;

	private GameObject switchButton;
	void Start(){
		Time.timeScale = 1;

		resume = GameObject.FindWithTag("Resume");
		restart = GameObject.FindWithTag("Restart");
		quit = GameObject.FindWithTag("Quit");
		switchButton = GameObject.Find("SwitchButton");
	}
	public IEnumerator Pause(){
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			pauseOn = true;
			resume.renderer.enabled = pauseOn;
			restart.renderer.enabled = pauseOn;
			quit.renderer.enabled = pauseOn;
			resume.collider.enabled = pauseOn;
			restart.collider.enabled = pauseOn;
			quit.collider.enabled = pauseOn;
			ButtonSwitching.coinButtonBool = false;
			ButtonSwitching.breakButtonBool = false;
			ButtonSwitching.actionButtonBool = false;
			switchButton.gameObject.renderer.enabled = false;
			//Newswitch.currentplayer = 1;

		}else{
			Time.timeScale = 1;
			pauseOn = false;
			resume.renderer.enabled = pauseOn;
			restart.renderer.enabled = pauseOn;
			quit.renderer.enabled = pauseOn;
			resume.collider.enabled = pauseOn;
			restart.collider.enabled = pauseOn;
			quit.collider.enabled = pauseOn;
			switchButton.gameObject.renderer.enabled = true;
			Newswitch.currentplayer = 1;
		}
		yield return new WaitForEndOfFrame();
	}
}
