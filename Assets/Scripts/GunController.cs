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
    public static GunController instance;
    public int score=0;
    public int enemiesKilled;
    public GameObject HealthRed;
    public int num;
    

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
        
        
    }

   
    private void FireGun()
    {

        FindObjectOfType<AudioManager>().PlayAudio("Shoot");
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue, 2f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
          //  audioSource.clip = audioClip;
          
            Instantiate(HealthRed, hit.collider.gameObject.transform.position, Quaternion.identity);
            //Debug.Log(hit.collider.gameObject.name);
            
           HitMarkerManager.hitinstance.instancePoint = hit.point;
            HitMarkerManager.hitinstance.SpawnMarker();
            var enemyhealth = hit.collider.gameObject.GetComponent<EnemyHealth>();
           
            if (enemyhealth != null)
            {
                enemyhealth.TakeDamage(damage);

            }
            if(hit.collider.gameObject.tag=="enemy")
            {
                if (enemyhealth.currentHealth <= 0)
                {
                    score+=100;
                    enemiesKilled++;
                    if(enemiesKilled>=num)
                    {
                        SceneManager.LoadScene(4);
                    }
                    print(score);
                }
            }
        }
       
    }
   
}