using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsoleCommand : ScriptableObject,IConsoleCommand
{
    public string commandWord = string.Empty;

    public string CommandWord => commandWord;

    public abstract bool Process(string[] args);
}
