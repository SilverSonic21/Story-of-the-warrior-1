using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

[DisallowMultipleComponent]
public class NewMonoBehaviourScript : MonoBehaviour
{

    public float moveDistance = 1.0f;
    private readonly Stack<ICommand> commandHistory = new Stack<ICommand>();

    public int undoCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ExecuteMoveCommand(Vector3.forward * moveDistance);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
              ExecuteMoveCommand(Vector3.right * -moveDistance);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
              ExecuteMoveCommand(Vector3.forward * -moveDistance);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            ExecuteMoveCommand(Vector3.right * moveDistance);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        Undo();
        
    }

    public void Undo()
    {
        if(commandHistory.Count == 0)
        return;
        ICommand command = commandHistory.Pop();
        command.Undo();
        undoCount--;
    }
    void ExecuteMoveCommand(Vector3 _amount)
    {
        ICommand command = new MoveCommand(transform, _amount);
        command.Execute();
        commandHistory.Push(command);
        undoCount++;
    }
}


public interface ICommand
{
    void Execute();

    void Undo();
}

public class MoveCommand : ICommand
{
    private readonly Action execute;
    private readonly Action undo;
    private Vector3 startingPosition;

    public MoveCommand(Transform _transform, Vector3 _moveAmound)
    {
        execute = () =>
        {
            startingPosition = _transform.position;
            _transform.position += _moveAmound;
        }; 

        undo = () => _transform.position = startingPosition;
    }


    public void Execute()
    {
        execute();
    }

    public void Undo()
    {
        undo();
    }
    
}


#if UNITY_EDITOR

#endif