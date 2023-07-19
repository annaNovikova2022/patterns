using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Stop,
    Run,
    BackRun
}

public enum MoveState
{
    Forward,
    Back
}
public class InputHandler : MonoBehaviour
{
    public float moveDistance = 10f;
    public GameObject objectTarget;
    public PlayerState _playerState = PlayerState.Stop;
    
    private MoveReceiver _moveReceiver { get; set; }
    public List<ICommand> _commands = new List<ICommand>();
    private int currentCommandNum = 0;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " have " );
    }
    
    
   

    public void Undo()
    {
        if (currentCommandNum < _commands.Count)
        {
            currentCommandNum--;
            ICommand command = _commands[currentCommandNum];
            command.UndoExecute();
            
        }
    }
    

    private void InsertCommand(ICommand command)
    {
        _commands.Insert(currentCommandNum++, command);
    }

    private void Move(MoveDirection direction)
    {
        ICommand command = new MoveCommand(_moveReceiver, direction, moveDistance, objectTarget);
        command.Execute();
        InsertCommand(command);
    }
    
    
    public void MoveUp() {Move(MoveDirection.up);}
    public void MoveDown() {Move(MoveDirection.down);}
    public void MoveLeft() {Move(MoveDirection.left);}
    public void MoveRight() {Move(MoveDirection.right);}

    
    private void Start()
    {
        _moveReceiver = new MoveReceiver();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
            ChangeStatePlayer(PlayerState.Stop, MoveState.Forward);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.W))
        {
            ChangeStatePlayer(PlayerState.Run, MoveState.Forward);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
            ChangeStatePlayer(PlayerState.Stop, MoveState.Back);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow)|| Input.GetKeyUp(KeyCode.S))
        {
            ChangeStatePlayer(PlayerState.Run, MoveState.Back);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
            ChangeStatePlayer(PlayerState.Stop, MoveState.Forward);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.A))
        {
            ChangeStatePlayer(PlayerState.Run, MoveState.Forward);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
            ChangeStatePlayer(PlayerState.Stop, MoveState.Forward);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.D))
        {
            ChangeStatePlayer(PlayerState.Run, MoveState.Forward);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            Undo();
        }
    }

    private void ChangeStatePlayer(PlayerState playerState, MoveState moveState)
    {
       _playerState = (playerState, moveState) switch
        {
            (PlayerState.Stop,MoveState.Forward) => playerState = PlayerState.Run,
            (PlayerState.Stop,MoveState.Back) => playerState = PlayerState.BackRun,
            (PlayerState.Run,MoveState.Forward) => playerState = PlayerState.Stop,
            (PlayerState.Run,MoveState.Back) => playerState = PlayerState.Stop,
            _ => _playerState
        };
    }
}
