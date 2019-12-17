using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text Score;
    // Use this for initialization
    void Start()
    {
        //Score.text = PlayerHit.XP.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void toMainMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    public void tryAgain()
    {
        
        SceneManager.LoadScene("MainScene");
    }
}
