using UnityEngine;
public class SyncronousTimer
{
    private float timeout;
    private float startTime;
    public SyncronousTimer(float timeout)
    {
        this.timeout = timeout;
        Reset();
    }

    public bool IsDone()
    {
        return startTime + timeout < Time.time;
    }

    public void Reset()
    {
        startTime = Time.time;
    }
}