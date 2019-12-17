using UnityEngine;
using System.Collections;

public class rotatearound : MonoBehaviour
{

    GameObject cube;
    public Transform center;
    public Vector3 axis = Vector3.right;
    public Vector3 desiredPosition;
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;
    private float movementSpeed = 20;

    void Start()
    {
        cube = GameObject.FindWithTag("Player");
        center = cube.transform;
        transform.position = (transform.position - center.position).normalized * radius + center.position;
        radius = 2.0f;
    }

    void Update()
    {
        float dist = Vector3.Distance(cube.transform.position, transform.position);
        if (dist < 10)
        {
            transform.LookAt(cube.transform);
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
            desiredPosition = (transform.position - center.position).normalized * radius + center.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        }
    }
}