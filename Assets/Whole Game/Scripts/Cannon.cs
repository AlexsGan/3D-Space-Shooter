using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{

    public int cannonHealth = 300;
    public int movementSpeed = 7;
    private int turnSpeed = 5;
    private Transform player;
    private Transform food;
    public Slider cannonHealthSlider;
    private bool playerHit = false;
    public int Xpearned = 15;

    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").transform;
        food = GameObject.FindGameObjectWithTag("Cube").transform;
        transform.rotation = Random.rotation;
    }
    void Update()
    {
    //cannonHealthSlider.value = cannonHealth;
    GameObject[] all = GameObject.FindGameObjectsWithTag("Cannon");
        GameObject[] gos1 = new GameObject[all.Length - 1];
        int index = 0;
        for (int i = 0; i < all.Length; i++)
        {
            if (all[i] == this.gameObject)
                continue;

            gos1[index] = all[i];
            index++;
        }
        GameObject closestE = null;
        float distanceE = Mathf.Infinity;
        Vector3 positionE = transform.position;
        foreach (GameObject go in gos1)
        {
            Vector3 diff = go.transform.position - positionE;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distanceE)
            {
                closestE = go;
                distanceE = curDistance;
            }
        }
        GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Cube");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= 60 && dist >= 10)
        {
            transform.LookAt(player);
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (dist <= 9.9999)
        {
            transform.LookAt(player);
            transform.position += transform.right * Time.deltaTime * turnSpeed;
        }
        else if (distanceE <= 40 && distanceE >=20)
        {
                transform.LookAt(closestE.transform);
                transform.position += transform.forward * Time.deltaTime * turnSpeed;
        }
        else if (distanceE <= 19.9999)
        {
                transform.LookAt(closestE.transform);
                transform.position += transform.right * Time.deltaTime * movementSpeed;
                transform.position += -transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (distance <= 40)
        {
                transform.LookAt(closest.transform);
                transform.position += transform.right * Time.deltaTime * turnSpeed;
        }
        else if (distance>=40)
        {
                transform.LookAt(closest.transform);
                transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cannonHealth -= 90;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            cannonHealth -= 25;
            playerHit = true;
            
        }
        if (other.gameObject.CompareTag("CannonBall"))
        {
            cannonHealth -= 300;
        }
        if (cannonHealth <= 0)
        {
            if (playerHit)
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHit>().GainXp(Xpearned);
            GameObject.Find("SpawnManager").GetComponent<EnemySpawner>().foodDestroyed();
            Destroy(gameObject);
        }
    }
}
