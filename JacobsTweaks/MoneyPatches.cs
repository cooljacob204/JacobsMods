using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using TaleWorlds.Core;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

namespace JacobsTweaks
{
    [HarmonyPatch(typeof(WorkshopsCampaignBehavior), "ProduceOutput")]
    class WorkshopPrePatches
    {
        static bool Prefix(ItemObject outputItem, Town town, Workshop workshop, int count, bool doNotEffectCapital)
        {
            int multiplier = int.Parse(Settings.LoadSetting("WorkshopIncomeMultiplier"));

            int itemPrice = town.GetItemPrice(outputItem, null, false);
            town.Owner.ItemRoster.AddToCounts(outputItem, count, true);
            if (Campaign.Current.GameStarted && !doNotEffectCapital)
            {
                int num = itemPrice * count * multiplier;
                workshop.ChangeGold(num);
                town.ChangeGold(-num);
            }

            CampaignEventDispatcher.Instance.GetType()
                .GetMethod("OnItemProduced", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(CampaignEventDispatcher.Instance, new object[] { outputItem, town.Owner.Settlement, count });

            return false;
        }
    }
}
