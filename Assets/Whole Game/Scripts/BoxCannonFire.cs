using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCannonFire : MonoBehaviour {

    public GameObject BoxBomb;
    private int counter = 0;
    private int limiter = 0;
    public int maxPop = 20;
    public int spawnRate = 240;
    public int Scale = 0;
    public Transform location;

   // Vector3 num = new Vector3(100, 200, 300);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //if (limiter < maxPop)
        //{
            if (counter < spawnRate)
            {
                counter++;
                //print("counter" + counter);
            }
            if (counter >= spawnRate)
            {
                //float radius = 50;
                //float radius = 70;
                Vector3 centre = Vector3.zero;
                GameObject foodObject;
                foodObject = Instantiate(BoxBomb);
                Vector3 position = (location.position);
                
                foodObject.transform.position = position;
                foodObject.transform.localScale += new Vector3(Scale, Scale, Scale);

                limiter++;
                //print("limiter" + limiter);
                counter = 0;
            }
        //}

    }
    public void foodDestroyed()
    {
        limiter--;
    }
}
