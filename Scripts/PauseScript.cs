using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

    public PlayerController player;
    public GameObject GameOver;
    private Canvas pauseCanvas;
    int killCount;

    private string PrimaryArticle;
    private string SecondaryArticle;

    // Use this for initialization
    void Start () {
        killCount = PlayerPrefs.GetInt("Kills");
        ShowSplash();
    }
	
	// Update is called once per frame
	void Update () {

        
    }

    public void ShowSplash()
    {
        killCount = PlayerPrefs.GetInt("Kills");
        randomArticle();
        string textobj = "";
        if (killCount <= 0)
            textobj = killCount + " Killed In Freak Tire Accident";
        if (killCount > 0 && killCount < 10)
            textobj = killCount + " Killed, Prank Gone Wrong!";
        if (killCount > 10 && killCount < 20)
            textobj = "Tire Killing Spree, " + killCount + " Killed!";
        if (killCount > 20 && killCount < 40)
            textobj = "Police: " + killCount + " Dead. Suspect Copy Cat Attacks";
        if (killCount > 40 && killCount < 80)
            textobj = "Deaths Reach " + killCount + ". Premier Promises to Stop Tire Attacks";
        if (killCount > 80 && killCount < 160)
            textobj = "Trudeau Offers Sympathies To Victim Families. Tire Kill Count Now " + killCount;
        if (killCount > 160)
            textobj = "Tires Now Banned Across Nation After " + killCount + " Dead.";
        gameObject.transform.Find("PrimaryTitle").GetComponent<Text>().text = textobj;
        gameObject.transform.Find("DuplicateTitle").GetComponent<Text>().text = SecondaryArticle;
    }

    public void Continue()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().Reset();
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
    }

    private void randomArticle()
    {
        int randNum = Random.Range(1, 5);
        switch (randNum)
        {
            case 1:
                SecondaryArticle = "'Cage Cage', Puts You In Cage, Forces You to Watch Nicolas Cage.";
                break;
            case 2:
                SecondaryArticle = "Deer Wins Slap Fight";
                break;
            case 3:
                SecondaryArticle = "Best Man Left Bleeding After Cake Attack.";
                break;
            case 4:
                SecondaryArticle = "Egyptian Man Names Son Instagram.";
                break;
            case 5:
                SecondaryArticle = "One Armed Man Applauds Strangers.";
                break;
            default:
                SecondaryArticle = "Psychics Predict World Didn't End Yesterday.";
                break;
        }
    }
}
