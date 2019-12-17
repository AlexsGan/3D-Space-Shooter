using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodecahedronSpawner : MonoBehaviour {
public GameObject food;
private int counter;
public int limiter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (limiter <= 30)
        {
            if (counter < 10)
            {
                counter++;
                print("counter"+counter);
            }
            if (counter >= 10)
            {
                Instantiate(food);
                food.transform.position = Random.insideUnitSphere * 60;
                limiter++;
                print("limiter" + limiter);
                counter = 0;
            }
        }

	}
    public void foodDestroyed()
    {
        limiter--;
        print("food destroyed");
    }
    
}
