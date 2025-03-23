using UnityEngine;

public class LoseZone : MonoBehaviour
{
    [SerializeField] private Game game;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if(ball){
            GameManager.instance.LoseSingleGame(game);
        }
    }
}
