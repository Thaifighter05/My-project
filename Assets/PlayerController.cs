using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        // Debug.DrawLine(Vector2.zero, Vector2.down * 8, Color.green);

        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveX, 0) * speed * Time.deltaTime;

        transform.Translate(movement);

        bool isGrounded = Physics2D.OverlapCircle(feet.position, groundRadius, groundLayer);

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


