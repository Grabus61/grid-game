using System.Collections.Generic;
using UnityEngine;

public class Spawner : StoppableObject
{
    [SerializeField] private GameObject spawnObj;

    private List<GameObject> PooledSpawnObj;

    [SerializeField] private int poolAmount = 10;

    [SerializeField] private float width;
    [SerializeField] private float height;

    [SerializeField] private float minSpawnTime = 2.0f;
    [SerializeField] private float maxSpawnTime = 4.0f;

    private float timer = 0f;

    void Awake()
    {
        PooledSpawnObj = new List<GameObject>();

        GameObject tempBall;
        for(int i = 0; i < poolAmount; i++){
            tempBall = Instantiate(spawnObj, new Vector2(transform.position.x + Random.Range(-width/2,width/2), transform.position.y + Random.Range(-height/2,height/2)), Quaternion.identity, transform);
            tempBall.SetActive(false);
            PooledSpawnObj.Add(tempBall);
        }
    }
    void Update()
    {
        if(stopped) return;
        
        //Spawn Cycle
        if(timer <= 0f){
            GameObject ball = GetPooledBall();
            ball.SetActive(true);
            ball.transform.position = new Vector2(transform.position.x + Random.Range(-width/2,width/2), transform.position.y + Random.Range(-height/2,height/2));
            timer = Random.Range(minSpawnTime, maxSpawnTime);
        }
        else{
            timer -= Time.deltaTime * GameManager.globalGameSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(width, .25f));
    }

    //Returns first inactive (usable) pool object
    private GameObject GetPooledBall(){
        for(int i = 0; i < poolAmount; i++){
            if(!PooledSpawnObj[i].activeInHierarchy){
                return PooledSpawnObj[i];
            }
        }

        return null;
    }

    public override void Stop()
    {
        base.Stop();

        foreach(GameObject obj in PooledSpawnObj){
            obj.GetComponent<IStoppable>().Stop();
        }
    }

    public override void Continue()
    {
        base.Continue();
        foreach(GameObject obj in PooledSpawnObj){
            obj.GetComponent<IStoppable>().Continue();
        }
    }
}
