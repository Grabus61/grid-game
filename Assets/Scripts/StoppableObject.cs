using UnityEngine;

public class StoppableObject : MonoBehaviour, IStoppable
{
    [SerializeField] protected Game game;
    protected bool stopped;

    private void Start()
    {
        game.AddStoppableObject(this);    
    }

    public virtual void Stop()
    {
        stopped = true;
    }

    public virtual void Continue()
    {
        stopped = false;
    }
}
