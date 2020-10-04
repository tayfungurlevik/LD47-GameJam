using UnityEngine;

public class Command : MonoBehaviour, ICommand
{
    [SerializeField]
    private int index;
    [SerializeField]
    private bool moveForward;
    [SerializeField]
    private bool turnLeft;
    [SerializeField]
    private bool turnRight;
    public int Index { get => index; set => index=value; }
    public bool MoveForward { get => moveForward; set => moveForward = value; }
    public bool TurnLeft { get => turnLeft; set => turnLeft = value; }
    public bool TurnRight { get => turnRight; set => turnRight=value; }
}
