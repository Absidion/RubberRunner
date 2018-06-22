using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public Font Neon80sFont;
    private int FontSize = Screen.width / 22;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUIStyle KillsStyle = new GUIStyle();
        KillsStyle.fontSize = FontSize;
        KillsStyle.font = Neon80sFont;
        KillsStyle.normal.textColor = Color.red;

        GUIStyle ScoreStyle = new GUIStyle();
        ScoreStyle.fontSize = FontSize;
        ScoreStyle.font = Neon80sFont;
        ScoreStyle.normal.textColor = Color.white;

		GUI.Label(new Rect(10, 10, 30, 60), PlayerController.kills.ToString(), KillsStyle);
        GUI.Label(new Rect(Screen.width - (FontSize * 4.5f), 10, 30, 60), "Score:" + PlayerController.score.ToString(), ScoreStyle);
    }
}
