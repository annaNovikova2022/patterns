using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float moveDistance = 10f;
    public GameObject objectTarget;
    
    private MoveReceiver _moveReceiver { get; set; }
    public List<ICommand> _commands = new List<ICommand>();
    private int currentCommandNum = 0;

    private void Start()
    {
        _moveReceiver = new MoveReceiver();

        if (objectTarget == null)
        {
            Debug.LogError("Error objTarget");
            enabled = false;
        }
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

    public void Redo()
    {
        if (currentCommandNum < _commands.Count)
        {
            ICommand command = _commands[currentCommandNum];
            currentCommandNum++;
            command.Execute();
            
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

    private void OnGUI()
    {
        string label = "  start";
        if (currentCommandNum ==0)
        {
            label = ">" + label;
        }

        label += "\n";

        for (int i = 0; i < _commands.Count; i++)
        {
            if (i == currentCommandNum-1)
                label += "> " + _commands[i].ToString() + "\n";
            else
                label += " " + _commands[i].ToString() + "\n";
        }
        
        GUI.Label(new Rect(0,0,400,800), label);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Redo();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Undo();
        }
    }
}
