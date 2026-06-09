using HarmonyLib;
using MBMScripts;

namespace TYPEtoNumberID.Patches;

[HarmonyPatch(typeof(ReferenceCustomize), nameof(ReferenceCustomize.GetString))]
public class ReferenceCustomizePatch
{
    static bool Prefix(ReferenceCustomize __instance, ref string __result, int ___m_DataType)
    {
        if (__instance.Updater.TargetUnit?.Unit is not Character character)
        {
            __result = string.Empty;
            return false;
        }

        string text;
        switch (___m_DataType)
        {
            case 1:  // EDataType.HairFrontType
                try
                {
                    text = character.HairFrontType.ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;

            default:
                return true;
        }

        __result = string.Format(SeqLocalization.Localize("#TypeFormat"), text);
        return false;
    }
}