using UnityEngine;

public class BallReset : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();
        if(ball){
            ball.Reset();
        }
    }
}
