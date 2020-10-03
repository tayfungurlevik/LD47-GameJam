using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using UnityEngine;

public class MoveCommand : MonoBehaviour,ICommand
{
    [SerializeField]
    private int amount;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeStep = 0.01f;
    public int Amount { get => amount; set => amount = value; }
    [SerializeField]
    private int index;
    public int Index { get => index; set => index = value; }
    private bool commandTurn;
    private Transform robotTransform;
    private Vector3 desiredPosition;
    private float delta;
    public bool CommandTurn { get => commandTurn; set => commandTurn = value; }
    private void Start()
    {
        robotTransform = FindObjectOfType<RobotController>().GetComponent<Transform>();
        
        delta = Vector3.Distance(robotTransform.position, desiredPosition);
    }
    public IEnumerator Execute()
    {
        desiredPosition = robotTransform.position + robotTransform.forward.normalized * amount;
        while (commandTurn&& Mathf.Abs(delta) > 0.1f)
        {
            delta = Vector3.Distance(robotTransform.position, desiredPosition);
            
            robotTransform.Translate(robotTransform.forward.normalized * speed * timeStep);
            yield return new WaitForSeconds(timeStep);
            
        }
        commandTurn = false;
        robotTransform.position = desiredPosition;
        
    }
    


}
