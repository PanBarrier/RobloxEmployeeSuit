using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using ModelReplacement;
using BepInEx.Configuration;
using System;
using System.Xml.Linq;

namespace ModelReplacement
{
    [BepInPlugin("com.mrbarrier.robloxemployeesuit", "RobloxEmployeeSuit", "0.1.0")]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Assets.PopulateAssets();

            ModelReplacementAPI.RegisterSuitModelReplacement("Roblox Employee", typeof(MRROBLOXEMPLOYEESUIT));

            Harmony harmony = new Harmony("com.mrbarrier.robloxemployeesuit");
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {"com.mrbarrier.robloxemployeesuit"} is loaded!");
        }
    }
    public static class Assets
    {
        public static string mainAssetBundleName = "Suit";
        public static AssetBundle MainAssetBundle = null;

        private static string GetAssemblyName() => Assembly.GetExecutingAssembly().GetName().Name.Replace(" ","_");
        public static void PopulateAssets()
        {
            if (MainAssetBundle == null)
            {
                Console.WriteLine(GetAssemblyName() + "." + mainAssetBundleName);
                using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetAssemblyName() + "." + mainAssetBundleName))
                {
                    MainAssetBundle = AssetBundle.LoadFromStream(assetStream);
                }

            }
        }
    }

}