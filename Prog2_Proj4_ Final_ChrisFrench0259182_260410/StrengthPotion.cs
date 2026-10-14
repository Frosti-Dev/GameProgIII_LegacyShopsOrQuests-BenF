using Prog2_Proj4_Final_ChrisFrench0259182_260410;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class StrengthPotion: ShopItem
    {
        public StrengthPotion(string itemName, int itemCost) : base(itemName: "Strength Potion", itemCost: 35)
        {
        }

        public override void Effect()
        {
            if (_itemCost <= Treasure._gold)
            {
                Treasure._gold -= _itemCost;
                GameManager.player._attack += 15;
                
            }

            else
            {
                HUD.BrokeBoy();
            }
        }
    }
}
