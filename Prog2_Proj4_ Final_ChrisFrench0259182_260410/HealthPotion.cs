using Prog2_Proj4_Final_ChrisFrench0259182_260410;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class HealthPotion : ShopItem
    {
        public HealthPotion(string itemName, int itemCost) : base(itemName: "Health Potion", itemCost: 25)
        {
        }

        public override void Effect()
        {
            GameManager.player._health += 15;
        }
    }
}
