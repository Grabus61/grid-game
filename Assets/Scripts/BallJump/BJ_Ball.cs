using UnityEngine;

public class BJ_Ball : Ball
{
    [SerializeField] private float ballSpeed = 2.0f;

    private void FixedUpdate() {
        rb.linearVelocityX = ballSpeed * GameManager.globalGameSpeed;
    }
}
