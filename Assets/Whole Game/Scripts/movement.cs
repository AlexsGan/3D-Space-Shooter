using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed  = 15;
    public float baseSpeed = 15;
    private float boostSpeed = 30;
    private float boostCooldown = 0;
    private bool boostActive = false;
    private int boostFuel = 100;
    void Update()
    {
        print(boostCooldown);
        if (boostCooldown == 500)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                print("left Shift pressed");
                boostActive = true;
                boostFuel--;
                if (boostFuel != 0)
                {
                    boostNow();
                }
                if (boostFuel == 0)
                {
                    boostActive = false;
                    boostOff();
                    boostCooldown = 0;
                }

            }
            else
            {
              if (boostFuel < 100)
                boostFuel++;
                boostOff();
            }
                
        }
        else
            boostCooldown++;

        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var y = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Translate(y, 0, 0);
        transform.Translate(0, 0, z);
    }
    void boostNow()
    {
        speed = boostSpeed;
    }
    void boostOff()
    {
        speed = baseSpeed;
    }
}