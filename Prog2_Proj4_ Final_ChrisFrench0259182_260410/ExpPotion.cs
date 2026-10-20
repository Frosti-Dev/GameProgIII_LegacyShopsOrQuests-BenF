using Prog2_Proj4_Final_ChrisFrench0259182_260410;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class ExpPotion : ShopItem
    {
        public ExpPotion(string itemName, int itemCost) : base(itemName: "ExpPotion", itemCost: 100)
        {

        }

        public override void Effect(Shop shop, int buyID)
        {
            if (_itemCost <= Treasure._gold)
            {
                Treasure._gold -= _itemCost;
                Player.plXP += 100;

                HUD.MoneySpent(shop, buyID);
            }

            else
            {
                HUD.BrokeBoy();
            }
        }
    }
}
