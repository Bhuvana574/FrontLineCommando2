using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour
{
    [Range(0, 2)]
    [SerializeField] float fireRate = 1f;
    [SerializeField]
    [Range(1, 10)]
    int damage = 1;
    [SerializeField] float timer;
    [SerializeField] Transform firePoint;
    public ParticleSystem particleSyste;
    [SerializeField]
   public int TotalEnemies = 4;
    public static GunController instance;
    
    public void Awake()
    {
        instance = this;
        }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
               
                timer = 0f;
                FireGun();
                particleSyste.Play();
            }
            
        }
        if (TotalEnemies == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

   
    private void FireGun()
    {

        
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue, 2f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            //Debug.Log(hit.collider.gameObject.name);
            var enemyhealth = hit.collider.gameObject.GetComponent<EnemyHealth>();
            if (enemyhealth != null)
            {
                enemyhealth.TakeDamage(damage);
            }
           
            
        }
    }
}