using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement: MonoBehaviour {


    public float MoveSpeed;
    [Range(0f,10f)]
    public float jumpSpeed;
    public float fallSpeed;


    bool jumpRequest = false;
    public static bool isGrounded;

    Vector2 overlapBoxPos;
    public Vector2 overlapBoxPositionOffset;
    public Vector2 overlapBoxSize;
    public LayerMask overlapBoxMask;

    Rigidbody2D RB;
    Animator anim;


    void Start () {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anim.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
            anim.SetTrigger("isJumping");
        }
    }


    void FixedUpdate()
    {
        overlapBoxPos = (Vector2)transform.position + overlapBoxPositionOffset;

        if (jumpRequest)
        {
            RB.AddForce(Vector2.up * jumpSpeed , ForceMode2D.Impulse);
            jumpRequest = false;
            isGrounded = false;
        }
        else
        {
            isGrounded = Physics2D.OverlapBox(overlapBoxPos, overlapBoxSize, 0f, overlapBoxMask) != null;
        }

        if(RB.velocity.y < 0)
        {
            RB.gravityScale = fallSpeed;
        }
        else
        {
            RB.gravityScale = 1;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(overlapBoxPos, overlapBoxSize);
    }

}
