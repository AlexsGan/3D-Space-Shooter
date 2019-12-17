using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingBallSpin : MonoBehaviour {
    // Use this for initialization
    public float grow = 2f;
    public float spin = 10f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // transform.localScale += new Vector3(grow, grow, grow);
        transform.Rotate(spin, spin, spin);
	}
}
