using UnityEngine;

//Base stoppable object class
public class StoppableObject : MonoBehaviour, IStoppable
{
    protected bool stopped;

    public virtual void Stop()
    {
        stopped = true;
    }

    public virtual void Continue()
    {
        stopped = false;
    }
}
