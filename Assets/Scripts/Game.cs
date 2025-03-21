using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    protected List<IStoppable> stoppableObjects;

    void Awake()
    {
        stoppableObjects = new List<IStoppable>();
    }

    public void AddStoppableObject(IStoppable obj){
        stoppableObjects.Add(obj);
    }
}
