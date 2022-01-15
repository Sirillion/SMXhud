using HarmonyLib;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: TormentedEmu.
//	Tweaked: Sirillion.

//	Adds an extra binding to hide buff background depending on a buff existing or not.
//	Difference: Vanilla has no binding for this, and as such every grid cell would get a background drawn regardless of it having a buff or not.

public class SMXhud_activebuffentry_xuic
{
    [HarmonyPatch(typeof(XUiC_ActiveBuffEntry))]
    [HarmonyPatch("GetBindingValue")]

    public class SMXhudActiveBuffEntryHasBuff
    {
        static bool Prefix(ref bool __result, ref string value, ref string bindingName, string ___buffName)
        {
            if (bindingName == "hasbuff")
            {
                if (string.IsNullOrEmpty(___buffName))
                    value = "false";
                else
                    value = "true";
                    __result = true;
                return false;
            }
            return true;
        }
    }
}

