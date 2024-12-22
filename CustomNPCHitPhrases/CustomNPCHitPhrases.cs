using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace CustomNPCHitPhrases;

[BepInPlugin("CustomNPCHitPhrases", "Custom NPC Hit Phrases", "1.0.0")]
public class CustomNPCHitPhrases : BaseUnityPlugin
{
    public static ConfigEntry<string> NotificationMessages;
    private Harmony Harmony;

    public void Awake()
    {
        Harmony = new("CustomNPCHitPhrases");
        Logger.LogInfo("Custom NPC Hit Phrases Loaded!");
        Harmony.PatchAll();
        NotificationMessages = Config.Bind("Misc", "Notification Messages", "Example1, Example2, Example3", "NPC hit hrases! Seperate them by commas");
    }

    public void OnDestroy()
    {
        Logger.LogInfo("Custom NPC Hit Phrases Unloaded!");
        Harmony.UnpatchAll();
    }
}
