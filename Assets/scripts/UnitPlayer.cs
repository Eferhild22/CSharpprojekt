using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlayer : MonoBehaviour
{
    private Vector2Int currentPosition;

    private void Start()
{

}
     public Vector2Int GetCurrentPosition()
    {
        return currentPosition;
    }
    public void MoveToPosition(int x, int y)
    {
        transform.position = new Vector3(x, y, 0);
    }
}