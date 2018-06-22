using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public Button startText;
	public Button exitText;


	// Use this for initialization
	void Start () {
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

	}


	public void StartLevel()
	{
		SceneManager.LoadScene ("GameScene");
	}

	public void ExitGame()
	{
		Application.Quit ();
	}


	// Update is called once per frame
	void Update () {
		
	}
}
