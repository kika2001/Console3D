using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Types : MonoBehaviour
{
    public string comp;


    public bool custom;
    // Start is called before the first frame update
    void Start()
    {
        if (custom)
        {
            gameObject.AddComponent(Type.GetType($"UnityEngine.{comp}, UnityEngine"));
            return;
        }

        gameObject.AddComponent(Type.GetType(comp));
    }
}
