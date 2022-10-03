using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    private int playerIndex;
    public GameObject character1;
    public GameObject character2;
    public void SetPlayerTurn(int index)
    {
        playerIndex = index;
    }

    public bool IsPlayerTurn()
    {
        return TurnManager.GetInstance().IsItPlayerTurn(playerIndex);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            bool IsPlayerTurn = playerTurn.IsPlayerTurn();
            if (IsPlayerTurn)
            {
                TurnManager.GetInstance().TriggerChangeTurn();
                //character1.GetComponent<WeaponRaycast>().enabled = false;
                //character2.GetComponent<WeaponRaycast>().enabled = true;

            }
        }
    }
}
