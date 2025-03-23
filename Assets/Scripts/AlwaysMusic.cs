using UnityEngine;

public class AlwaysMusic : MonoBehaviour
{
    public static AlwaysMusic instance;
    void Start()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this){
            Destroy(gameObject);
        }
    }
}
