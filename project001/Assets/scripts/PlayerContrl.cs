using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrl : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxSpeed = 50, Moveforce = 100, JumpForce=100;
    private float fInput=0.0f;
    private bool bFaceRight = true;
    private bool bGrounded = false;
    Transform mGroundCheck;
    private bool bJump = false;
    void FixedUpdate()
    {
       
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        //控制移动
        if (fInput * rigidBody.velocity.x < MaxSpeed)
        {
            rigidBody.AddForce(Vector2.right * fInput * Moveforce);
        }
        //限制最大速度
        if (Mathf.Abs(rigidBody.velocity.x) > MaxSpeed)
        {
            rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * MaxSpeed, rigidBody.velocity.y);
        }
        if (bJump)
        {
            rigidBody.AddForce(new Vector2(0f, JumpForce));
            bJump = false;
        }

    }
    void Start()
    {
        mGroundCheck = transform.Find("GroundCheck");

    }

    // Update is called once per frame
    void Update()
    {
        fInput = Input.GetAxis("Horizontal");
        if (fInput > 0 && !bFaceRight)
        {
            flip();
        }
        else if (fInput < 0 && bFaceRight)
        {
            flip();
        }
        bGrounded = Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (bGrounded)
        {
            bJump=Input.GetButtonDown("Jump");

        }
        
    }
    void flip() 
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
         
    }
}
