using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    [SerializeField]
    float jumpForce = 3000;
    Rigidbody2D rBody;
    bool hasReleasedJumpButton = true;
    
    
    [SerializeField]
    Transform feet;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    float groundRadius = 0.2f;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform shotPosition;
    bool isGrounded;
    
    [SerializeField]
    float dashspeed;
    

    float shotTimer = 0;
    [SerializeField]
    float TimeBetweenShots = 0.5f;

    bool IsGrounded;
    float upSpeed;
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
       
        if(IsGrounded)
        {
            upSpeed = 500f;
        }
        // Debug.DrawLine(Vector2.zero, Vector2.down * 8, Color.green);

        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveX, 0) * speed * Time.deltaTime;

        transform.Translate(movement);

        isGrounded = Physics2D.OverlapCircle(feet.position, groundRadius, groundLayer);

        Debug.Log(isGrounded);
        if(Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton == true && isGrounded)
        {
            Debug.Log("JUMP!");
            rBody.AddForce(Vector2.up * jumpForce);
            hasReleasedJumpButton = false;
        }

        if(Input.GetAxisRaw("Jump") == 0)
        {
        hasReleasedJumpButton = true;
        }

        shotTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1")> 0  && shotTimer > TimeBetweenShots)
        {
        Instantiate(bulletPrefab, shotPosition.position, Quaternion.identity);
        shotTimer = 0;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            // rBody.AddForce(Vector2.x * dashspeed);
        }
        
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        if(Collision.gameObject.tag == "tramp" &&  IsGrounded == false
            )
        {
            upSpeed += 400f;
            if (upSpeed>= 1200f)
            {
                upSpeed = 1200f;
            }
            rBody.AddForce(new Vector2(0,upSpeed));
        }

        if(Collision.gameObject.tag == "Blade")
        {
            Destroy(this.gameObject);

        }

        if(Collision.gameObject.tag == "DeathPoint")
        {
            transform.position = new Vector3(-7.6f, 0.8f, 0f);
        }
    }
    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.green;
        // Gizmos.DrawWireSphere(Vector2.zero, 1);
        // Gizmos.DrawWireCube(Vector2.zero, Vector2.one);

        if (feet)
        {
            Gizmos.DrawWireSphere(feet.position, groundRadius);
        }
    }
}


