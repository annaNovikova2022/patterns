using UnityEngine;

public enum MoveDirection{ up, down, left, right};

public class MoveCommand : ICommand
{
    private MoveDirection _direction { get; set; }
    private MoveReceiver _receiver { get; set; }
    private float _distance { get; set; }
    private GameObject _gameObject { get; set; }

    public MoveCommand(MoveReceiver receiver, MoveDirection direction, float distance, GameObject gameObjectToMove)
    {
        _receiver = receiver;
        _direction = direction;
        _distance = distance;
        _gameObject = gameObjectToMove;
    }
    
    public void Execute()
    {
        _receiver.MoveOperation(_gameObject, _direction, _distance);
    }

    public void UndoExecute()
    {
        _receiver.MoveOperation(_gameObject, InverseDirection(_direction), _distance);
    }
    private MoveDirection InverseDirection(MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.up:
                return MoveDirection.down;
            case MoveDirection.down:
                return MoveDirection.up;
            case MoveDirection.left:
                return MoveDirection.right;
            case MoveDirection.right:
                return MoveDirection.left;
            default:
                Debug.Log("Error move");
                return MoveDirection.down;
            
        }
    }

    public override string ToString()
    {
        return "MoveCommand: " + MoveDirectionString(_direction) + " : " + _distance.ToString();
    }

    public string MoveDirectionString(MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.up:
                return "up";
            case MoveDirection.down:
                return "down";
            case MoveDirection.left:
                return "left";
            case MoveDirection.right:
                return "right";
            default:
                return "unkown";
        }
    }

}