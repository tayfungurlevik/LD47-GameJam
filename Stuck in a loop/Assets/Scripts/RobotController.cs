using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotController : MonoBehaviour
{

    private List<Command> commands;
    private List<Command> orderedCommands;
    private bool moveForward;
    [SerializeField]
    private float moveSpeed=1.0f;
    private Command currentCommand;
    private int commandIndex=0;
    private float roadTaken = 0;
    public static event Action OnReset = delegate { };
    private void Start()
    {
        commands = new List<Command>();
    }
    public void PlayRobot()
    {
        TakeCommands();
        SortCommands();
        currentCommand = orderedCommands[commandIndex];
    }
    public void ResetCommands()
    {
        commands.Clear();
        commandIndex = 0;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        OnReset?.Invoke();
    }
    private void SortCommands()
    {
         orderedCommands = commands.OrderBy(t => t.Index).ToList();
        
    }

    private void TakeCommands()
    {
        
        var givenCommands = FindObjectsOfType<Command>().ToList();
        commands.AddRange(givenCommands);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (commands.Count > 0&&commandIndex<orderedCommands.Count)
        {
            //If there is at least one command
            
            if (currentCommand.MoveForward)
            {
                if (roadTaken<1.0f)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    roadTaken += (transform.forward * moveSpeed * Time.deltaTime).magnitude;
                }
                else
                {
                    roadTaken = 0;
                    //Debug.Log("Tamamlanan komut index=" + commandIndex);
                    commandIndex++;
                    if (commandIndex<orderedCommands.Count)
                    {
                        currentCommand = orderedCommands[commandIndex];
                        return;
                    }
                    else
                    {
                        commandIndex = 0;
                        currentCommand = orderedCommands[commandIndex];
                        return;
                    }
                    

                }
            }
            if (currentCommand.TurnRight)
            {
                transform.Rotate(transform.up,90);
                //Debug.Log("Tamamlanan komut index=" + commandIndex);
                commandIndex++;
                if (commandIndex < orderedCommands.Count)
                {
                    currentCommand = orderedCommands[commandIndex];
                    return;
                }
                else
                {
                    commandIndex = 0;
                    currentCommand = orderedCommands[commandIndex];
                    return;
                }

            }
            if (currentCommand.TurnLeft)
            {
                transform.Rotate(transform.up, -90);
                //Debug.Log("Tamamlanan komut index=" + commandIndex);
                commandIndex++;
                if (commandIndex < orderedCommands.Count)
                {
                    currentCommand = orderedCommands[commandIndex];
                    return;
                }
                else
                {
                    commandIndex = 0;
                    currentCommand = orderedCommands[commandIndex];
                    return;
                }

            }
            


        }
    }
}
