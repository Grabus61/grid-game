using UnityEngine;

public class BallJumpGame : Game
{
    public void ContinueGame(){
        foreach(IStoppable obj in stoppableObjects){
            obj.Continue();
        }
    }

    public void StopGame(){
        foreach(IStoppable obj in stoppableObjects){
            obj.Stop();
        }
    }
}
