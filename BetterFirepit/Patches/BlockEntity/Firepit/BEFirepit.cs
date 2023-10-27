using Vintagestory.GameContent;

namespace BetterFirepit.Patches.BlockEntity.Firepit
{
    public class BEFirepitSmeltItemsPatch
    {
        public static void Prefix(BlockEntityFirepit __instance, out float __state)
        {
            __state = __instance.InputStackTemp;
        }
        public static void Postfix(BlockEntityFirepit __instance, float __state)
        {
            __instance.InputStackTemp = __state;
        }
    }
}
