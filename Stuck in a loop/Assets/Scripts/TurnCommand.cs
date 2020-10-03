using System.Collections;
using System.Windows.Markup;
using UnityEditor.Timeline;
using UnityEngine;

public class TurnCommand : MonoBehaviour, ICommand
{
    [SerializeField]
    private int amount;
    public int Amount { get => amount; set => amount = value; }

    [SerializeField]
    private int index;
    [SerializeField]
    private float rotationStep = 5.0f;
    [SerializeField]
    private float timeStep = 0.01f;
    private Transform robotTransform;
    private bool commandTurn;
    float currentRotation = 0f;
    Quaternion desiredRotation;
    private float delta;
    private void Start()
    {
        robotTransform = FindObjectOfType<RobotController>().GetComponent<Transform>();
        
        delta = currentRotation - amount;
    }
    public int Index { get => index; set => index = value; }
    public bool CommandTurn { get => commandTurn; set => commandTurn = value; }

    public IEnumerator Execute()
    {
        desiredRotation = robotTransform.rotation * Quaternion.Euler(0, amount, 0);
        while (commandTurn && Mathf.Abs(delta) > 0.1f)
        {
            



            robotTransform.Rotate(new Vector3(0, rotationStep, 0) * timeStep);
            currentRotation += rotationStep * timeStep;
            delta = currentRotation - amount;
            yield return new WaitForSeconds(timeStep);



        }
        commandTurn = false;
        robotTransform.rotation = desiredRotation;
        
    }

}
