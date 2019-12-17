using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCannon : MonoBehaviour {

    public int boxCannonHealth = 400;
    public int movementSpeed = 10;
    private Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            boxCannonHealth -= 90;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            boxCannonHealth -= 25;
        }
        if (other.gameObject.CompareTag("CannonBall"))
        {
            boxCannonHealth -= 50;
        }
        if (boxCannonHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
