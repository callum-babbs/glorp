using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glorp.Content.Items
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class glorpItem : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.glorp.hjson' file.
		public override void SetDefaults()
		{
            Item.CloneDefaults(ItemID.ZephyrFish); // Copy the Defaults of the Zephyr Fish Item.

            Item.shoot = ModContent.ProjectileType<glorpPetProjectile>(); // "Shoot" your pet projectile.
            Item.buffType = ModContent.BuffType<glorpPetBuff>(); // Apply buff upon usage of the Item.

            Item.width = 20;
            Item.height = 20;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.AddBuff(Item.buffType, 3600);
            }
            return true;
        }

        public override void AddRecipes()
		{
            CreateRecipe()
                .AddIngredient(2860, 50)
                .AddIngredient(2304, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
	}
}
