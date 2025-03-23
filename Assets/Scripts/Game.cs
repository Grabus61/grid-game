using Unity.Cinemachine;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] protected StoppableObject[] stoppableObjects;

    [SerializeField] protected CinemachineCamera cam;

    [SerializeField] protected SpriteRenderer background;

    [HideInInspector] public bool lost = false;

    public virtual void ContinueGame(){
        foreach(StoppableObject obj in stoppableObjects){
            if(obj.gameObject.activeInHierarchy){
                obj.Continue();
            }
        }
    }

    public virtual void StopGame(){
        foreach(StoppableObject obj in stoppableObjects){
            if(obj.gameObject.activeInHierarchy){
                obj.Stop();
            }
        }
    }

    public CinemachineCamera GetGameCamera(){
        return cam;
    }

    public void Lose(){
        background.color = Color.gray;
        lost = true;
    }
}
