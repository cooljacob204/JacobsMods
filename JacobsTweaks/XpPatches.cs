using HarmonyLib;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace JacobsTweaks
{
    [HarmonyPatch(typeof(DefaultBuildingTypes), "InitializeAll")]
    public class DefaultBuildingTypesPatch
    {
        static void Postfix(ref BuildingType ____buildingCastleTrainingFields, ref BuildingType ____buildingSettlementTradingFields)
        {
            int multiplier = int.Parse(Settings.LoadSetting("TrainingFieldMultiplier"));

            ____buildingCastleTrainingFields.Initialize(new TextObject("{=BkTiRPT4}Training Fields", null), new TextObject("{=otWlERkc}A field for military drills that increase the daily experience gain of all garrisoned units.", null), new int[]
            {
                39,
                52,
                65
            }, BuildingLocation.Castle, new Dictionary<BuildingEffect, IReadOnlyList<int>>
            {
                {
                    DefaultBuildingEffects.Experience,
                    new List<int>
                    {
                        1 * multiplier,
                        2 * multiplier,
                        3 * multiplier
                    }
                }
            }, 0);

            ____buildingSettlementTradingFields.Initialize(new TextObject("{=BkTiRPT4}Training Fields", null), new TextObject("{=otWlERkc}A field for military drills that increase the daily experience gain of all garrisoned units.", null), new int[]
            {
                390,
                520,
                650
            }, BuildingLocation.Settlement, new Dictionary<BuildingEffect, IReadOnlyList<int>>
            {
                {
                    DefaultBuildingEffects.Experience,
                    new List<int>
                    {
                        1 * multiplier,
                        2 * multiplier,
                        4 * multiplier
                    }
                }
            }, 0);
        }
    }
}