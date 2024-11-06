using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

using GameUI = MonoBehaviourPublicGaroloGaObInCacachGaUnique;

namespace crabgame_mod_template
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        public override void Load()
        {
            Harmony.CreateAndPatchAll(typeof(Plugin));
        }

        [HarmonyPatch(typeof(GameUI), "Start")]
        [HarmonyPostfix]
        public static void Start(GameUI __instance)
        {
            EnableAmmoUIAndSetColors();
        }

        private static void EnableAmmoUIAndSetColors()
        {
            //Ammo UI element
            GameObject ammoUI = GameObject.Find("GameUI/Status/BottomRight/Tab0/Ammo (1)");
            if (ammoUI != null)
            {
                // Enable the Ammo UI element
                ammoUI.SetActive(true);

                //Circle child within Ammo (1) and set its color 
                Transform circleTransform = ammoUI.transform.Find("Circle");
                if (circleTransform != null)
                {
                    Image circleImage = circleTransform.GetComponent<Image>();
                    if (circleImage != null)
                    {
                        circleImage.color = new Color(0, 1, 0, 1); // Green Color
                    }
                }

                //Inner child within Ammo (1) and set its color 
                Transform innerTransform = ammoUI.transform.Find("Inner");
                if (innerTransform != null)
                {
                    Image innerImage = innerTransform.GetComponent<Image>();
                    if (innerImage != null)
                    {
                        innerImage.color = new Color(1, 0, 0, 1); // Red color
                    }
                }
            }
        }
    }
}

public static class PluginInfo
{
    public const string PLUGIN_GUID = "com.example.crabgame_mod";
    public const string PLUGIN_NAME = "CrabGameModAmmoIndication";
    public const string PLUGIN_VERSION = "1.0.0";
}
