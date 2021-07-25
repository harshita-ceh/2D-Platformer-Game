using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float Jump;
   public float crouch;
    private Rigidbody2D rb2D;
    private void Awake()
    {
        Debug.Log("awake");
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    public void PickUpKey()
    {
        Debug.Log("key picked up");
        scoreController.IncreaseScore(10);
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        float crouch = Input.GetAxisRaw("crouch");
        MoveCharacter(horizontal,vertical,crouch);
        PlayMovementAnimation(horizontal,vertical,crouch);
        
    }
    private void MoveCharacter(float horizontal, float vertical, float crouch)
    {
        //horizontal
        if (horizontal != 0)
            {
            Vector3 position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;
            animator.SetBool("isrunning", true);
        }
        else
        {
            animator.SetBool("isrunning", false);
        }
        // vertical
         if (vertical > 0)
        {
           rb2D.AddForce(new Vector2(0f, Jump), ForceMode2D.Force);
        }
        if (crouch > 0)
        {
            rb2D.AddForce(new Vector2(0f, crouch), ForceMode2D.Force);
        }
    }
    private void PlayMovementAnimation(float horizontal, float vertical, float crouch)
    {
        animator.SetFloat("speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        if (crouch > 0)
        {
            animator.SetBool("crouch", true);
        }
        else
        {
            animator.SetBool("crouch", false);
        }
    }
}