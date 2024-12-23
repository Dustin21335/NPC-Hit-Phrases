using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace NPCHitPhrases;

[BepInPlugin("NPCHitPhrases", "NPC Hit Phrases", "1.0.1")]
public class NPCHitPhrases : BaseUnityPlugin
{
    public static ConfigEntry<string> NotificationMessages;
    private Harmony Harmony;

    public void Awake()
    {
        Harmony = new("NPCHitPhrases");
        Logger.LogInfo("NPC Hit Phrases Loaded!");
        Harmony.PatchAll();
        NotificationMessages = Config.Bind("Misc", "Notification Messages", "Example1, Example2, Example3", "NPC hit phrases! Seperate them by commas");
    }

    public void OnDestroy()
    {
        Logger.LogInfo("NPC Hit Phrases Unloaded!");
        Harmony.UnpatchAll();
    }
}
