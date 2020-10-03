using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class RobotController : MonoBehaviour
{

    private List<ICommand> commands;

    private void Start()
    {
        
    }
    public void PlayRobot()
    {
        TakeCommands();
        StartCoroutine( ExecuteCommands ());
    }
    private IEnumerator ExecuteCommands()
    {
        var orderedCommands = commands.OrderBy(t => t.Index);

        foreach (var item in orderedCommands)
        {
            item.CommandTurn = true;
            StartCoroutine(item.Execute());
            yield return new WaitForSeconds(3.0f);
            StopCoroutine(item.Execute());
        }
    }

    private void TakeCommands()
    {
        commands = new List<ICommand>();
        var moveCommands = FindObjectsOfType<MoveCommand>().ToList<ICommand>();
        var turnCommands = FindObjectsOfType<TurnCommand>().ToList<ICommand>();
        commands.AddRange(moveCommands);
        commands.AddRange(turnCommands);
            
    }
}
