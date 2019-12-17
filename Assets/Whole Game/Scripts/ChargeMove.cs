using System.Collections.Generic;
using UnityEngine;

public class ChargeMove : MonoBehaviour {
    private int counter = 0;
    private int cooldown = 180;
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public GameObject chargingBullet;
    private float Bullet_Forward_Force = 100.0f;
    private float speed = 10f;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (cooldown == 180)
        {
            if (Input.GetMouseButton(0))
            {
                counter++;
                print("charging"+counter);
                if (counter == 1)
                {
                    GameObject Temporary_Bullet_Handler;
                    Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                    Temporary_Bullet_Handler.transform.parent = GameObject.Find("Speedy ship").transform;
                    Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
                    Destroy(Temporary_Bullet_Handler, 3f);
                }

                if (counter == 180)
                {
                    GameObject Temporary_Bullet_Handler;
                    Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                    Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
                    Rigidbody Temporary_RigidBody;
                    Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
                    Temporary_RigidBody.AddForce(-transform.forward * Bullet_Forward_Force * speed);
                    Destroy(Temporary_Bullet_Handler, 3f);
                    counter = 0;
                    cooldown = 0;
                   
                }

            }
            else if (Input.GetMouseButtonUp(0))
            {
                counter = 0;
            }
        }
        else
        {
            cooldown++;
            print(cooldown);
        }
	}
    void createFake()
    {

    }
}
