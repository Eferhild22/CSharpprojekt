using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlayer : MonoBehaviour
{
    /// <summary>
    /// Gets Player's world position
    /// </summary>
    /// <returns></returns>
    public Vector2Int GetPosition()
    {
        return new Vector2Int((int)transform.position.x, (int)transform.position.y);
    }
    /// <summary>
    /// Gets Player's position in relation to the cursor
    /// </summary>
    /// <returns></returns>
    public Vector2Int GetConvertedPosition()
    {
        return new Vector2Int((int)transform.position.x * -1, (int)transform.position.y);
    }
    public void MoveToPosition(int x, int y)
    {
        transform.position = new Vector3(-x, y, -0.5f);
    }
}