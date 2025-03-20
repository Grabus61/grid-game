using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BJ_Character : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private InputActionReference move;

    [SerializeField] private float jumpSpeed = 10f;

    [SerializeField] private float moveSpeed = 10f;

    Vector2 moveVector;

    bool jumpRequested = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        jumpButton.action.performed += JumpButtonPressed;
    }

    void OnDisable()
    {
        jumpButton.action.performed -= JumpButtonPressed;
    }

    private void JumpButtonPressed(InputAction.CallbackContext context)
    {
        if(context.performed){
            jumpRequested = true;
        }
    }

    void Update()
    {
        moveVector = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        //Move
        rb.linearVelocityX = moveVector.x * moveSpeed;

        //Jump
        if(jumpRequested){
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpRequested = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //On Contact with Ball, Lose
        if(collision.tag == "BJ_Ball"){
            //Lose
            Destroy(gameObject);
        }
    }
}
