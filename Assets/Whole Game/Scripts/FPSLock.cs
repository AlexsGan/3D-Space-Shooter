using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour {
    public int FPSLimit = 75;
    void Awake()
    {
        Application.targetFrameRate = FPSLimit;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
