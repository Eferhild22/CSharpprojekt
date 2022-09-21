using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    public bool IsMoving()
    { return isMoving; }
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.1f;
    [SerializeField]
    private float moveDistance = 1f;

    public void MoveToPosition(Vector3 direction)
    {

            StartCoroutine(MovePlayer(direction*moveDistance));
    }
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;
        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos,(elapsedTime/timeToMove));
            elapsedTime+=Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;

    }
}
