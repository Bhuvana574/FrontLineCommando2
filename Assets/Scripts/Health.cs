using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
   public  int startHealth = 5;
    public int currentHealth;
    public GameObject DeathEffect;
    public static Health healthinstance;
    private void Start()
    {
     
        healthinstance = this;
        Time.timeScale = 1;
        currentHealth = startHealth;
        HealthManager.instance.HealthSlider.value = startHealth;

    }

    private void OnEnable()
    {
        currentHealth = startHealth;

    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
      //  ScoreManager.Scoreinstance.updateHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
       HealthManager.instance.HealthSlider.maxValue = currentHealth;
       //HealthManager.instance.healthText.text = "Health" + currentHealth;
    }
    private void Die()
    {
        Instantiate(DeathEffect, this.gameObject.transform.position, Quaternion.identity);
       DeathEffect.gameObject.SetActive(true);
        Time.timeScale = 0;

        if (this.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
    }
}