using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float speed = 5f;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.left * speed );

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);

        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x > 0.1f && rb2d.velocity.x < -0.1f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        
        if (speed > 0.1f)
        {
            transform.localScale = new Vector3(9f, 9f, 9f);
        }
        else
        {
            if (speed < 0.1f)
            {
                transform.localScale = new Vector3(-9f, 9f, 9f);
            }
        }
        

    }
    
    void OnCollisionEnter2D(Collision2D col)
    {

        
        if (col.otherCollider.tag == "wall" || col.collider.tag=="wall" || col.gameObject.tag=="wall")
        {
            speed = -speed;

            transform.localScale = new Vector3(-rb2d.transform.localScale.x, 9f, 9f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yOffset = 1.4f;

            if(transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("enemyJump");
                Destroy(gameObject);
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }

            
        }
    }
}
