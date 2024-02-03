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
            ConsoleKeyInfo cki;

            Models.Button[] buttonArr = new Models.Button[7]; 

            buttonArr[0] = new Models.Button(5,5,"Aufgabe 1");
            buttonArr[1] = new Models.Button(18, 5, "Aufgabe 2");
            buttonArr[2] = new Models.Button(31, 5, "Aufgabe 3 Writer");
            buttonArr[3] = new Models.Button(51, 5, "Aufgabe 3 Reader");
            buttonArr[4] = new Models.Button(5, 7, "Aufgabe 4 Verschlüssel");
            buttonArr[5] = new Models.Button(30, 7, "Aufgabe 4 Entschlüssel");
            buttonArr[6] = new Models.Button(55, 7, "Aufgabe 5");

            buttonArr[0].DrawButton(true);
            buttonArr[1].DrawButton(false);
            buttonArr[2].DrawButton(false);
            buttonArr[3].DrawButton(false);
            buttonArr[4].DrawButton(false);
            buttonArr[5].DrawButton(false);
            buttonArr[6].DrawButton(false);
            int buttonIndex = 0;

            do
            {


                cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    buttonArr[0].DrawButton();
                    buttonArr[1].DrawButton();
                    buttonArr[2].DrawButton();
                    buttonArr[3].DrawButton();
                    buttonArr[4].DrawButton();
                    buttonArr[5].DrawButton();
                    buttonArr[6].DrawButton();

                }
                else if (cki.Key == ConsoleKey.LeftArrow)
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
                    int counter = 0;
                    while (buttonArr[counter].IsSelected() != true)
                    {
                        counter++;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();

                    if(counter == 0)
                    {
                        Afg_1();
                        Console.WriteLine("Erledigt!");
                    }
                    else if (counter == 1)
                    {
                        Afg_2();
                    }
                    else if (counter == 2)
                    {
                        Afg_3_Writer();
                        Console.WriteLine("Erledigt!");
                    }
                    else if (counter == 3)
                    {
                        
                        Afg_3_Reader();
                    }
                    else if (counter == 4)
                    {
                        Afg_4_verschlüssel();
                    }
                    else if (counter == 5)
                    {
                        
                        Afg_4_entschlüssel();
                    }
                    else
                    {
                        Afg_5();
                    }
                    counter = 0;
                    Console.WriteLine("Drucken Sie die Leertaste");


                }
                

            } while (cki.Key != ConsoleKey.Escape);
            Console.SetCursorPosition(0,30);
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

                string etwas = sReader.ReadLine();
                Console.WriteLine(etwas);
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


            FileStream fs = new FileStream(@"C:\Filestream\afg4.txt", FileMode.Open, FileAccess.Write);

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
            FileStream fs = new FileStream(@"C:\Filestream\afg4.txt", FileMode.OpenOrCreate);

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

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{(char)(i + 97)}/{(char)(i + 65)} kommt {array[i],3} mal vor");
            }
            sr.Close();

        }
    }
}
