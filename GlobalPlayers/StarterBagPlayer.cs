using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using StarterBag.Items;

namespace StarterBag.GlobalPlayers
{
    public class StarterBagPlayer : ModPlayer
    {
        private bool hasReceivedStarterBag;

        public override void OnEnterWorld()
        {
            if (hasReceivedStarterBag)
                return;

            hasReceivedStarterBag = true;

            IEntitySource source = Player.GetSource_Misc("StarterBagGift");
            Player.QuickSpawnItem(source, ModContent.ItemType<StarterBagItem>());
        }

        public override void SaveData(TagCompound tag)
        {
            tag["hasReceivedStarterBag"] = hasReceivedStarterBag;
        }

        public override void LoadData(TagCompound tag)
        {
            hasReceivedStarterBag = tag.GetBool("hasReceivedStarterBag");
        }
    }
}
