using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour {
    public int health = 1000;
    public GUIText scoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bullet")
        {
            health -= 5;
            checkHealth();
        }
    }
    void checkHealth()
    {
        if (health <= 0)
        {
        }
    }
    void printHealth()
    {

    }
}
