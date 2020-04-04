using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace JacobsTweaks
{
    [HarmonyPatch(typeof(DefaultSmithingModel), "ResearchPointsNeedForNewPart")]
    class SmithingPatches
    {
        static void Postfix(ref int __result)
        {
            __result /= 18;
        }
    }
}
