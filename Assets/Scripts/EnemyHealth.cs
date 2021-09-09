using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int startHealth = 5;
    [SerializeField]
    public int currentHealth;
    public int enemiesKilled = 0;
   // public ParticleSystem enemyParticle;
    public static EnemyHealth instance;

    public void Awake()
    {
        instance = this;

    }

    private void OnEnable()
    {
        currentHealth = startHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        
        //gameObject.SetActive(false);
        Destroy(this.gameObject);
        if (this.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
       
            enemiesKilled++;
            print(enemiesKilled);
        
      

    }
}
