using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class DeveloperConsoleBehaviour : MonoBehaviour
{
    [SerializeField] private string prefix = string.Empty;
    [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

    [Header("UI")]
    [SerializeField] private GameObject uiCanvas = null;
    [SerializeField] private TMP_InputField inputfield = null;
    [SerializeField] private TMP_Text textfield = null;
    [SerializeField] private TMP_Text commands_textfield = null;
    [SerializeField] private TMP_Text objects_textfield = null;
    [SerializeField] private TMP_Text behaviours_textfield = null;


    private float pausedTimeScale;

    private static DeveloperConsoleBehaviour instance;

    private DeveloperConsole developerConsole;
    private DeveloperConsole DeveloperConsole
    {
        get
        {
            if (developerConsole != null)
                return developerConsole;

            return developerConsole = new DeveloperConsole(prefix, commands);
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            Debug.Log("\\");
            Toggle();

        }
        if (uiCanvas.activeSelf && Input.GetKeyDown(KeyCode.Return) && inputfield.text != "")
        {
            textfield.text += this.gameObject.name + ": " + inputfield.text + "\n";
            ProcessCommand(inputfield.text);
            inputfield.ActivateInputField();

        }
        else if (uiCanvas.activeSelf && Input.GetKeyDown(KeyCode.UpArrow) && inputfield.text == "")
        {
        }

    }

    public void Toggle()
    {
        if (uiCanvas.activeSelf)
        {
            //Time.timeScale = pausedTimeScale;
            uiCanvas.SetActive(false);
            
        }
        else
        {
            //pausedTimeScale = Time.timeScale;
            //Time.timeScale = 0;
            uiCanvas.SetActive(true);
            inputfield.ActivateInputField();
            UpdateInfo();
        }
    }

    public void UpdateInfo()
    {
        var prefabs1 = Resources.LoadAll<ConsoleCommand>("Commands");
        commands_textfield.text = "";
        for (int i = 0; i < prefabs1.Length; i++)
        {
            commands_textfield.text += prefabs1[i].commandWord + "; ";            
        }

        var prefabs2 = Resources.LoadAll("Behaviours");
        behaviours_textfield.text = "";
        for (int i = 0; i < prefabs2.Length; i++)
        {
            behaviours_textfield.text += prefabs2[i].name + "; ";
        }

        var prefabs3 = Resources.LoadAll<GameObject>("Objects");
        objects_textfield.text = "";
        for (int i = 0; i < prefabs3.Length; i++)
        {
            objects_textfield.text += prefabs3[i].name + "; ";
        }
    }

    public void ProcessCommand(string inputValue)
    {
        DeveloperConsole.ProcessCommand(inputValue);
        inputfield.text = string.Empty;
    }
}
