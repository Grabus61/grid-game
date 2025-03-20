using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float globalGameSpeed = 2f;
    [SerializeField] private float gameSpeedAddition = 0.2f;

    private float defaultGlobalGameSpeed = 2f;

    private int gameChangeCounter = 0;

    [SerializeField] private Game[] gameList;

    private float timer = 2f;

    void Awake()
    {
        globalGameSpeed = defaultGlobalGameSpeed;
    }

    void Update()
    {
        if(timer <= 0f){
            globalGameSpeed += gameSpeedAddition;
            timer = 2f;
            Debug.Log(globalGameSpeed);
        }
        else{
            timer -= Time.deltaTime;
        }
    }

}
