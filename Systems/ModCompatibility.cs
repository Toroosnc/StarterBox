using Terraria.ModLoader;

namespace StarterBox.Systems
{
    public class ModCompatibility : ModSystem
    {
        private static Mod magicStorageMod;
        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("MagicStorage", out magicStorageMod);
        }
        public static bool IsMagicStorageLoaded => magicStorageMod != null;
        public static int GetMagicStorageItemType(string itemName)
        {
            if (magicStorageMod == null)
                return 0;
            if (magicStorageMod.TryFind(itemName, out ModItem modItem))
                return modItem.Type;
            return 0;
        }
    }
}
