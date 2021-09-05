using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float playerSpeed;
    public float backSpeed;
    public float turnSpeed;
    Animator anim;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
      
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

    }
   
}
