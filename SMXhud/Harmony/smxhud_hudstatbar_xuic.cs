using HarmonyLib;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: Sirillion.
//	Assists: sphereii, TormentedEmu.

//	Adds an extra binding to separate statmax into its own for current ammo count.
//	Difference: Vanilla has no statmax binding and as such it can only show statcurrentwithmax or statcurrent.

public class SMXhud_hudstatbar_xuic
{
    [HarmonyPatch(typeof(XUiC_HUDStatBar))]
    [HarmonyPatch("GetBindingValue")]
    public class SMXhudHudStatBarStatMaxNew
    {
        public static bool Prefix(ref XUiC_HUDStatBar __instance, ref bool __result, ref string value, ref string bindingName,
                            ref HUDStatGroups ___statGroup, ref HUDStatTypes ___statType, ref int ___currentAmmoCount,
                            ref CachedStringFormatter<int> ___statcurrentFormatterInt, ref CachedStringFormatter<int> ___currentPaintAmmoFormatter,
                            ref ItemActionAttack ___attackAction, ref int ___currentSlotIndex)
        {
            if (bindingName != null)
            {
                if (bindingName == "statmax")
                {
                    if (__instance.LocalPlayer == null || (___statGroup == HUDStatGroups.Vehicle && __instance.Vehicle == null))
                    {
                        value = "";
                        return true;
                    }
                    switch (___statType)
                    {
                        case HUDStatTypes.Health:
                            value = ___statcurrentFormatterInt.Format((int)__instance.LocalPlayer.Stats.Health.Max);
                            break;
                        case HUDStatTypes.Stamina:
                            value = ___statcurrentFormatterInt.Format((int)__instance.LocalPlayer.Stats.Stamina.Max);
                            break;
                        case HUDStatTypes.Water:
                            value = ___statcurrentFormatterInt.Format((int)__instance.LocalPlayer.Stats.Water.Max);
                            break;
                        case HUDStatTypes.Food:
                            value = ___statcurrentFormatterInt.Format((int)__instance.LocalPlayer.Stats.Food.Max);
                            break;
                        case HUDStatTypes.ActiveItem:
                            if (___attackAction is ItemActionTextureBlock)
                            {
                                value = ___currentPaintAmmoFormatter.Format(___currentAmmoCount);
                            }
                            else if (___attackAction is ItemActionReplaceBlock)
                            {
                                ItemActionReplaceBlock.ItemActionReplaceBlockData itemActionReplaceBlockData = (ItemActionReplaceBlock.ItemActionReplaceBlockData)__instance.LocalPlayer.inventory.GetItemActionDataInSlot(___currentSlotIndex, 1);
                                value = ((itemActionReplaceBlockData.ReplaceBlockClass != null) ? itemActionReplaceBlockData.ReplaceBlockClass.GetLocalizedBlockName() : "No Block");
                            }
                            else
                            {
                                value = ___statcurrentFormatterInt.Format(___currentAmmoCount);
                            }
                            break;
                        case HUDStatTypes.VehicleHealth:
                            value = ___statcurrentFormatterInt.Format((int)__instance.Vehicle.GetVehicle().GetMaxHealth());
                            break;
                        case HUDStatTypes.VehicleFuel:
                            value = ___statcurrentFormatterInt.Format((int)__instance.Vehicle.GetVehicle().GetMaxFuelLevel()); // Float - Revisit this!
                            break;
                    }
                }
            }
            return true;
        }

        [HarmonyPatch(typeof(XUiC_HUDStatBar))]
        [HarmonyPatch("GetBindingValue")]
        public class SMXhudHudStatBarStatMaxOld
        {
            public static void Postfix(ref bool __result, ref string value, ref string bindingName, ref int ___currentAmmoCount, ref CachedStringFormatter<int> ___statcurrentFormatterInt)
            {
                if (bindingName != null)
                {
                    if (bindingName == "statmax2")
                    {
                        value = ___statcurrentFormatterInt.Format(___currentAmmoCount);
                        __result = true;
                    }
                }
            }
        }

        // WIP - Sirillion - Testing stuff.
        [HarmonyPatch(typeof(XUiC_HUDStatBar))]
        [HarmonyPatch("GetBindingValue")]
        public class SMXhudHudStatBarStatCurrentOverride
        {
            public static bool Prefix(ref XUiC_HUDStatBar __instance, ref bool __result, ref string value, ref string bindingName,
                                ref HUDStatGroups ___statGroup, ref HUDStatTypes ___statType, ref int ___currentAmmoCount,
                                ref CachedStringFormatter<int> ___statcurrentFormatterInt, ref CachedStringFormatter<int> ___statcurrentFormatterFloat,
                                ref CachedStringFormatter<int> ___currentPaintAmmoFormatter, ref ItemActionAttack ___attackAction, ref int ___currentSlotIndex)
            {
                if (bindingName != null)
                {
                    if (bindingName == "statcurrent2")
                    {
                        if (__instance.LocalPlayer == null || (___statGroup == HUDStatGroups.Vehicle && __instance.Vehicle == null))
                        {
                            value = "";
                            return true;
                        }
                        switch (___statType)
                        {
                            case HUDStatTypes.Health:
                                value = ___statcurrentFormatterInt.Format(__instance.LocalPlayer.Health);
                                break;
                            case HUDStatTypes.ActiveItem:
                                if (___attackAction is ItemActionTextureBlock)
                                {
                                    value = ___currentPaintAmmoFormatter.Format(___currentAmmoCount);
                                }
                                else
                                {
                                    value = ___statcurrentFormatterInt.Format(__instance.LocalPlayer.inventory.holdingItemItemValue.Meta);
                                }
                                break;
                        }
                    }
                }
                return true;
            }
        }
    }

    //	Inject into SetupActiveItemEntry to show melee weapon icons on the right side unit frames.
    //	Difference: Vanilla has no way of display the icon for a melee weapon on the HUD.

    // WIP - From sphereii - Custom Code - Show melee weapon icons on hud.
    [HarmonyPatch(typeof(XUiC_HUDStatBar))]
    [HarmonyPatch("SetupActiveItemEntry")]
    public class SMXuiSetUpActiveItemEntry
    {
        public static bool Prefix(XUiC_HUDStatBar __instance, int ___currentSlotIndex, ref ItemClass ___itemClass, ref ItemActionAttack ___attackAction)
        {
            if (__instance.LocalPlayer != null && __instance.LocalPlayer.inventory.GetItemInSlot(___currentSlotIndex) != null)
            {
                ItemValue itemValue = __instance.LocalPlayer.inventory.GetItem(___currentSlotIndex).itemValue;
                if (itemValue != null && itemValue.ItemClass != null)
                {
                    if (itemValue.ItemClass.Actions[0] is ItemActionDynamicMelee)
                    {
                        ___attackAction = itemValue.ItemClass.Actions[0] as ItemActionAttack;
                        ___itemClass = itemValue.ItemClass;
                        return false;
                    }
                }

            }
            return true;
        }
    }
}