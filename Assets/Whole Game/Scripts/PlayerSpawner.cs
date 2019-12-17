using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSpawner : MonoBehaviour {
    public GameObject player;
    public int SpawnRadius = 20;
    private int limiter = 1;
    public float startTime;
    public Text timerText;
    public static int score = 0;
	// Use this for initialization
	void Start () {
        GameObject Player1;
        Player1 = Instantiate(player);
        Vector3 position = (Random.insideUnitSphere * SpawnRadius);
        Player1.transform.position = position;
        startTime = Time.time;
    }
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;
        string minutes = ((int)(t / 60)).ToString();
        string seconds = (Mathf.Round(t % 60)).ToString();
        timerText.text = minutes + ":" + seconds + " s";
	}
    public static void updateScore(int n)
    {
        score = n;
    }
}

	

