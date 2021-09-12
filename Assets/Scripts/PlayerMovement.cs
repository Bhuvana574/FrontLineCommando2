using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float playerSpeed;
    public float backSpeed;
    public float turnSpeed,jumpForce;
    Animator anim;
    public int score;
    public static PlayerMovement instance;
   


    private void Awake()
    {
       
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        instance = this;
    }
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);
        anim.SetFloat("Speed", vertical);
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        if (vertical != 0)
        {
            float moveSpeed = (vertical > 0) ? playerSpeed : backSpeed;
            characterController.SimpleMove(transform.forward * vertical * moveSpeed);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
        }


    }
    public void OnTriggerEnter(Collider other)
    {
        /*if(other.gameObject.tag=="player")
        {
            Destroy(gameObject);
        }*/
        if (other.gameObject.CompareTag("Health"))
        {

            Destroy(other.gameObject);
           HealthManager.instance.HealthSlider.value = Health.healthinstance.startHealth;
            //.instance.healthText.text = "Health" + Health.instance.currentHealth;
        }

    }
}
