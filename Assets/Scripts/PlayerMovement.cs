using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed; // allowing to edit in unity 
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        // gets reference for rigidbody and animator from object 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }

    private void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // flips player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        //set animator parameters
        anim.SetBool("run", horizontalInput != 0);
    }
}
