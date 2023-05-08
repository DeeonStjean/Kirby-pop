using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 15;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 100.0f;
    [SerializeField] bool isGrounded = true;

    public ProjectileBehavior ProjectilePrefab;
    public Transform LanchOffset;

    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
    }


    // Update is called once per frame --used for user input
    //do NOT use for physics & movement
    void Update(){
        //input for player movement
        movement = Input.GetAxis("Horizontal");
        
        //input for player to jump
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
        
        //input for player to shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefab, LanchOffset.position, transform.rotation);
        }
    }
    private void FixedUpdate(){
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
        else
        {
            jumpPressed = false;
            if (isGrounded)
            {
                if (movement > 0 || movement < 0)
                {
                    animator.SetBool("Run", true);
                }
                else
                {
                    animator.SetBool("Run", false);
                }
            }
        }
    }
    private void Flip()
    {
        //character can turn around and face the other direction
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        animator.SetBool("Jump", true);
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        Debug.Log("jumped");
        jumpPressed = false;
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
        }
        else
            Debug.Log(collision.gameObject.tag);
    }
}
