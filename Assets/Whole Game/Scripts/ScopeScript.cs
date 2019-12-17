using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeScript : MonoBehaviour {
    private float baseFOV = 80;
    private bool toggle;
    public GameObject Canvas;
    // Use this for initialization
    void Start () {
		  {

        baseFOV = Camera.main.fieldOfView;
    }

	}

    // Update is called once per frame
    void Update()
    {
        if (!toggle)
        {
            if (Input.GetMouseButtonDown(1))
                zoom();
        }

        else
            if (Input.GetMouseButtonUp(1))
            {
                zoomOut();
            }
    }
    void zoom()
    {
        toggle = true;
       Canvas.SetActive(true);
        Camera.main.fieldOfView = 10;
        Camera.main.transform.Translate(0, -1f, 0);
        Camera.main.transform.Rotate(-20, 0, 0);
    }
    void zoomOut()
    {
        toggle = false;
        Camera.main.fieldOfView = baseFOV;
        Canvas.SetActive(false);
        Camera.main.transform.Rotate(20, 0, 0);
        Camera.main.transform.Translate(0, 1f, 0);
        
        
    }
   
}
