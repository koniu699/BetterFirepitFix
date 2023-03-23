using HarmonyLib;
using Vintagestory.GameContent;


namespace BetterFirepit.Patches.BlockEntity.Firepit
{
    [HarmonyPatch(typeof(BlockEntityFirepit), nameof(BlockEntityFirepit.smeltItems))]
    public class BEFirepitSmeltItemsPatch
    {

        static void Prefix(BlockEntityFirepit __instance, out float __state)
        {
            __state = __instance.InputStackTemp;

        }
        static void Postfix(BlockEntityFirepit __instance, float __state)
        {
            __instance.InputStackTemp = __state;
        }
    }
}
