using HarmonyLib;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: Sirillion.
//	Tweaked: sphereii, TormentedEmu.

//	Disables YOffset for CollectedItemsList as it is not needed with SMX.
//	Difference: Vanilla moves the CollectedItems upwards a bit when holding an ActiveItem in your hand or when entering a vehicle.

public class SMXhud_collecteditemlist_xuic
{
    [HarmonyPatch(typeof(XUiC_CollectedItemList))]
    [HarmonyPatch("SetYOffset")]

    public class SMXhudCollectedItemList
    {
        public static bool Prefix()
        {
            return false;
        }
    }
}