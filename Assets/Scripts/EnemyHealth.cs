using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int startHealth = 5;
    [SerializeField]
    public int currentHealth;
    public static EnemyHealth instance1;
    public GameObject DeathEffect;
    public bool isEnemyDied = false;

    private void OnEnable()
    {
        currentHealth = startHealth;
    }
    private void Awake()
    {
        instance1 = this;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
       
        if (currentHealth <= 0)
        {
            
                Die();
            
        }
    }
    public void Die()
    {
        //ScoreManager.instance.IncrementScore();
        Instantiate(DeathEffect, this.gameObject.transform.position, Quaternion.identity);
        DeathEffect.gameObject.SetActive(true);
        

        gameObject.SetActive(false);
        //isEnemyDied = true;
        
        
        if (this.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
       

        // enemiesKilled++;
        //print(enemiesKilled);

    }
}