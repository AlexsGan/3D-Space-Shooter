using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTrajectory : MonoBehaviour {
public float speed = 6f;
	// Use this for initialization
	void Start () {
        movement();
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void movement()
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.up * speed;
        print("fired");

        // Destroy the bullet after 2 seconds
        Destroy(gameObject, 2.0f);
    }
}
