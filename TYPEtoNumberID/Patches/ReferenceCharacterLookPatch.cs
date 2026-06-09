using HarmonyLib;
using MBMScripts;

namespace TYPEtoNumberID.Patches;

[HarmonyPatch(typeof(ReferenceCharacterLook), nameof(ReferenceCharacterLook.GetString))]
public class ReferenceCharacterLookPatch
{
    static bool Prefix(ReferenceCharacterLook __instance, ref string __result, int ___m_DataType)
    {
        if (__instance.Updater.TargetUnit?.Unit is not Character character)
        {
            __result = string.Empty;
            return false;
        }

        string text;
        switch (___m_DataType)
        {
            case 16:  //EDataType.EyeType no text
                __result =  character.EyeType.ToString();
                return false;

            case 18:  //EDataType.BodyType no text
                __result = character.LowerBodyType.ToString();
                return false;

            case 22:  // EDataType.HairFrontType
                try
                {
                    text = character.HairFrontType.ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;

            case 24:  //EDataType.HairSideType
                if (character.HairSideType == 0)
                {
                    __result = SeqLocalization.Localize("#None");
                    return false;
                }
                try
                {
                    text = character.HairSideType.ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;

            case 25://  EDataType.HairBackType no text
                __result = character.HairBackType.ToString();
                return false;

            case 27:  //EDataType.PubicHairType
                if (character.PubicHairType == 0)
                {
                    __result = SeqLocalization.Localize("#None");
                    return false;
                }

                try
                {
                    text = character.PubicHairType.ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;

            case 29:  //EDataType.SkinColorType no text
                if (character.SkinColorType == 100)
                {

                    __result =  "O";
                    return false;
                }

                __result = (character.SkinColorType + 1).ToString();
                return false;

            case 31:  //EDataType.HornDragonType
                if (character.HornType == 0 && character.HornDragonType == 0)
                {
                    __result = SeqLocalization.Localize("#None");
                    return false;
                }

                if (character.HornType > 0)
                {
                    try
                    {
                        text = character.HornType.ToString();
                    }
                    catch
                    {
                        text = string.Empty;
                    }
                    break;
                }

                try
                {
                    var list = GlobalCharacterData.AllPartTypes["Horn"];
                    text = (character.HornDragonType + list[list.Count-1]).ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;
            case 33:  //EDataType.HairBodyType
                if (character.HairBodyType == 0)
                {
                    __result = SeqLocalization.Localize("#None");
                    return false;
                }

                try
                {
                    text = character.HairBodyType.ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;

            case 41:  //EDataType.EyeBallType no text
                __result = character.RawEyeBallType.ToString();
                return false;

            case 45:  //EDataType.EarType
                try
                {
                    text = character.EarType.ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;

            case 46:  //EDataType.EarHairType
                if (character.EarHairType == 0)
                {
                    __result = SeqLocalization.Localize("#None");
                    return false;
                }

                try
                {
                    text = character.EarHairType.ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;

            case 48:  //EDataType.TailType
                if (character.TailType == 0 && character.TailDragonType == 0)
                {
                    __result = SeqLocalization.Localize("#None");
                    return false;
                }

                if (character.TailType > 0)
                {
                    try
                    {
                        text = character.TailType.ToString();
                    }
                    catch
                    {
                        text = string.Empty;
                    }
                    break;
                }

                try
                {
                    var list = GlobalCharacterData.AllPartTypes["Tail"];
                    text = (character.TailDragonType + list[list.Count - 1]).ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;
            case 55:  //EDataType.HornType
                if (character.HornType == 0)
                {
                    __result = SeqLocalization.Localize("#None");
                    return false;
                }

                try
                {
                    text = character.HornType.ToString();
                }
                catch
                {
                    text = string.Empty;
                }
                break;

            case 57:  //EDataType.BeardType
                if (character.BeardType == 0)
                {
                    __result = SeqLocalization.Localize("#None");
                    return false;
                }

                try
                {
                    text = character.BeardType.ToString();
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