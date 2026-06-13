using UnityEngine;

namespace TYPEtoNumberID;

public static class ModEntry
{
    internal const string ModName = "TYPEtoNumberID";

    public static void Load()
    {
        GlobalCharacterData.Initialize();

        Log("TYPEtoNumberID Mod loaded!");
    }

    internal static void Log(string msg) => Debug.Log($"[TNID] {msg}");
}