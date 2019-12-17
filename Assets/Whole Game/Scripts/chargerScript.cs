using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerScript : MonoBehaviour
{
    // Use this for initialization
    public float grow = 2f;
    public float spin = 10f;
    private float counter=0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.localScale += new Vector3(grow, grow, grow);
        transform.Rotate(spin, spin, spin);
       
        

    }
}
