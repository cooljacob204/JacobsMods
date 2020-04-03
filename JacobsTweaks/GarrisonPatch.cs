using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace JacobsTweaks
{
    [HarmonyPatch(typeof(DefaultDailyTroopXpBonusModel), "CalculateGarrisonXpBonusMultiplier")]
    public class DefaultDailyTroopXpBonusModelPatch
    {
        static void Postfix(ref float __result)
        {
            __result *= 50;
        }
    }
}