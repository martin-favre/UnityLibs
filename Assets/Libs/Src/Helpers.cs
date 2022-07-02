using System;
using UnityEngine;

public static class Helpers
{
    public static void DoForAll(Vector2Int size, Action<Vector2Int> action)
    {
        DoForAll(Vector2Int.zero, size, action);
    }

    public static void DoForAll(Vector2Int offset, Vector2Int size, Action<Vector2Int> action)
    {
        for (int y = offset.y; y < size.y; y++)
        {
            for (int x = offset.x; x < size.x; x++)
            {
                action(new Vector2Int(x, y));
            }
        }
    }

    // chance is probability 0->1
    public static bool ThingHappens(float probability)
    {
        return UnityEngine.Random.Range(0, 1) < probability;
    }
}
