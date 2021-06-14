using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Ability")]
    public bool allowExtraJump;
    public bool allowGliding;
    public bool allowDynamicJump;

    [Header("Extra Jump")]
    public int extraJumps;
    public int extraJumpsValue;
    [Header("Dynamic Jump")]
    public float dynamicJumpMultiplier = 0.5f;

    [Header("Velocity")]
    public float speed;
    public float jumpForce;
    private float moveInput;

    [Header("Jump state")]
    private bool facingRight = true;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    [Header("Jump Optimization")]
    public float offGroundTime = 0.2f;
    public float offGroundTime_t;
    
    
    void Start()
    {
        if (allowExtraJump == false)
        {
            extraJumpsValue = 0;
        }
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(Vector2.left * speed);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(Vector2.right * speed);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    //rb.AddForce(Vector2.left * speed);
        //    rb.velocity = new Vector2(0, rb.velocity.y);
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    //rb.AddForce(Vector2.right * speed);
        //    rb.velocity = new Vector2(0, rb.velocity.y);
        //}

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Update()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
            offGroundTime_t = 0;
        }
        if(!isGrounded)
        {
            offGroundTime_t += Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            if(offGroundTime_t >= offGroundTime)
            {
                //Small jump
                rb.velocity = Vector2.up * jumpForce * 0.7f;
                AudioManager.instance.Play(SoundList.Jump);
                extraJumps--;
            }
            else
            {
                //big jump
                AudioManager.instance.Play(SoundList.Jump);
                rb.velocity = Vector2.up * jumpForce;
            }
        } else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && offGroundTime_t <= offGroundTime)
        {
            AudioManager.instance.Play(SoundList.Jump);
            rb.velocity = Vector2.up * jumpForce;
        }
        if(allowDynamicJump)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (rb.velocity.y > 0)
                {
                    AudioManager.instance.Play(SoundList.Jump);
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * dynamicJumpMultiplier);
                }
            }
        }
        //Jump straight down from platforms
        //if(Input.GetKeyDown(KeyCode.S) && isGrounded)
        //{
        //    StartCoroutine(FallTimer());
        //}
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    //IEnumerator FallTimer()
    //{
    //    GetComponent<Collider2D>().enabled = false;
    //    yield return new WaitForSeconds(0.35f);
    //    GetComponent<Collider2D>().enabled = true;
    //}
}
