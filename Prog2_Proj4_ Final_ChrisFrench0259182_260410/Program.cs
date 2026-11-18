using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{

    //public class Program
    class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Do you wish to reload any available character data save?");
            Console.WriteLine("'Y' for Yes");
            Console.WriteLine("'N' for No");
            ConsoleKey input = Console.ReadKey(true).Key;
            Console.Clear();

            if (input == ConsoleKey.Y)
            {
                try
                {
                    GameManager.LoadData();
                    GameManager.isOldFile = true;
                }

                catch (FileNotFoundException)
                {
                    Console.Clear();

                    Console.WriteLine("CRITICAL ERROR: NO SAVE FOUND!");
                }

                GameManager.LoadData();
                GameManager.isOldFile = true;
            }
            else if (input == ConsoleKey.N) GameManager.isOldFile = false;

            bool replay = false;

            try
            {
                GameManager.StartGame();   
            }

            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();

                Console.WriteLine("CRITICAL ERROR: Console window was too small!");
                Console.WriteLine("Please maximize your window and press 'R' to restart."); //pause and waitts for player resize and press r

            }

            if (input == ConsoleKey.Y)
            {
                GameManager.LoadData();
                GameManager.isOldFile = true;
            }
            else GameManager.isOldFile = false;

            GameManager.StartGame();

            replay = true;

            while (replay)
            {
                //try
                //{
                //    GameManager.StartGame();
                //}
                //catch (ArgumentOutOfRangeException)
                //{
                //    Console.Clear();
                //    Console.WriteLine("CRITICAL ERROR: Console window was too small!");
                //    Console.WriteLine("Please maximize your window and press 'R' to restart.");  // same but in replay

                //}
                Console.Clear();
                GameManager.StartGame();

                ConsoleKey inputR = Console.ReadKey(true).Key;
                if (inputR == ConsoleKey.R)
                {
                    GameManager.isPlaying = true;
                    replay = true;
                    GameManager.Restart();
                    return;
                }
                if (inputR != ConsoleKey.R)
                {
                    replay = false;
                }
                Console.Clear();

            }

            //GameManager.StartGame();


        }





        /////////////////////////   
        //bool replay = true;

        //while (replay)
        //{
        //    GameManager.StartGame();

        //    ConsoleKey input = Console.ReadKey(true).Key;
        //    if (input == ConsoleKey.R)
        //    {
        //        GameManager.isPlaying = true;
        //        replay = true;
        //        GameManager.Restart();
        //        return;
        //    }
        //    if (input != ConsoleKey.R)
        //    {
        //        replay = false; 
        //    }
        //    Console.Clear();

        //}

        //GameManager.StartGame();


    }





}



