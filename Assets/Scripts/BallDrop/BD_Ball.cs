using UnityEngine;

public class BD_Ball : Ball
{
    [SerializeField] private float fastDropTimer = 1f;
    [SerializeField] private float fasterGravityScale = 1f;

    void Update()
    {
        if(stopped) return;

        if(fastDropTimer < 0f){
            rb.gravityScale = fasterGravityScale * GameManager.globalGameSpeed;
        }
        else{
            fastDropTimer -= Time.deltaTime;
        }
    }
}
