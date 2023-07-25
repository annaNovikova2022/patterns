using System.Collections.Generic;
using UnityEngine;



public class InputHandler : MonoBehaviour
{
    public float moveDistance = 1f;
    public GameObject objectTarget;

    private IPlayerState _playerState = new StopState();
    private PlayerState _playerStateList = new PlayerState();
    
    private MoveReceiver _moveReceiver { get; set; }
    public List<ICommand> _commands = new List<ICommand>(10);
    private int currentCommandNum = 0;
    
    public InputHandler(){}

    public InputHandler(GameObject target, float moveDist)
    {
        objectTarget = target;
        moveDistance = moveDist;
    }
    
    
    public void Undo()
    {
        if (_commands.Count==0)
        {
            return;
        }
        foreach (ICommand command in _commands)
        {
             command.UndoExecute();
        }
        _commands.Clear();
    }
    

    private void InsertCommand(ICommand command)
    {
        if (_commands.Count == 10) _commands.RemoveAt(0);
        _commands.Add(command);
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
        objectTarget = GameEventSetting.player;
        moveDistance = GameEventSetting.moveDistance;
        _moveReceiver = new MoveReceiver();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
            _playerState = _playerStateList.ChangeMove(MoveDirection.up);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.W))
        {
            _playerState = _playerStateList.ChangeMove(MoveDirection.stop);
        }
        
        else if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
            _playerState = _playerStateList.ChangeMove(MoveDirection.down);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow)|| Input.GetKeyUp(KeyCode.S))
        {
            _playerState = _playerStateList.ChangeMove(MoveDirection.stop);
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        
        else if (Input.GetKeyDown(KeyCode.U))
        {
            Undo();
        }
    }
    
}
