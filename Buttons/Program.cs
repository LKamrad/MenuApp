using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ConsoleKeyInfo cki;

            //Models.Button[] buttonArr = new Models.Button[7]; 
            List<Models.Button> ButtonSystem = new List<Models.Button>();

            ButtonSystem.Add(new Models.Button(5,12, "Funktion 1", true));
            ButtonSystem.Add(new Models.Button(18, 12, "Funktion 2", false));
            ButtonSystem.Add(new Models.Button(31, 12, "Funktion 3", false));
            ButtonSystem.Add(new Models.Button(44, 12, "Funktion 4", false));
            ButtonSystem.Add(new Models.Button(5, 15, "Funktion 5", false));
            ButtonSystem.Add(new Models.Button(18, 15, "Funktion 6", false));
            ButtonSystem.Add(new Models.Button(31, 15, "Funktion 7", false));
            ButtonSystem.Add(new Models.Button(44, 15, "Funktion 8", false));


            Models.Button[] buttonArr = ButtonSystem.ToArray();
            int buttonIndex = 0;

            do
            {
                Console.CursorVisible = false;

                
                Console.Clear();
                PrintLogo();
                foreach (var button in buttonArr)
                {
                    button.DrawButton();
                }
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("Navigation <- or ->");
                Console.WriteLine("Press Enter to select");
                Console.WriteLine("Press Escape to quit");

                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.LeftArrow)
                {
                    if(buttonIndex != 0)
                    {
                        buttonArr[buttonIndex--].DrawButton(false);
                        buttonArr[buttonIndex].DrawButton(true);
                    }

                }
                else if (cki.Key == ConsoleKey.RightArrow)
                {
                    if (buttonIndex != buttonArr.Length - 1)
                    {
                        buttonArr[buttonIndex++].DrawButton(false);
                        buttonArr[buttonIndex].DrawButton(true);
                    }
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = true;
                    int counter = 0;
                    while (buttonArr[counter].IsSelected() != true)
                    {
                        counter++;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();

                    if(counter == 0)
                    {
                        Console.WriteLine("Funktion 1");
                    }
                    else if (counter == 1)
                    {
                        Console.WriteLine("Funktion 2");
                    }
                    else if (counter == 2)
                    {
                        Console.WriteLine("Funktion 3");
                    }
                    else if (counter == 3)
                    {

                        Console.WriteLine("Funktion 4");
                    }
                    else if (counter == 4)
                    {
                        Console.WriteLine("Funktion 5");
                    }
                    else if (counter == 5)
                    {

                        Console.WriteLine("Funktion 6");
                    }
                    else if (counter == 6)
                    {

                        Console.WriteLine("Funktion 7");
                    }
                    else
                    {
                        Console.WriteLine("Funktion 8");
                    }


                    do {
                        Console.WriteLine("Press SPACEBAR to go back to the main menu, press ESC to exit");
                        cki = Console.ReadKey();
                    } while ((cki.Key == ConsoleKey.Escape || cki.Key == ConsoleKey.Spacebar) == false);
                    


                }
                

            } while (cki.Key != ConsoleKey.Escape);
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine(" GGoodbye :)");
        }

        static void PrintLogo()
        {
            Console.WriteLine("\r\n  _____                                       _                   \r\n " +
                "|  __ \\                                     | |                  \r\n " +
                "| |__) | __ ___   __ _ _ __ __ _ _ __ ___   | | ___   __ _  ___  \r\n " +
                "|  ___/ '__/ _ \\ / _` | '__/ _` | '_ ` _ \\  | |/ _ \\ / _` |/ _ \\ \r\n " +
                "| |   | | | (_) | (_| | | | (_| | | | | | | | | (_) | (_| | (_) |\r\n " +
                "|_|   |_|  \\___/ \\__, |_|  \\__,_|_| |_| |_| |_|\\___/ \\__, |\\___/ \r\n" +
                "                   __/ |                               __/ |      \r\n " +
                "                 |___/                               |___/       \r\n");
        }


    }
}
