using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float maxSpeed = 10f;

    public bool grounded;

    public float jumpPower = 13f;

    public float jumpPowerEnemy = 9f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;
    private bool jumpEnemy=false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed",Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            jump = true;
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);

        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        
        if (h > 0.1f)
        {
            transform.localScale = new Vector3(9f,9f,9f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-9f, 9f, 9f);
        }

        if (jump == true)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        if ( jumpEnemy == true)
        {

            rb2d.AddForce(Vector2.up * jumpPowerEnemy, ForceMode2D.Impulse);
            jumpEnemy = false;
        }

    }

    public void enemyJump()
    {
        jumpEnemy = true;
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        jumpEnemy = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.left * side * jumpPowerEnemy, ForceMode2D.Impulse);

        
    }
    
}
