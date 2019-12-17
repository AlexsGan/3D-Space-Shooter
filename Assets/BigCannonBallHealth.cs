using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCannonBallHealth : MonoBehaviour
{

    public int cannonBallHealth = 70;
    private Transform player;
    public float movementSpeed = 10f;
    public int Xpearned = 10;
    void start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }
    void update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        //if (dist <= 40)
        //{
        transform.LookAt(player);
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
        //}
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHit>().GainXp(Xpearned);
            Destroy(other.gameObject);
            cannonBallHealth -= 10;
        }

        if (other.gameObject.CompareTag("Cube"))
        {
            Destroy(other.gameObject);
            cannonBallHealth -= 10;
        }

        if (other.gameObject.CompareTag("Cannon"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (cannonBallHealth <= 0)
        {

            Destroy(gameObject);
        }
    }//end OnTriggerEnter method
}
