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


        static void Afg_1()
        {

            FileStream fs = new FileStream(@"C:\Filestream\afg1.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fs);

            streamWriter.WriteLine("Just a test");

            streamWriter.Close();
        }

        static void Afg_2()
        {

            Console.Write("Die Dateipfad: ");
            try
            {
                FileStream fs = new FileStream(@"" + Console.ReadLine(), FileMode.OpenOrCreate);
                StreamReader sReader = new StreamReader(fs);
                string etwas;
                do
                {
                    etwas = sReader.ReadLine();
                    Console.WriteLine(etwas);

                } while ((!sReader.EndOfStream));

                sReader.Close();
            }
            catch
            {
                Console.WriteLine("Ungültige eingabe!");
            }


            
        }

        static void FillArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 2;
            }
        }
        static void Remover(int[] array, int max)
        {
            int entferner = 2;

            while (entferner * entferner <= max)
            {
                int i = entferner - 2;

                while (array[i] == 0)
                {
                    i = ++entferner - 2;
                }

                i += entferner;
                while (i < array.Length)
                {
                    array[i] = 0;
                    i += entferner;
                }

                entferner++;

            }
        }

        static void PrintArray2(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] != 0)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }
        static void Afg_3_Writer()
        {
            string pfad = @"C:\Filestream\afg3.txt";
            FileStream fs = new FileStream(@pfad, FileMode.OpenOrCreate);
            StreamWriter sWriter = new StreamWriter(fs);

            int max = 1000;
            int[] array = new int[max - 1];


            FillArray(array);
            Remover(array, max);
            //PrintArray(array);
            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] != 0)
                {
                    sWriter.Write($"{array[i]},");
                }
            }
            sWriter.Close();
            



        }
        static void Afg_3_Reader()
        {
            string pfad = @"C:\Filestream\afg3.txt";
            FileStream fs = new FileStream(@pfad, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string primes = sr.ReadLine();
            string[] strArray = primes.Split(',');
            foreach (string str in strArray)
            {
                Console.Write($"{str} ");
            }
            sr.Close();
        }

        static void Afg_4_verschlüssel()
        {


            FileStream fs = new FileStream(@"C:\Filestream\afg4.txt", FileMode.Create, FileAccess.Write);

            StreamWriter sr = new StreamWriter(fs);

            Console.Write("Text: ");
            string text = Console.ReadLine();
            string verschlüsselt = "";
            Random rnd = new Random();

            for (int i = 0; i < text.Length; i++)
            {
                verschlüsselt += text[i];
                verschlüsselt += (char)rnd.Next(32, 127);
                verschlüsselt += (char)rnd.Next(32, 127);
            }
            sr.WriteLine(verschlüsselt);
            sr.Close();
        }
        static void Afg_4_entschlüssel()
        {
            FileStream fs = new FileStream(@"C:\Filestream\afg4.txt", FileMode.Open, FileAccess.Read);

            string ausgabe = "";
            fs.Seek(0, SeekOrigin.Begin);
            int c;
            int counter = 0;
            while ((c = fs.ReadByte()) != -1)
            {
                if (counter % 3 == 0)
                {
                    ausgabe += (char)c;
                }
                counter++;
            }

            Console.WriteLine(ausgabe);
            fs.Close();
        }

        static void Afg_5()
        {
            int[] array = new int[26];
            FileStream fs = new FileStream(@"C:\Filestream\new.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string buffer;

            do
            {
                buffer = sr.ReadLine().ToLower();


                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] >= 97 && buffer[i] <= 122)
                    {
                        array[buffer[i] - 97]++;
                    }
                }

            } while ((!sr.EndOfStream));
            sr.Close();


            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{(char)(i + 97)}/{(char)(i + 65)} kommt {array[i],3} mal vor");
            }
            Console.WriteLine();

        }
    }
}
