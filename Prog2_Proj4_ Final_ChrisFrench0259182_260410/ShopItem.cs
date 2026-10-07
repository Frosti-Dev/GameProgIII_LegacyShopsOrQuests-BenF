using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class ShopItem
    {
        public string _itemName { get; set; }
        public int _itemCost { get; set; }

        protected ShopItem(string itemName, int itemCost)
        {
            _itemName = itemName;

            _itemCost = itemCost;
        }

        public virtual void Effect()
        {

        }
    }
}
