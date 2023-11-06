using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed_, jumpHeight = 5.0f;
    private bool isGrounded_;

    float VelX_;
    Rigidbody2D rb;
    Animator anim_;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim_ = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            Debug.Log("space key was pressed");
        }
        FlipCharacter();
        /* Jump(); */
        Movement();
        
    }
    

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            Debug.Log("space key was pressed");
        }
    }

    public void FlipCharacter()
    {
        if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);

        }
    }

    public void Movement()
    {
        VelX_ = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(VelX_ * speed_, 0.0f);

        if(rb.velocity.x != 0)
        {
            anim_.SetBool("walk",true);
        }else
        {
            anim_.SetBool("walk",false);
        }
    }

}


