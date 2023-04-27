using Vintagestory.API.Common;
using HarmonyLib;
using Vintagestory.API.Server;
using Vintagestory.GameContent;
using System.Reflection;
using BetterFirepitNet7.Patches.BlockEntity.Firepit;

namespace BetterFirepitNet7
{
    internal class Program : ModSystem
    {
        public Harmony? harmony;

        public override void StartServerSide(ICoreServerAPI api)
        {
            ILogger logger = api.Logger;
            harmony = new Harmony("betterfirepit");
            MethodInfo? original = typeof(BlockEntityFirepit).GetMethod("smeltItems");
            MethodInfo? prefix = typeof(BEFirepitSmeltItemsPatch).GetMethod("Prefix");
            MethodInfo? postfix = typeof(BEFirepitSmeltItemsPatch).GetMethod("Postfix");

            if (original != null && prefix != null && postfix != null)
            {
                MethodInfo? method = harmony.Patch(original, new HarmonyMethod(prefix), new HarmonyMethod(postfix));
                if (method != null)
                {
                    logger.Debug("Better Firepit: Patched firepit");
                }
                else
                {
                    logger.Debug("Better Firepit: Failed to patch firepit");
                }
            }
            else
            {
                logger.Debug("Better Firepit: Could not find method(s) to patch. More info:");
                logger.Debug($"{original?.Name ?? "null"}/{prefix?.Name ?? "null"}/{postfix?.Name ?? "null"}");
            }
            
            base.StartServerSide(api);
        }
    }
}
