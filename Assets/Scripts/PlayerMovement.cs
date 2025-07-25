using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D myRigidbody;

    Animator animator ;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        FlipSprite();
    }


    void Movement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        myRigidbody.linearVelocity = new UnityEngine.Vector2(moveInput * moveSpeed, myRigidbody.linearVelocity.y);
        animator.SetFloat("Velocity", Mathf.Abs(myRigidbody.linearVelocityX));


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
