using System.Collections;
using UnityEngine;

public class Ball : StoppablePhysicsObject
{
    public void Reset()
    {
        transform.position = transform.parent.position;
        gameObject.SetActive(false);
    }

    public void ResetWithTimer(float duration)
    {
        StartCoroutine(ResetCoroutine(duration));
    }

    private IEnumerator ResetCoroutine(float duration){
        yield return new WaitForSeconds(0.6f);
        Reset();
    }
}
