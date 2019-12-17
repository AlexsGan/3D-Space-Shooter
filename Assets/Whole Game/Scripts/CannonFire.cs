using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour
{
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    private float Bullet_Forward_Force = 100.0f;
    public float speed = 100.0f;
    public int attackspeed = 50;
    public int counter = 50;
    private Transform player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
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
        
        if (dist <=40)
            if (counter < attackspeed)
            {
                counter++;
            }
            else
            {
                Fire();
            }
        if (distanceE <= 70)
            if (counter < attackspeed)
            {
                counter++;
            }
            else
            {
                Fire();
            }
        if (distance <= 40)
            if (counter < attackspeed)
            {
                counter++;
            }
            else
            {
                Fire();
            }
    }


    void Fire()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        Temporary_RigidBody.AddForce(Bullet_Emitter.transform.forward * Bullet_Forward_Force * speed);
        Destroy(Temporary_Bullet_Handler, 3.0f);
        counter = 0;
    }
}