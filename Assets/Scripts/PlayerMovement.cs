using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    CapsuleCollider2D playerCollider;
    public LayerMask whatIsGround;
    private Rigidbody2D myRigidbody;

    Animator animator ;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Movement();
        FlipSprite();
        Jump();
    }

    private bool isGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast
        (
            playerCollider.bounds.center,
            playerCollider.bounds.size,
            0f,
            UnityEngine.Vector2.down,
            extraHeight,
            whatIsGround
        );
        return raycastHit.collider != null;
     }

    void Movement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        myRigidbody.linearVelocity = new UnityEngine.Vector2(moveInput * moveSpeed, myRigidbody.linearVelocity.y);
        animator.SetFloat("Velocity", Mathf.Abs(myRigidbody.linearVelocityX));
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            myRigidbody.linearVelocity = new UnityEngine.Vector2(myRigidbody.linearVelocity.x,jumpForce);
        }

     }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocityX) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new UnityEngine.Vector2(Mathf.Sign(myRigidbody.linearVelocityX), 1f);
        }
        ;
    }
}
