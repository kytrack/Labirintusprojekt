using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;

namespace ConsoleApp23
{
    class Program
    {
        /// <summary>
        /// Megadja, hogy hány termet tartamaz a térkép
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>Termek száma</returns>
        static int GetRoomNumber(char[,] map)
        {
            return -1;
        }
        /// <summary>
        /// A kapott térkép széleit végignézve megállapítja, hogy hány kijárat van.
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>Az alkalmas kijáratok száma</returns>
        static int GetSuitableEntrance(char[,] map)
        {
            return -1;
        }
        /// <summary>
        /// Megnézi, hogy van-e a térképen meg nem engedett karakter?
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>true - A térkép tartalmaz szabálytalan karaktert, false - nincs benne ilyen</returns>
        static bool IsInvalidElement(char[,] map)
        {
            return true;
        }
        /// <summary>
        /// Visszaadja azoknak a járatkaraktereknek a pozícióját, amelyekhez egyetlen szomszéd pozícióból sem lehet eljutni.
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>A pozíciók "sor_index:oszlop_index" formátumban szerepelnek a lista elemeiként
        static List<string> GetUnavailableElements(char[,] map)
        {
            List<string> unavailables = new List<string>();
            // ?
            // pld: string poz = "4:12"; 
            return unavailables;
        }
        /// <summary>
        /// Labiritust generál a kapott pozíciókat tartalmazó lista alapján. A lista elemei egymáshoz kapcsolódó járatok pozíciói.
        /// </summary>
        /// <param name="positionsList">"sor_index:oszlop_index" formátumban az egymáshoz kapcsolódó járatok pozícióit tartalmazó lista </param>
        /// <returns>A létrehozott labirintus térképe</returns>
        static char[,] GenerateLabyrinth(List<string> positionsList)
        {
            return null;
        }



        //sajat methodok



