using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
   public Dictionary<MoveDirection,IPlayerState> _playerStates = new Dictionary<MoveDirection, IPlayerState>();

   public PlayerState()
   {
      IPlayerState state = new MoveState();
      _playerStates.Add(state._moveDirection,state);
      
      state = new MoveBackState();
      _playerStates.Add(state._moveDirection,state);
      
      state = new StopState();
      _playerStates.Add(state._moveDirection,state);
   }

   public IPlayerState ChangeMove(MoveDirection moveDirection)
   {
      _playerStates[moveDirection].StringState();
      return _playerStates[moveDirection];
      /*switch (moveDirection)
      {
         case MoveDirection.down: 
            _playerStates[moveDirection].StringState();
            return _playerStates[moveDirection];
         case MoveDirection.up: 
            _playerStates[moveDirection].StringState();
            return _playerStates[moveDirection];
         default: return null;
      }*/
   }
}
