using UnityEngine;

public class StopState : IPlayerState
{
    public MoveDirection _moveDirection { get; set; }
    public StopState()
    {
        _moveDirection = MoveDirection.stop;
    }
    public void StringState()
    {
        Debug.Log("stop");
    }
}
