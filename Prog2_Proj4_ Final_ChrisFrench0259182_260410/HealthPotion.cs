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
        public int _itemStrength;

        public HealthPotion(string itemName, int itemCost, int itemStrength) : base(itemName: "Health Potion", itemCost: 25)
        {
            _itemName = itemName;
            _itemCost = itemCost;
            _itemStrength = itemStrength;
        }

        public override void Effect(Shop shop, int buyID)
        {
            if (_itemCost <= Treasure._gold)
            {
                Treasure._gold -= _itemCost;
                GameManager.player._health += _itemStrength;

                if (GameManager.player._health > GameManager.plaMaxHP)
                {
                    GameManager.player._health = GameManager.plaMaxHP;
                }

                HUD.MoneySpent(shop, buyID);
            }

            else
            {
                HUD.BrokeBoy();
            }
        }
    }
}
