using UnityEngine;

public class StoppablePhysicsObject : StoppableObject
{
    protected Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Stop()
    {
        base.Stop();
        rb.simulated = false;
    }

    public override void Continue(){
        base.Continue();
        rb.simulated = true;
    }
}
