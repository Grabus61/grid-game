using UnityEngine;

public class BJ_Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float ballSpeed = 2.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        rb.linearVelocityX = ballSpeed * GameManager.globalGameSpeed;

        if(transform.position.y < -10){
            gameObject.SetActive(false);
        }
    }

    private void Reset()
    {
        transform.position = transform.parent.position;
    }
}
