using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace CustomNPCHitPhrases;

[BepInPlugin("CustomNPCHitPhrases", "Custom NPC Hit Phrases", "1.0.1")]
public class CustomNPCHitPhrases : BaseUnityPlugin
{
    private bool Visible = true;
    public static ConfigEntry<string> NotificationMessages;
    private Harmony Harmony;

    public void Awake()
    {
        Harmony = new("CustomNPCHitPhrases");
        Logger.LogInfo("Custom NPC Hit Phrases Loaded!");
        Harmony.PatchAll();
        NotificationMessages = Config.Bind("Misc", "Notification Messages", "Example1, Example2, Example3", "Custom NPC hit phrases! Seperate them by commas");

    }

    public void OnDestroy()
    {
        Logger.LogInfo("Custom NPC Hit Phrases Unloaded!");
        Harmony.UnpatchAll();
    }

    public void OnGUI()
    {
        if (!Visible) return;
        GUI.skin.box.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 100, 500, 200), "");
        GUI.skin.button.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 90, 500, 30), "Custom NPC Hit Phrases Notification");
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 60, 500, 100), "You have to edit the config and restart the game for this to work!");
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 60, 100, 30), "Okay!")) Visible = false;
    }
}