using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace editor
{
    class editor
    {
        static void Main(string[] args)
        {
            List<char> elemek = new List<char>() { '.', '╬', '═', '╦', '╩', '║', '╣', '╠', '╗', '╝', '╚', '╔', '█' };
            char[,] map = Generate(5, 10);
            while (true)
            {
                switch (Menu())
                {
                    case 'p':
                        Console.Write("\nHány sorból álljon ? :");
                        int sorSzam = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nHány oszlopból álljon ? :");
                        int oszlopSzam = Convert.ToInt32(Console.ReadLine());
                        map = Generate(sorSzam, oszlopSzam);
                        UpdateConsole(map, true);
                        break;
                    case 'e':
                        int sor;
                        int oszlop;
                        int hely;
                        do
                        {
                            try
                            {
                                Console.WriteLine("Add meg a sort ahova le szeretnéd rakni az elemet (A kilépéshez nyomj entert):");
                                sor = Convert.ToInt32(Console.ReadLine())-1;
                                Console.WriteLine("Add meg az oszlopot ahova le szeretnéd rakni az elemet:");
                                oszlop = Convert.ToInt32(Console.ReadLine())-1;
                                Console.WriteLine("Add meg a karaktert amelyet le szeretnél rakni");
                                Console.WriteLine("(0). (1)╬ (2)═ (3)╦ (4)╩ (5)║ (6)╣ (7)╠ (8)╗ (9)╝ (10)╚ (11)╔ (12)█");
                                hely = Convert.ToInt32(Console.ReadLine());
                                map[sor, oszlop] = elemek[hely];
                                UpdateConsole(map, true);

                            }
                            catch (System.FormatException)
                            {
                                break;
                            }

                        } while (true);
                        UpdateConsole(map, true);
                        break;
                    case 'b':
                        map = Betoltes(Environment.CurrentDirectory + @"\map.txt");
                        UpdateConsole(map, true);
                        break;
                    case 'm':
                        Mentes(map, Environment.CurrentDirectory + @"\map.txt");
                        break;
                    case 'k':
                        System.Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }


        }

        static char Menu()
        {
            Console.WriteLine("\nMenü");
            Console.WriteLine("\t[p]álya generálása");
            Console.WriteLine("\t[e]lemek elhelyezése");
            Console.WriteLine("\t[b]etöltés fájlból");
            Console.WriteLine("\t[m]entés fájlba");
            Console.WriteLine("\t[k]ilépés a programból");
            Console.Write("Kérem válasszon! ");
            char betu;
            do
            {
                betu = Console.ReadKey().KeyChar;
                if (betu == 'p' || betu == 'e' || betu == 'b' || betu == 'm' || betu == 'k')
                {
                    break;
                }
            } while (true);
            Console.WriteLine();
            return betu;
        }


        static char[,] Generate(int rowcount, int colcount)
        {
            char[,] newMap = new char[rowcount, colcount];
            Alap(newMap);
            return newMap;
        }


        static void Alap(char[,] palya)
        {
            for (int row = 0; row < palya.GetLength(0); row++)
            {
                for (int col = 0; col < palya.GetLength(1); col++)
                {
                    palya[row, col] = '.';
                }
            }
        }

        static char[,] Betoltes(string path)
        {
            string[] lines = File.ReadAllLines(path);
            char[,] map = new char[lines.Length, lines[0].Length];
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = lines[row][col];
                }
            }
            return map;
        }
        static void Mentes(char[,] map, string mapName)
        {
            string[] lines = new string[map.GetLength(0)];
            string line = "";
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    line += map[row, col];
                }
                lines[row] = line;
                line = "";
            }
            File.WriteAllLines(mapName, lines);
        }


        static void UpdateConsole(char[,] map, bool border = false)
        {
            Console.Clear();
            if (border)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(' ');
                for (int col = 1; col <= map.GetLength(1); col++)
                {
                    if (col % 10 == 0)
                    {
                        Console.Write('.');
                    }
                    else
                    {
                        Console.Write(col % 10);
                    }
                }
            }
            Console.WriteLine();
            for (int row = 0; row < map.GetLength(0); row++)
            {
                if (border)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if ((row + 1) % 10 == 0)
                    {
                        Console.Write('.');
                    }
                    else
                    {
                        Console.Write((row + 1) % 10);
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                for (int coli = 0; coli < map.GetLength(1); coli++)
                {
                    Console.Write(map[row, coli]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }


    }
}
