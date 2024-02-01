using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float baseJumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] int jumpNumber;
    
    public Transform bottomPoint;
    public LayerMask groundLayer;

    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(speed * horizontal * Time.deltaTime,0,0),Space.World);

    }

    private void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCapsule(bottomPoint.position, new Vector2(1, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (isGrounded)
        {
            jumpNumber = 2;
            jumpForce = baseJumpForce;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpNumber > 1)
        {
            if (jumpNumber == 2)
            {
                Debug.Log("Jumped once.");
            }
            else if (jumpNumber == 1)
            {
                Debug.Log("double jump");
                //rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce/2);
            }
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            jumpNumber -= 1;
        }
    }

}
