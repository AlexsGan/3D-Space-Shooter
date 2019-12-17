using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColission : MonoBehaviour
{
    public int health = 10;
    public int rotation;

    // Use this for initialization
    void Start()
    {
        rotation = Random.Range(-50, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(Vector3.right * Time.deltaTime* rotation);
        transform.Rotate(Vector3.up * (Time.deltaTime* rotation));

        if (health <= 0)
        {
            GameObject.Find("SpawnManager").GetComponent<foodSpawner1>().foodDestroyed();
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            health -= 10;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHit>().GainXp(5);
        }

        if (other.gameObject.tag == "CannonBall")
        {
            health -= 5;
            Destroy(other.gameObject);
        }
            
    }
}

