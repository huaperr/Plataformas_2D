using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class p_movement : MonoBehaviour
{

    public float speed;
    private float Move;

    public float jump;
    bool IsJumping;

    bool isAlive = true;

    bool lookingRight = true;

    
     Rigidbody2D rb;

     Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {

        Move = Input.GetAxis("Horizontal");

        animator.SetFloat("Horizontal", Mathf.Abs(Move));

        if (Input.GetKeyDown(KeyCode.A) && lookingRight == true)
        {
            transform.Rotate(0, -180, 0);
            lookingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && lookingRight == false)
        {
            transform.Rotate(0, -180, 0);
            lookingRight = true;

        }

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && IsJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            animator.SetBool("isJumping", true);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("wall"))
        {
            IsJumping = false;
            animator.SetBool("isJumping", false);
        }

        if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("wall"))
        {
            
            IsJumping = true;
        }
    }
}
