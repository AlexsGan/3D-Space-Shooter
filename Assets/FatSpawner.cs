using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatSpawner : MonoBehaviour
{
    public GameObject food;
    private int counter;
    private int limiter = 0;
    public int maxPop = 20;
    public int spawnRate = 120;
    public int Scale = 0;

    Vector3 num = new Vector3(100, 200, 300);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (counter < spawnRate)
        {
            counter++;
            //print("counter" + counter);
        }
        if (counter >= spawnRate)
        {
            float radius = 160;
            //float radius = 70;
            Vector3 centre = Vector3.zero;
            GameObject foodObject;
            foodObject = Instantiate(food);
            Vector3 position = (Random.insideUnitSphere * radius);
            foodObject.transform.position = position;
            foodObject.transform.localScale += new Vector3(Scale, Scale, Scale);

            limiter++;
            //print("limiter" + limiter);
            counter = 0;
        }


    }
    public void foodDestroyed()
    {

        print("food destroyed");
    }
}
