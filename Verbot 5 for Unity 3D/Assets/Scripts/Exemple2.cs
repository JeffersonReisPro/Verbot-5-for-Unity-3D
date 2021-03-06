﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

/// <summary>
/// Sample application that uses the Verbot 5 Library.
/// </summary>
public class Exemple2 : ScriptTemplateForUI
{

    private VerbotScriptTemplate verbot = new VerbotScriptTemplate();

    // Use this for initialization
    void Start()
    {
        chatTextUI.text = "";
        verbot.StartVerbot();
        string[] PathToVKBs = new string[] {
            Path.Combine(Application.streamingAssetsPath,@"Verbots\Sylvie.vkb")
        };
        verbot.LoadKnowledgeBase(PathToVKBs);

        //Load Brain/memoirs
        verbot.LoadVars("Verbots", "memoirs.dat");
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void OnDisable()
    {
        //Save Brain/memoirs
        verbot.SaveVars("Verbots", "memoirs.dat");
    }


    /// <summary>
    /// /// Send a message to UI
    /// </summary>
    public void SendMessageUI()
    {
        if (string.IsNullOrEmpty(userInput.text) == false)
        {
            SendMessageUI(verbot.GetReply(userInput.text));
        }
    }


}
