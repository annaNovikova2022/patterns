using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackState : IPlayerState
{
    public MoveDirection _moveDirection { get; set; }

    public MoveBackState()
    {
        _moveDirection = MoveDirection.down;
    }
    public void StringState()
    {
        Debug.Log("Move back");
    }
}
