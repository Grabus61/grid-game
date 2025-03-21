using UnityEngine;

public class BJ_Ball : StoppablePhysicsObject
{
    [SerializeField] private float ballSpeed = 2.0f;

    private void FixedUpdate() {
        rb.linearVelocityX = ballSpeed * GameManager.globalGameSpeed;
    }

    public void Reset()
    {
        transform.position = transform.parent.position;
        gameObject.SetActive(false);
    }
}
