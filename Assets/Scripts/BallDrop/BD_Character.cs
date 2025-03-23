using UnityEngine;
using UnityEngine.InputSystem;

public class BD_Character : StoppablePhysicsObject
{
    [SerializeField] private InputActionReference move;
    
    [SerializeField] private float moveSpeed = 10f;

    Vector2 moveVector;

    void Update()
    {
        if(stopped) return;
        
        moveVector = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        rb.linearVelocityX = moveVector.x * moveSpeed * GameManager.globalGameSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<BD_Ball>();
        if(ball){
            ball.ResetWithTimer(0.5f);
        }
    }
}
