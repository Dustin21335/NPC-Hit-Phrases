using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace CustomNPCHitPhrases.Patches
{
    [HarmonyPatch(typeof(NPC_Info))]
    public class NPC_InfoPatches
    {
        private static List<string> NotificationMessages = new List<string>();

        [HarmonyPrefix, HarmonyPatch("UserCode_RPCNotificationAboveHead__String__String")]
        public static bool UserCode_RPCNotificationAboveHead__String__String(NPC_Info __instance)
        {
            string Messages = CustomNPCHitPhrases.NotificationMessages.Value;
            if (string.IsNullOrEmpty(Messages)) return true;
            NotificationMessages = Messages.Split(',').Select(m => m.Trim()).ToList();
            if (NotificationMessages.Any(string.IsNullOrEmpty)) return true;
            GameObject obj = Object.Instantiate(__instance.messagePrefab, __instance.transform.position + Vector3.up * 1.8f, Quaternion.identity);
            obj.GetComponent<TextMeshPro>().text = NotificationMessages[new Random().Next(NotificationMessages.Count)]; 
            obj.SetActive(true);
            return false;
        }
    }
}