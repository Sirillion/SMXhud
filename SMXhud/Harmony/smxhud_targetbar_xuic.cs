using HarmonyLib;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: Sirillion.
//	Assists: .

//	Adds a visible trigger that hides the target health bar when entering a vehicle.
//	Difference: Vanilla has no such trigger and as such it will display the vehicles health bar while riding around.

public class SMXhud_targetbar_xuic
{
	[HarmonyPatch(typeof(XUiC_TargetBar))]
	[HarmonyPatch("Update")]
	public class SMXhudTargetBarVisible
	{
		public static bool Prefix(ref XUiC_TargetBar __instance)
		{
			__instance.ViewComponent.IsVisible = ((!(__instance.xui.playerUI.entityPlayer.AttachedToEntity != null) || !(__instance.xui.playerUI.entityPlayer.AttachedToEntity is EntityVehicle)) && !__instance.xui.playerUI.entityPlayer.IsDead());
			return true;
		}
	}

	[HarmonyPatch(typeof(XUiC_TargetBar))]
	[HarmonyPatch("GetBindingValue")]
	public class SMXhudTargetBarBinding
	{
		public static void Postfix(ref XUiC_TargetBar __instance, ref bool __result, ref string value, ref string bindingName, ref CachedStringFormatter<int> ___statcurrentFormatterInt)
		{
      if (bindingName != null)
      {
        if (bindingName == "statmax")
        {
          if (__instance.Target == null)
					{
						value = "";
					}
          else
          {
            value = ___statcurrentFormatterInt.Format((int)__instance.Target.Stats.Health.Max);
          }

          __result = true;
				}
			}
		}
	}
}
