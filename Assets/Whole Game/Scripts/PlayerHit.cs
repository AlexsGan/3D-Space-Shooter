using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour {
    public int MaxHealth = 100;
    public int playerHealth = 100;
    private int level = 0;
    public Text LevelNum;
    private int Exp;
    private float currentMax = 25;
    public Slider healthSlider;
    public Text HpAmount;
    public Slider XP;
    public Text XpAmount;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0, 1f);
    public Color flashColourlight = new Color(1f, 0f, 1f);
    public GameObject middleCannon;
    public GameObject LeftCannon;
    public GameObject RightCannon;
    public AudioSource ShootingAudio;
    public AudioClip HitClip;
    public AudioClip LostClip;

    private void Start()
    {
        XpAmount.text = ("0/" + currentMax);
        HpAmount.text = (playerHealth + "/" + MaxHealth);
        LevelNum.text = ("0");
        Cursor.visible = false;
    }

    private void Update()
    {
        XP.value = Exp;
        XP.maxValue = currentMax;
        healthSlider.value = playerHealth;
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        if (Exp >= currentMax)
        {
            currentMax *= 2;
            XP.maxValue *= 2f;
            level++;
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>().levelChange(level);
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<QuadSpawner>().levelChange(level);
            MaxHealth += 10;
            playerHealth += 10;
            if (level == 4) 
                doubleCannons();
            if (level == 7)
                TrippleCannons();
           
        }
        LevelNum.text = (level+"");
        XpAmount.text = (Exp+"/" + currentMax);
        HpAmount.text = (playerHealth + "/" + MaxHealth);
        if (playerHealth > MaxHealth)
            playerHealth = MaxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            Destroy(other.gameObject);
            playerHealth -= 10;
        }
        if (other.gameObject.CompareTag("Cannon"))
        {
            playerHealth -= 70;
        }
        if (other.gameObject.CompareTag("CannonBall"))
        {
            ShootingAudio.clip = HitClip;
            ShootingAudio.Play();
            playerHealth -= 20;
            damageImage.color = flashColour;
        }
        if (other.gameObject.CompareTag("MiniCannonBall"))
        {
            ShootingAudio.clip = HitClip;
            ShootingAudio.Play();
            playerHealth -= 4;
            damageImage.color = flashColour;
        }
        if (other.gameObject.CompareTag("BigCannonBall"))
        {
            ShootingAudio.clip = HitClip;
            ShootingAudio.Play();
            playerHealth -= 60;
            damageImage.color = flashColour;
        }
        if (other.gameObject.CompareTag("Pellet"))
        {
            playerHealth -= 1;
            damageImage.color = flashColourlight;
        }
        if (playerHealth <= 0)
        {
            Cursor.visible = true;
            Destroy(gameObject);

            SceneManager.LoadScene("LostScene");
        }
    }//end OnTriggerEnter method
    public void Heal()
    {
        playerHealth += 25;
        HpAmount.text =(playerHealth+"/"+MaxHealth);
    }
    public void GainXp(int amount)
    {
        
        Exp += amount;
        
    }
    public void doubleCannons()
    {
        middleCannon.SetActive(false);
        LeftCannon.SetActive(true);
        RightCannon.SetActive(true);
    }
    public void TrippleCannons()
    {
        middleCannon.SetActive(true);
        LeftCannon.SetActive(true);
        RightCannon.SetActive(true);
    }
}
