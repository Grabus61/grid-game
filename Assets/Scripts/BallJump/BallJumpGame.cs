using System.Collections.Generic;
using UnityEngine;

public class BallJumpGame : Game
{
    [SerializeField] private List<Rigidbody2D> objects;

    [SerializeField] private BJ_BallSpawner ballSpawner;

    void Start()
    {
        foreach(GameObject obj in ballSpawner.GetBallPool()){
            objects.Add(obj.GetComponent<Rigidbody2D>());
        }
    }

    public void ContinueGame(){
        foreach(Rigidbody2D rb in objects){
            rb.simulated = true;
        }
    }

    public void StopGame(){
        foreach(Rigidbody2D rb in objects){
            rb.simulated = false;
        }
    }
}
