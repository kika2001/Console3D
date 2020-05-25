using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Log Command", menuName ="Utilities/DeveloperConsole/Commands/Log Command")]
public class LogCommand : ConsoleCommand
{
    public override bool Process(string[] args)
    {
        string logtText = string.Join(" ", args);

        Debug.Log(logtText);
        return true;

    }
}
