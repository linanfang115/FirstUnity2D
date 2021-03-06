using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D Rb;

    public float MoveForce = 50f;
    public float fInputx, fInputy;
    public float MaxSpeed = 10f;
    public float JumpForce = 100f;

    private bool bFaceRight = true;
    private bool bGrounded = false;
    private bool bJump = false;

    Transform mGroundCheck;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        fInputy = Input.GetAxis("Vertical");
        fInputx = Input.GetAxis("Horizontal");
        
        if(fInputx>0 && !bFaceRight)
         {
             Flip();
         }
         else if(fInputx<0 && bFaceRight)
         {
             Flip();
         }

        bGrounded=Physics2D.Linecast(this.transform.position,mGroundCheck.position,1<<LayerMask.NameToLayer("Ground"));



        if(Input.GetKey(KeyCode.Space)&& bGrounded)
        {
            bJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(Rb.velocity.x) < MaxSpeed)
        {
            Rb.AddForce(MoveForce * Vector2.right * fInputx);
        }

        if (Mathf.Abs(Rb.velocity.x) > MaxSpeed)
        {
            Rb.velocity = new Vector2(Mathf.Sign(Rb.velocity.x) * MaxSpeed, Rb.velocity.y);
        }

        /*if (Mathf.Abs(Rb.velocity.y) < MaxSpeed)
        {
            Rb.AddForce(Vector2.up * MoveForce * fInputy);
        }

        if (Mathf.Abs(Rb.velocity.y) > MaxSpeed)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, Mathf.Sign(Rb.velocity.y) * MaxSpeed);
        }*/


        if (bJump)
        {
            Rb.AddForce(new Vector2(0f, JumpForce));
            bJump = false;
        }

    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }

    
}
