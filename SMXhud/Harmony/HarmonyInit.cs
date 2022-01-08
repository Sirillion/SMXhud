using System.Reflection;
using UnityEngine;

public class SMXhud : IModApi
{
    public void InitMod(Mod _modInstance)
    {
        Debug.Log($" Loading Patch: {GetType()} Mod: {_modInstance.ModInfo.Name}");
        var harmony = new HarmonyLib.Harmony(GetType().ToString());
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}