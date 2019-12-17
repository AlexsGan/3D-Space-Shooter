using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject.Find("HelpMenu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = true;
        GameObject.Find("OptionMenu").GetComponent<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void startGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void help()
    {
        GameObject.Find("HelpMenu").GetComponent<Canvas>().enabled = true;
        GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = false;
    }
    public void option()
    {
        GameObject.Find("OptionMenu").GetComponent<Canvas>().enabled = true;
        GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = false;
    }
    public void backFromHelp()
    {
        GameObject.Find("HelpMenu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("OptionMenu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("MainMenu").GetComponent<Canvas>().enabled = true;
    }
    public void quit()
    {
        Application.Quit();
    }
}
