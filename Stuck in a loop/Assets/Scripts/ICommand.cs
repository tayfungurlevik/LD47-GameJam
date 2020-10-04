using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  interface ICommand
{
    
    int Index { get; set; }
    bool MoveForward { get; set; }

    bool TurnLeft { get; set; }
    bool TurnRight { get; set; }
}
