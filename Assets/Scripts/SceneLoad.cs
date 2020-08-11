using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {


	public GameObject CanvasPause;
	void Update () {

		if (GameObject.Find("Batang").GetComponent<MeshRenderer>().enabled != true)
		{

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
			
		}

	}

	public void OnPauseClick(){

		Time.timeScale = 0;
		CanvasPause.SetActive(true);

	}

	public void OnMainMenuClick(){

		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");

	}

	public void OnresumeClick(){

		Time.timeScale = 1;
		CanvasPause.SetActive(false);

	}


}
