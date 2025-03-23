using UnityEngine;

public class BC_Ball : Ball
{
    [SerializeField] private float speed = 2f;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.AddForce(randomDirection * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = rb.linearVelocity.normalized * speed * GameManager.globalGameSpeed;
    }
}
