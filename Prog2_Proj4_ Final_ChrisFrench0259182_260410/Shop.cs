using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Prog2_Proj4_Final_ChrisFrench0259182_260410;


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
        public int _item1Cost;
        public ShopItem _shopItem2;
        public int _item2Cost;
        public ShopItem _shopItem3;
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

            _shopItem1 = shopItem1;
            _shopItem2 = shopItem2;
            _shopItem3 = shopItem3;
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

        public static void OpenShop(Shop shop)
        {
            if(GameManager.player._x == shop._x && GameManager.player._y == shop._y)
            {
                HUD.Shopkeep(_shopkeepName);
            }
        }
    }
}
