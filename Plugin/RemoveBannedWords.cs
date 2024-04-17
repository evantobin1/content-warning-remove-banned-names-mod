using System.Collections.Generic;
using BepInEx;
using HarmonyLib;


namespace Plugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class RemoveBannedWords : BaseUnityPlugin
    {

        private void Awake()
        {
            // Plugin startup logic
            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }


        // Patching a method to modify a private field
        [HarmonyPatch(typeof(PlayerVisor), "RPCA_SetVisorText")]
        public class PatchPlayerVisorClass
        {
            static bool Prefix(ref string text, ref List<string> ___bannedWords)
            {
                ___bannedWords = new List<string>();

                // Return true to run the original method after this prefix
                return true;
            }
        }
    }
}
