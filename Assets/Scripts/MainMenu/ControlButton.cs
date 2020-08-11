 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour {


	public GameObject BPlay,BAbout;
	void Update(){

		if (BPlay.GetComponent<Text>().enabled == false)
		{

			SceneManager.LoadScene("Level1");
			
		}
		if (BAbout.GetComponent<Text>().enabled == false)
		{

			SceneManager.LoadScene("About");
			
		}

	}

	public void PlayButton(){

		GameObject.Find("LoadingPlay").GetComponent<Animator>().SetBool("Loading", true);

	}

	public void OptionsButton(){
		


	}

	public void AboutButton(){

		GameObject.Find("LoadingAbout").GetComponent<Animator>().SetBool("Loading", true);

	}

	public void ExitButton(){

		Application.Quit();

	}

}
