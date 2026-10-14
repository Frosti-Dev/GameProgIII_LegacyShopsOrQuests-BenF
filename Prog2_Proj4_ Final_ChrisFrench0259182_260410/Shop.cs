using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Prog2_Proj4_Final_ChrisFrench0259182_260410;
using System.Diagnostics.Contracts;


namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class Shop
    {
        //added ben code


        public static string _shopkeepName { get; set; }
        public int _x { get; set; }
        public int _y { get; set; }

        public static Random randomName = new Random();

        public char _symbol { get; protected set; }
        public ConsoleColor _bgColor { get; set; }
        public ConsoleColor _fgColor { get; set; }

        public ShopItem _shopItem1;
        public string _item1Name;
        public int _item1Cost;
        public ShopItem _shopItem2;
        public string _item2Name;
        public int _item2Cost;
        public ShopItem _shopItem3;
        public string _item3Name;
        public int _item3Cost;

        public Shop(string shopkeepName, int x, int y, char symbol, ConsoleColor fgColor, ConsoleColor bgColor, ShopItem shopItem1, ShopItem shopItem2, ShopItem shopItem3)
        {
            _x = x;
            _y = y;
            _symbol = symbol;
            _fgColor = fgColor;
            _bgColor = bgColor;

            shopkeepName = GetRandomNameFromFile();
            _shopkeepName = shopkeepName;

            _item1Name = shopItem1._itemName;
            _item2Name = shopItem2._itemName;
            _item3Name = shopItem3._itemName;

            _shopItem1 = shopItem1;
            _shopItem2 = shopItem2;
            _shopItem3 = shopItem3;

            _item1Cost = shopItem1._itemCost;
            _item2Cost = shopItem2._itemCost;
            _item3Cost = shopItem3._itemCost;

        }

        public static string GetRandomNameFromFile()
        {
            string filePath = "names.txt";
            try
            {
                if (File.Exists(filePath))
                {

                    string content = File.ReadAllText(filePath);
                    string[] names = content.Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    if (names.Length > 0)
                    {
                        return names[randomName.Next(names.Length)].Trim();
                    }
                }
            }
            catch (Exception ex)

            {
                Console.WriteLine($"Error loading {filePath}: {ex.Message}");
            }

            return "Mysterious Frosti";
        }

        public static void CheckOpenShop(Shop shop)
        {
            if(GameManager.player._x == shop._x && GameManager.player._y == shop._y)
            {
                GameManager.isShopping = true;
                HUD.Shopkeep(_shopkeepName, shop);
            }

            else
            {
                GameManager.isShopping = false;
            }
        }

        public static void CheckBuy(Shop shop, int buyID)
        {
            if (GameManager.isShopping)
            {
                if(buyID == 1)
                {
                    shop._shopItem1.Effect();
                    HUD.MoneySpent(shop, buyID);
                }
                if (buyID == 2)
                {
                    shop._shopItem2.Effect();
                    HUD.MoneySpent(shop, buyID);
                }
                if (buyID == 3)
                {
                    shop._shopItem3.Effect();
                    HUD.MoneySpent(shop, buyID);

                    //FIX HUD POPPING UP TOO EARLY!!!!!!!!!
                }
            }
        }
    }
}
