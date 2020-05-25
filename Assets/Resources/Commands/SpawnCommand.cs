using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Log Command", menuName = "Utilities/DeveloperConsole/Commands/Spawn Command")]
public class SpawnCommand : ConsoleCommand
{
    public override bool Process(string[] args)
    {
        
        //Debug.Log(args.Length);
        if (args.Length <= 2)
        {
            return false;
        }
        //Debug.Log("Will Read");
        UnityEngine.Object[] prefabs;
        prefabs = Resources.LoadAll("Objects", typeof(GameObject));
        Debug.Log(prefabs.Length);
        //Debug.Log("Its Readed");
        //Debug.Log(prefabs[0].name);

        if (args.Length >= 3)
        {
            GameObject spawned = null;
            Debug.Log("Antes do For");
            for (int i = 0; i < prefabs.Length; i++)
            {
                if (args[0] == prefabs[i].name)
                {
                    spawned = (GameObject)Instantiate(prefabs[i], new Vector3(0, 2, 0), Quaternion.identity);
                    var behaviours = Resources.LoadAll("Behaviours");
                    Debug.Log("Vai entrar no for 2");
                    for (int e = 1; e < args.Length; e++)
                    {
                        Debug.Log("Entrou no for 2");
                        foreach (var item in behaviours)
                        {
                            Debug.Log(item.name);
                            if (args[e] == item.name)
                            {
                                var componente = args[e];//isto é uma string
                                spawned.AddComponent(Type.GetType(componente));
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            if (Int32.TryParse(args[1], out int value))
            {
                GameObject final = spawned.gameObject;
                for (int t = 1; t < value; t++)
                {
                    Instantiate(final, new Vector3(spawned.transform.position.x, spawned.transform.position.y + (5*t), spawned.transform.position.z), Quaternion.identity);
                }
                return true;

            }
        }
        return false;
    }
}
