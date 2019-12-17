using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealStarScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHit>().Heal();
            Destroy(gameObject);
            GameObject.Find("SpawnManager").GetComponent<foodSpawner1>().foodDestroyed();
        }
    }
}
