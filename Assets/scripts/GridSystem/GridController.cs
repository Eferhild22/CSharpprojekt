using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] GameObject gridPrefab;
    [SerializeField] private GridMovement gridMovement;
    [SerializeField] private UnitPlayer character1;
    [SerializeField] private int number = 20;
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Vector2Int newStartPosition;
    private Vector2Int currentSelectionPosition;

    bool hasSelectedPlayer = false;

    private void Start()
    {
        for (int x = 0; x < number; x++)
        {
            for (int y = 0; y < number; y++)
            {
                GameObject grid = Instantiate(gridPrefab) as GameObject;
                grid.transform.position = new Vector3(-x, y, 0f);
            }
        }
    }
    private void Update()
    {
        //bool IsPlayerTurn = playerTurn.IsPLayerTurn();

        //if (IsPlayerTurn)
        
            if (!gridMovement.IsMoving())
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (currentSelectionPosition.y < number - 1)
                    {
                        currentSelectionPosition.y += 1;
                        gridMovement.MoveToPosition(Vector3.up);
                    }
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (currentSelectionPosition.y > 0)
                    {
                        currentSelectionPosition.y -= 1;
                        gridMovement.MoveToPosition(Vector3.down);
                    }
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (currentSelectionPosition.x < number - 1)
                    {
                        currentSelectionPosition.x += 1;
                        gridMovement.MoveToPosition(Vector3.left);
                    }
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (currentSelectionPosition.x > 0)
                    {
                        currentSelectionPosition.x -= 1;
                        gridMovement.MoveToPosition(Vector3.right);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ProcessSelection();
                }
            }
    }
    private void ProcessSelection()
    {
        if (hasSelectedPlayer)
        {
            character1.MoveToPosition(currentSelectionPosition.x, currentSelectionPosition.y);
            hasSelectedPlayer = false;
            //character1.Position
        }
        else
        {
            if (currentSelectionPosition == character1.GetCurrentPosition())
            {
                hasSelectedPlayer = true;
            }
        }
    }
}