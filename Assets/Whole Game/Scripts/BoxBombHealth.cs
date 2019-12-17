using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBombHealth : MonoBehaviour {

    public int boxBombHealth = 40;
    private Transform player;
    public float movementSpeed = 15f;

    private void start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= 40)
        {
            transform.LookAt(player);
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
    }

        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxBombHealth -= 40;
        }

        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            boxBombHealth -= 20;
        }

        if (other.gameObject.CompareTag("Cube"))
        {
            Destroy(other.gameObject);
            boxBombHealth -= 10;
        }

        if (other.gameObject.CompareTag("Cannon"))
        {
            //cannonBallHealth -= 70;
        }

        if (boxBombHealth <= 0)
        {
            Destroy(gameObject);
        }
    }//end OnTriggerEnter method
}
