using System.Collections.Generic;
using UnityEngine;

public class BJ_BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    private List<GameObject> ballPool;
    [SerializeField] private int poolAmount = 10;

    private float timer = 0f;

    void Start()
    {
        ballPool = new List<GameObject>();

        GameObject tempBall;
        for(int i = 0; i < poolAmount; i++){
            tempBall = Instantiate(ball, transform.position, Quaternion.identity);
            tempBall.SetActive(false);
            ballPool.Add(tempBall);
        }
    }
    void Update()
    {
        if(timer <= 0f){
            GetPooledBall().SetActive(true);
            timer = Random.Range(2, 4);
        }
        else{
            timer -= Time.deltaTime * GameManager.globalGameSpeed;
        }
    }

    private GameObject GetPooledBall(){
        for(int i = 0; i < poolAmount; i++){
            if(!ballPool[i].activeInHierarchy){
                return ballPool[i];
            }
        }

        return null;
    }

    public List<GameObject> GetBallPool(){
        return ballPool;
    }
}
