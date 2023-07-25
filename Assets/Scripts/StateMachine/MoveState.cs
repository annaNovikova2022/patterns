using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IPlayerState
{
    public MoveDirection _moveDirection { get; set; }
    
    public MoveState()
    {
        _moveDirection = MoveDirection.up;
    }
    public void StringState()
    {
        Debug.Log("Move forward");
    }
}
