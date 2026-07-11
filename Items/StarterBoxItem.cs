using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using StarterBox.Systems;

namespace StarterBox.Items
{
    public class StarterBoxItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 0;
            Item.expert = false; 
        }

        public override bool CanRightClick() => true;

        public override void RightClick(Player player)
        {
            IEntitySource source = player.GetSource_Misc("StarterBoxOpen");

            GiveClassWeapons(player, source);
            GiveResources(player, source);
            GiveMagicStorageItems(player, source);

            Item.stack--;
        }

        private static void GiveClassWeapons(Player player, IEntitySource source)
        {
            // Mage
            player.QuickSpawnItem(source, ItemID.WandofSparking);

            // Melee
            player.QuickSpawnItem(source, ItemID.IronBroadsword);

            // Ranger
            player.QuickSpawnItem(source, ItemID.WoodenBow);
            player.QuickSpawnItem(source, ItemID.WoodenArrow, 250);

            // Summoner
            player.QuickSpawnItem(source, ItemID.BabyBirdStaff);
        }

        private static void GiveResources(Player player, IEntitySource source)
        {
            player.QuickSpawnItem(source, ItemID.LifeCrystal, 2);
            player.QuickSpawnItem(source, ItemID.ManaCrystal, 2);
            player.QuickSpawnItem(source, ItemID.GoldCoin, 5);
            player.QuickSpawnItem(source, ItemID.LesserHealingPotion, 25);
        }
        private static void GiveMagicStorageItems(Player player, IEntitySource source)
        {
            if (!ModCompatibility.IsMagicStorageLoaded)
                return;

            int storageUnit = ModCompatibility.GetMagicStorageItemType("StorageUnit");
            int storageHeart = ModCompatibility.GetMagicStorageItemType("StorageHeart");
            int storageCraftingInterface = ModCompatibility.GetMagicStorageItemType("CraftingAccess");

            if (storageUnit > 0)
                player.QuickSpawnItem(source, storageUnit, 4);

            if (storageHeart > 0)
                player.QuickSpawnItem(source, storageHeart, 1);

            if (storageCraftingInterface > 0)
                player.QuickSpawnItem(source, storageCraftingInterface, 1);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "StarterBoxDescription",
                "Right click to open.\n" +
                "Contains starter weapons for Mage, Melee, Ranger, and Summoner,\n" +
                "as well as Life Crystals, Mana Crystals, coins, and Lesser Healing Potions.\n" +
                "Also provides Magic Storage components if the mod is installed."));
        }
    }
}
