using UnityEngine;

public class BJ_BallReset : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BJ_Ball"){
            collision.GetComponent<BJ_Ball>().Reset();
        }
    }
}