        /// <summary>
        /// Betölti a megadott nevű szöveges fájlból a pályát.
        /// </summary>
        /// <param name="palyaNeve">Az állomány elérési útja és neve</param>
        /// <returns>A létrehozott és adatokkal feltöltött char mátrixot adja vissza</returns>
        static char[,] LoadRoom(string mapName)
        {
            string[] sorok = File.ReadAllLines(mapName);
            char[,] map = new char[sorok.Length, sorok[0].Length];
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < map.GetLength(1); oszlopIndexe++)
                {
                    map[sorIndex, oszlopIndexe] = sorok[sorIndex][oszlopIndexe];
                }
            }
            return map;
        }


        /// <summary>
        /// A pálya megjelenítését végzi.
        /// </summary>
        /// <param name="map">A megjelenítendő pálya (tenger)</param>
        static void ShowRoom(char[,] map,char mode,int posX,int posY)
        {
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < map.GetLength(1); oszlopIndexe++)
                {
                    if (mode=='y')
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(map[sorIndex, oszlopIndexe]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        if (sorIndex==posX && oszlopIndexe==posY)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(map[sorIndex, oszlopIndexe]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.Write(map[sorIndex, oszlopIndexe]);
                        }
                    }
                }
                Console.WriteLine();
            }
        }


        static char SelectLanguage()
        {
            Console.WriteLine("Nyelv/Language h(magyar) / e(english):");
            char nyelvvalasztas;
            do
            {
                nyelvvalasztas = Console.ReadKey().KeyChar;
                if (nyelvvalasztas == 'h' || nyelvvalasztas == 'e')
                {
                    break;
                }

            } while (true);
            return nyelvvalasztas;
        }


        static char SelectMode()
        {
            char choosenMode;
            do
            {
                choosenMode = Console.ReadKey().KeyChar;
                if (choosenMode == 'y' || choosenMode == 'n')
                {
                    break;
                }

            } while (true);
            return choosenMode;
        }

        static char PosCharacterA(char[,] map, int posX, int posY)
        {
            char characterA = characterA = map[posX, posY];
            if (posY==0)
            {
                characterA = '.';
            }
            else
            {
                if (map[posX, posY - 1] == '.')
                {
                    characterA = '.';
                }
            }
            return characterA;
        }

        static char PosCharacterS(char[,] map, int posX, int posY)
        {
            char characterS = characterS = map[posX, posY];
            if (posX==map.GetLength(0)-1)
            {
                characterS = '.';
            }
            else
            {
                if (map[posX + 1, posY] == '.')
                {
                    characterS = '.';
                }
            }
            return characterS;
        }

        static char PosCharacterD(char[,] map, int posX, int posY)
        {
            char characterD = characterD = map[posX, posY];
            if (posY == map.GetLength(1) - 1)
            {
                characterD = '.';
            }
            else 
            {
                if (map[posX, posY + 1] == '.')
                {
                    characterD = '.';
                }
            }
            return characterD;
        }

        static char PosCharacterW(char[,] map,int posX,int posY)
        {
            char characterW= characterW = map[posX, posY];
            if (posX == 0)
            {
                characterW = '.';
            }
            else
            {
                if (map[posX - 1, posY] == '.')
                {
                    characterW = '.';
                }
            }
            return characterW;
        }



        const char KAR = '█';
        static void Main(string[] args)
        {
            //kezdokep
            string welcome = File.ReadAllText("labirintus.txt");
            Console.WriteLine(welcome);
            Console.ReadKey();
            Console.Clear();


            //nyelvvalasztas
            char standardLanguage= SelectLanguage();
            Console.Clear();

            Dictionary<string, string> gameDictoanary = new Dictionary<string, string> { { "hu1", "Add meg a játéktérkép nevét: " },
                                                                                         { "en1", "Enter the name of the game map: " },
                                                                                         { "hu2", "Fedett(y) vagy Fedetlen(n) térkép: " },
                                                                                         { "en2", "Covered(y) or Uncovered(n) map: " },
                                                                                         { "hu3", "Pálya neve: " },
                                                                                         { "en3", "Map name: " },
                                                                                         { "hu4", " mérete: " },
                                                                                         { "en4", " size: " },
                                                                                         { "hu5", "sor" },
                                                                                         { "en5", "row" },
                                                                                         { "hu6", "oszlop" },
                                                                                         { "en6", "column" },
                                                                                         { "hu7", "Lépések száma:" },
                                                                                         { "en7", "Number of steps:" },
                                                                                         { "hu8", "Termek száma:" },
                                                                                         { "en8", "Number of rooms:" },
                                                                                         { "hu9", "Felfedezett termek száma:" },
                                                                                         { "en9", "Number of discovered rooms:" },
                                                                                         { "hu10", "Felfedezett termek száma:" },
                                                                                         { "en10", "Number of discovered rooms:" }};

            //beallitasok
            string choosenMap;
            char choosenMode;
            if (standardLanguage=='h')
            {
                Console.WriteLine(gameDictoanary["hu1"]);
                choosenMap = Console.ReadLine();
            }
            else
            {
                Console.WriteLine(gameDictoanary["en1"]);
                choosenMap = Console.ReadLine();
            }
            Console.Clear();

            if (standardLanguage == 'h')
            {
                Console.WriteLine(gameDictoanary["hu2"]);
                choosenMode = SelectMode();
            }
            else
            {
                Console.WriteLine(gameDictoanary["en2"]);
                choosenMode = SelectMode();
            }


            //megjeleniti a mapot
            char[,]map = LoadRoom(choosenMap);
            int startPositionX = 0;
            int startPositionY = 0;
            List<char> elfogadhato = new List<char>() { '.', '╬', '═', '╦', '╩', '║', '╣', '╠', '╗', '╝', '╚', '╔', '█' };
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < map.GetLength(1); oszlopIndexe++)
                {
                    if ((sorIndex==0 && map[sorIndex, oszlopIndexe]== '╬') || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╩')
                        || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '║') ||(sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╣')
                        || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╠') || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╝')
                        || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╚')

                        || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╬') || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '═')
                        || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╦') || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╩')
                        || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╣') || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╗')
                        || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╝')

                        || (sorIndex == map.GetLength(0) && map[sorIndex, oszlopIndexe] == '╬') || (sorIndex == map.GetLength(0) && map[sorIndex, oszlopIndexe] == '╦')
                        || (sorIndex == map.GetLength(0) && map[sorIndex, oszlopIndexe] == '║') || (sorIndex == map.GetLength(0) && map[sorIndex, oszlopIndexe] == '╣')
                        || (sorIndex == map.GetLength(0) && map[sorIndex, oszlopIndexe] == '╠') || (sorIndex == map.GetLength(0) && map[sorIndex, oszlopIndexe] == '╗')
                        || (sorIndex == map.GetLength(0) && map[sorIndex, oszlopIndexe] == '╔')

                        || (oszlopIndexe == map.GetLength(1) && map[sorIndex, oszlopIndexe] == '╬') || (oszlopIndexe == map.GetLength(1) && map[sorIndex, oszlopIndexe] == '═')
                        || (oszlopIndexe == map.GetLength(1) && map[sorIndex, oszlopIndexe] == '╦') || (oszlopIndexe == map.GetLength(1) && map[sorIndex, oszlopIndexe] == '╩')
                        || (oszlopIndexe == map.GetLength(1) && map[sorIndex, oszlopIndexe] == '╠') || (oszlopIndexe == map.GetLength(1) && map[sorIndex, oszlopIndexe] == '╚')
                        || (oszlopIndexe == map.GetLength(1) && map[sorIndex, oszlopIndexe] == '╔'))
                    {
                        startPositionX = sorIndex;
                        startPositionY = oszlopIndexe;
                    }
                }
            }

            //'╬','═','╦','╩','║','╣','╠','╗','╝','╚', '╔'
            Console.Clear();

            int numberofSteps = 0;

            while (true)
            {
                //kiirasok
                if (standardLanguage == 'h')
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(gameDictoanary["hu3"]+choosenMap+ gameDictoanary["hu4"]+map.GetLength(0)+gameDictoanary["hu5"]+ " x " + gameDictoanary["hu6"]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(gameDictoanary["en3"]+choosenMap+ gameDictoanary["en4"]+map.GetLength(0)+gameDictoanary["en5"]+ " x " + gameDictoanary["en6"]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (standardLanguage == 'h')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(gameDictoanary["hu7"]+numberofSteps);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(gameDictoanary["en7"] + numberofSteps);
                    Console.BackgroundColor = ConsoleColor.Black;
                }





                ShowRoom(map, choosenMode, startPositionX, startPositionY);

                char bill = Console.ReadKey().KeyChar;
                if (bill == 'w' || bill == 's' || bill == 'a' || bill == 'd')
                {
                    if (startPositionX > -1 && bill == 'd')
                    {
                        if (PosCharacterD(map, startPositionX, startPositionY) != '.')
                        {
                            startPositionY = startPositionY + 1;
                            numberofSteps++;
                        }
                    }
                        else if (startPositionX > -1 && bill == 'w')
                        {
                        if (PosCharacterW(map, startPositionX, startPositionY) != '.')
                        {
                            startPositionX = startPositionX - 1;
                            numberofSteps++;
                        }
                    }
                            else if (map.GetLength(1) > startPositionY && bill == 'a')
                            {
                        if (PosCharacterA(map, startPositionX, startPositionY) != '.')
                        {
                            startPositionY = startPositionY - 1;
                            numberofSteps++;
                        }
                    }
                                else if (map.GetLength(0) > startPositionX && bill == 's')
                                {
                                    if (PosCharacterS(map, startPositionX, startPositionY) !='.')
                                    {
                                    startPositionX = startPositionX + 1;
                            numberofSteps++;
                                    }
                                }
                 }
                Console.Clear();
            }        
            Console.WriteLine(startPositionX + "," + startPositionY);
        }
    }
}
