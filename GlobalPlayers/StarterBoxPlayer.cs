using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using StarterBox.Items;

namespace StarterBox.GlobalPlayers
{
    public class StarterBoxPlayer : ModPlayer
    {
        private bool hasReceivedStarterBox;

        public override void OnEnterWorld()
        {
            if (hasReceivedStarterBox)
                return;

            hasReceivedStarterBox = true;

            IEntitySource source = Player.GetSource_Misc("StarterBoxGift");
            Player.QuickSpawnItem(source, ModContent.ItemType<StarterBoxItem>());
        }

        public override void SaveData(TagCompound tag)
        {
            tag["hasReceivedStarterBox"] = hasReceivedStarterBox;
        }

        public override void LoadData(TagCompound tag)
        {
            hasReceivedStarterBox = tag.GetBool("hasReceivedStarterBox");
        }
    }
}
