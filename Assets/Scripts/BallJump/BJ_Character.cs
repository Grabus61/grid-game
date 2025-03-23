using UnityEngine;
using UnityEngine.InputSystem;

public class BJ_Character : StoppablePhysicsObject
{
    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private InputActionReference move;

    [SerializeField] private float jumpSpeed = 10f;

    [SerializeField] private float moveSpeed = 10f;

    Vector2 moveVector;

    bool jumpRequested = false;
    bool canJump = true;

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
        if(context.performed && !stopped){
            jumpRequested = true;
        }
    }

    void Update()
    {
        moveVector = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if(stopped) return;

        //Move
        rb.linearVelocityX = moveVector.x * moveSpeed * GameManager.globalGameSpeed;

        //Jump
        if(jumpRequested && canJump){
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpRequested = false;
            canJump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //On Contact with Ball, Lose
        if(collision.GetComponent<Ball>()){
            GameManager.instance.LoseSingleGame(transform.parent.GetComponent<Game>());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "BJ_Ground"){
            canJump = true;
        }
    }
}
