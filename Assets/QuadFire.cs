using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadFire : MonoBehaviour {
    public Transform c1;
    public Transform c2;
    public Transform c3;
    public Transform c4;
    public GameObject Bullet;
    private float Bullet_Forward_Force = 100.0f;
    public float speed = 100.0f;
    public int attackspeed = 50;
    public int counter = 50;
    private Transform player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(player.position, transform.position);
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
        if (dist <= 40)
            
                if (counter == 0)
                    Fire1();
                if (counter == 15)
                    Fire2();
                if (counter == 30)
                    Fire3();
                if (counter == 45)
                    Fire4();
                if (counter == 60)
                    counter = 0;
            
        if (distanceE <= 30)
        {
            if (counter == 0)
                Fire1();
            if (counter == 15)
                Fire2();
            if (counter == 30)
                Fire3();
            if (counter == 45)
                Fire4();
            if (counter == 60)
                counter = 0;
        }
        else if (distance <= 40)
        {
            if (counter == 0)
                Fire1();
            if (counter == 15)
                Fire2();
            if (counter == 30)
                Fire3();
            if (counter == 45)
                Fire4();
            if (counter == 60)
                counter = 0;
        }
        print(counter);

    }
  void Fire1()
{
    GameObject Temporary_Bullet_Handler;
    Temporary_Bullet_Handler = Instantiate(Bullet, c1.transform.position, c1.transform.rotation) as GameObject;
    Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
    Rigidbody Temporary_RigidBody;
    Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
    Temporary_RigidBody.AddForce(c1.transform.forward * Bullet_Forward_Force * speed);
    Destroy(Temporary_Bullet_Handler, 1.0f);
    counter = 0;
}
    void Fire2()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, c2.transform.position, c2.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(c2.transform.forward * Bullet_Forward_Force * speed);
        Destroy(Temporary_Bullet_Handler, 1.0f);
        counter = 0;
    }
    void Fire3()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, c3.transform.position, c3.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(c3.transform.forward * Bullet_Forward_Force * speed);
        Destroy(Temporary_Bullet_Handler, 1.0f);
        counter = 0;
    }
    void Fire4()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, c4.transform.position, c4.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(c4.transform.forward * Bullet_Forward_Force * speed);
        Destroy(Temporary_Bullet_Handler, 1.0f);
        counter = 0;
    }

}
  

