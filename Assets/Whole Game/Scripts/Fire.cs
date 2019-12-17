using UnityEngine;
using System.Collections;
 
public class Fire : MonoBehaviour
{
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    private float Bullet_Forward_Force = 100.0f;
    public float speed = 100.0f;
    public static int attackspeed = 10;
    private int counter = attackspeed;
    public float falloff = 3f;
    public AudioSource ShootingAudio;        
    public AudioClip FireClip;               

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (counter < attackspeed)
        {
            counter++;
           // print(counter);
        }
        else
        {
            if (Input.GetKey("space"))
            {
                ShootingAudio.clip = FireClip;
                ShootingAudio.Play();
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
                Temporary_RigidBody.AddForce(Bullet_Emitter.transform.forward * Bullet_Forward_Force * speed);
                Destroy(Temporary_Bullet_Handler, falloff);
                counter = 0;
            }
            if (Input.GetMouseButton (0))
            {
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                Temporary_Bullet_Handler.transform.Rotate(Vector3.right * 90);
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
                Temporary_RigidBody.AddForce(Bullet_Emitter.transform.forward * Bullet_Forward_Force * speed);
                Destroy(Temporary_Bullet_Handler, falloff);
                counter = 0;
            }
        }
    }
}