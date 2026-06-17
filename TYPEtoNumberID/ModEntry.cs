using MBM.ModLoader.Core;
using System;
using UnityEngine;

namespace TYPEtoNumberID;

public static class ModEntry
{
    internal const string ModName = "TYPEtoNumberID";

    internal static bool IsTitsModLoaded = false;

    public static void Load()
    {
        Loader.OnAllModsLoaded += CheckTitsModLoad;

        Log("TYPEtoNumberID Mod loaded!");
    }

    private static void CheckTitsModLoad()
    {
        if (Loader.IsModLoaded("TitsMod"))
        {
            Log("Detected: TitsMod enabled.");
            IsTitsModLoaded = true;
        }
    }

    internal static void Log(string msg) => Debug.Log($"[TNID] {msg}");
}