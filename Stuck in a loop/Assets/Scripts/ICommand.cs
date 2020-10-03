using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  interface ICommand
{
    
    int Index { get; set; }
    int Amount { get; set; }
    bool CommandTurn { get; set; }
    IEnumerator Execute();
}
