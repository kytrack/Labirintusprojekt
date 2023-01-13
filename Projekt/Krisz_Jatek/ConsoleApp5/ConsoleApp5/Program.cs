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
        public static int GetRoomNumber(char[,] map)
        {
            int roomNumber = 0;

            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < map.GetLength(1); oszlopIndexe++)
                {
                    if (map[sorIndex, oszlopIndexe] == '█')
                    {
                        roomNumber++;
                    }
                }
            }
            return roomNumber;
        }
        /// <summary>
        /// A kapott térkép széleit végignézve megállapítja, hogy hány kijárat van.
        /// </summary>
        /// <param name="map">Labirintus mátrixa</param>
        /// <returns>Az alkalmas kijáratok száma</returns>
        static int GetSuitableEntrance(char[,] map)
        {
            int exits = 0;
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                char balOszlopChar = map[sorIndex, 0];
                switch (balOszlopChar)
                {
                    case '╬':
                    case '═':
                    case '╦':
                    case '╩':
                    case '╣':
                    case '╗':
                    case '╝':
                        exits++;
                        break;
                }
                char jobbOszlopChar = map[sorIndex, map.GetLength(1) - 1];
                switch (jobbOszlopChar)
                {
                    case '╬':
                    case '═':
                    case '╦':
                    case '╩':
                    case '╠':
                    case '╚':
                    case '╔':
                        exits++;
                        break;
                }
            }
            for (int oszlopIndexe = 1; oszlopIndexe < map.GetLength(1) - 1; oszlopIndexe++)
            {
                char felsoSorChar = map[0, oszlopIndexe];
                switch (felsoSorChar)
                {
                    case '╬':
                    case '╩':
                    case '║':
                    case '╣':
                    case '╠':
                    case '╝':
                    case '╚':
                        exits++;
                        break;
                }
                char alsoSorChar = map[map.GetLength(0) - 1, oszlopIndexe];
                switch (alsoSorChar)
                {
                    case '╬':
                    case '╦':
                    case '║':
                    case '╣':
                    case '╠':
                    case '╗':
                    case '╔':
                        exits++;
                        break;
                }
            }
            return exits;
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
        static void ShowRoom(char[,] map, char mode, int posX, int posY, string[]cells)
        {
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < map.GetLength(1); oszlopIndexe++)
                {
                    if (mode == 'y')
                    {
                        //
                        if (sorIndex == posX && oszlopIndexe == posY)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(map[sorIndex, oszlopIndexe]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (cells.Contains(sorIndex + "," + oszlopIndexe))
                        {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(map[sorIndex, oszlopIndexe]);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(map[sorIndex, oszlopIndexe]);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        
                    }
                    else
                    {
                        if (sorIndex == posX && oszlopIndexe == posY)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(map[sorIndex, oszlopIndexe]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            if (map[sorIndex, oszlopIndexe] == '.')
                            {
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(map[sorIndex, oszlopIndexe]);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(map[sorIndex, oszlopIndexe]);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
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
                nyelvvalasztas = Console.ReadKey(true).KeyChar;
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
                choosenMode = Console.ReadKey(true).KeyChar;
                if (choosenMode == 'y' || choosenMode == 'n')
                {
                    break;
                }

            } while (true);
            return choosenMode;
        }

        static char LeaveMap()
        {
            char choosenMode;
            do
            {
                choosenMode = Console.ReadKey(true).KeyChar;
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
            if (posY == 0)
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
            if (posX == map.GetLength(0) - 1)
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

        static char PosCharacterW(char[,] map, int posX, int posY)
        {
            char characterW = characterW = map[posX, posY];
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



        static string PossibleSteps(char[,] map, int posX, int posY)
        {
            //'╬','═','╦','╩','║','╣','╠','╗','╝','╚', '╔'
            string steps = "";
            if (map[posX, posY] == '╬')
            {
                steps = "WASD";
            }
            else if (map[posX, posY] == '═')
            {
                steps = "AD";
            }
            else if (map[posX, posY] == '╦')
            {
                steps = "ASD";
            }
            else if (map[posX, posY] == '╩')
            {
                steps = "WAD";
            }
            else if (map[posX, posY] == '║')
            {
                steps = "WS";
            }
            else if (map[posX, posY] == '╣')
            {
                steps = "WAS";
            }
            else if (map[posX, posY] == '╠')
            {
                steps = "WSD";
            }
            else if (map[posX, posY] == '╗')
            {
                steps = "AS";
            }
            else if (map[posX, posY] == '╝')
            {
                steps = "WA";
            }
            else if (map[posX, posY] == '╚')
            {
                steps = "WD";
            }
            else if (map[posX, posY] == '╔')
            {
                steps = "SD";
            }
            else if (map[posX, posY] == '█')
            {
                steps = "WASD";
            }
            return steps;
        }


        static void Main(string[] args)
        {
            //kezdokep
            string welcome = File.ReadAllText("labirintus.txt");
            Console.WriteLine(welcome);
            Console.ReadKey(true);
            Console.Clear();


            //nyelvvalasztas
            char standardLanguage = SelectLanguage();
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
                                                                                         { "hu8", "Felfedezett termek száma:" },
                                                                                         { "en8", "Number of discovered rooms:" },
                                                                                         { "hu9", "Továbblépési lehetőségek: " },
                                                                                         { "en9", "Possible steps:" },
                                                                                         { "hu10", "Észak" },
                                                                                         { "en10", "North" },
                                                                                         { "hu11", "Nyugat" },
                                                                                         { "en11", "West" },
                                                                                         { "hu12", "Dél" },
                                                                                         { "en12", "South" },
                                                                                         { "hu13", "Kelet" },
                                                                                         { "en13", "East" },
                                                                                         { "hu14", "Biztosan ki szeretnél menni?(y/n)" },
                                                                                         { "en14", "Are you sure you want to go out?(y/n)" },
                                                                                         { "hu15", "Vége a játéknak" },
                                                                                         { "en15", "End of the game" },};

            //beallitasok
            string choosenMap;
            char choosenMode;
            char choosenLeave;
            if (standardLanguage == 'h')
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
            char[,] map = LoadRoom(choosenMap);
            int startPositionX = 0;
            int startPositionY = 0;
            int numberofExits = GetSuitableEntrance(map);
            Dictionary<string, bool> exitCoords = new Dictionary<string, bool>();

            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < map.GetLength(1); oszlopIndexe++)
                {
                    if ((sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╬') || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╩')
                        || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '║') || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╣')
                        || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╠') || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╝')
                        || (sorIndex == 0 && map[sorIndex, oszlopIndexe] == '╚')

                        || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╬') || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '═')
                        || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╦') || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╩')
                        || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╣') || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╗')
                        || (oszlopIndexe == 0 && map[sorIndex, oszlopIndexe] == '╝')

                        || (sorIndex == map.GetLength(0)-1 && map[sorIndex, oszlopIndexe] == '╬') || (sorIndex == map.GetLength(0)-1 && map[sorIndex, oszlopIndexe] == '╦')
                        || (sorIndex == map.GetLength(0)-1 && map[sorIndex, oszlopIndexe] == '║') || (sorIndex == map.GetLength(0)-1 && map[sorIndex, oszlopIndexe] == '╣')
                        || (sorIndex == map.GetLength(0)-1 && map[sorIndex, oszlopIndexe] == '╠') || (sorIndex == map.GetLength(0)-1 && map[sorIndex, oszlopIndexe] == '╗')
                        || (sorIndex == map.GetLength(0)-1 && map[sorIndex, oszlopIndexe] == '╔')

                        || (oszlopIndexe == map.GetLength(1)-1 && map[sorIndex, oszlopIndexe] == '╬') || (oszlopIndexe == map.GetLength(1)-1 && map[sorIndex, oszlopIndexe] == '═')
                        || (oszlopIndexe == map.GetLength(1)-1 && map[sorIndex, oszlopIndexe] == '╦') || (oszlopIndexe == map.GetLength(1)-1 && map[sorIndex, oszlopIndexe] == '╩')
                        || (oszlopIndexe == map.GetLength(1)-1 && map[sorIndex, oszlopIndexe] == '╠') || (oszlopIndexe == map.GetLength(1)-1 && map[sorIndex, oszlopIndexe] == '╚')
                        || (oszlopIndexe == map.GetLength(1)-1 && map[sorIndex, oszlopIndexe] == '╔'))
                    {
                            startPositionX = sorIndex;
                            startPositionY = oszlopIndexe;
                            exitCoords.Add(sorIndex + "," + oszlopIndexe, false);
                    }
                }
            }

            //'╬','═','╦','╩','║','╣','╠','╗','╝','╚', '╔'
            Console.Clear();

            int numberofSteps = 0;
            string direction = "";
            int numberofRooms = GetRoomNumber(map);
            int discoveredRooms = 0;
            Dictionary<string, bool> roomCoords = new Dictionary<string, bool>();
            for (int sorIndex = 0; sorIndex < map.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < map.GetLength(1); oszlopIndexe++)
                {
                    if (map[sorIndex, oszlopIndexe] == '█')
                    {
                        roomCoords.Add(sorIndex + "," + oszlopIndexe, false);
                    }
                }
            }

            string possibleDirectionsW = "";
            string possibleDirectionsA = "";
            string possibleDirectionsS = "";
            string possibleDirectionsD = "";

            bool run = true;

            string[] showCells = new string[1000];
            int showCellsindex=0;

            while (run)
            {
                //kiirasok
                if (standardLanguage == 'h')
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(gameDictoanary["hu3"] + choosenMap + gameDictoanary["hu4"] + map.GetLength(0) + gameDictoanary["hu5"] + " x " + map.GetLength(1) + gameDictoanary["hu6"]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(gameDictoanary["en3"] + choosenMap + gameDictoanary["en4"] + map.GetLength(0) + gameDictoanary["en5"] + " x " + map.GetLength(1) + gameDictoanary["en6"]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (standardLanguage == 'h')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(gameDictoanary["hu7"] + numberofSteps + " , " + gameDictoanary["hu8"] + discoveredRooms + "/" + numberofRooms);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(gameDictoanary["en7"] + numberofSteps + " , " + gameDictoanary["en8"] + discoveredRooms + "/" + numberofRooms);
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (PossibleSteps(map, startPositionX, startPositionY).Contains("W"))
                {
                    if (standardLanguage == 'h')
                    {
                        possibleDirectionsW = gameDictoanary["hu10"] + ",";
                    }
                    else
                    {
                        possibleDirectionsW = gameDictoanary["en10"] + ",";
                    }
                }
                else
                {
                    possibleDirectionsW = "";
                }

                if (PossibleSteps(map, startPositionX, startPositionY).Contains("A"))
                {
                    if (standardLanguage == 'h')
                    {
                        possibleDirectionsA = gameDictoanary["hu11"] + ",";
                    }
                    else
                    {
                        possibleDirectionsA = gameDictoanary["en11"] + ",";
                    }
                }
                else
                {
                    possibleDirectionsA = "";
                }

                if (PossibleSteps(map, startPositionX, startPositionY).Contains("S"))
                {
                    if (standardLanguage == 'h')
                    {
                        possibleDirectionsS = gameDictoanary["hu12"] + ",";
                    }
                    else
                    {
                        possibleDirectionsS = gameDictoanary["en12"] + ",";
                    }
                }
                else
                {
                    possibleDirectionsS = "";
                }

                if (PossibleSteps(map, startPositionX, startPositionY).Contains("D"))
                {
                    if (standardLanguage == 'h')
                    {
                        possibleDirectionsD = gameDictoanary["hu13"] + ",";
                    }
                    else
                    {
                        possibleDirectionsD = gameDictoanary["en13"] + ",";
                    }
                }
                else
                {
                    possibleDirectionsD = "";
                }

                
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(gameDictoanary["hu9"] + possibleDirectionsW + possibleDirectionsA + possibleDirectionsS + possibleDirectionsD);
                Console.BackgroundColor = ConsoleColor.Black;

                //map

                ShowRoom(map, choosenMode, startPositionX, startPositionY, showCells);

                char bill = Console.ReadKey(true).KeyChar;
                if (bill == 'w' || bill == 's' || bill == 'a' || bill == 'd')
                {
                    if (startPositionX > -1 && bill == 'd')
                    {
                        if (exitCoords.ContainsKey(startPositionX + "," + startPositionY))
                        {
                            if (bill == 'd' && map.GetLength(1) - 1 == startPositionY)
                            {
                                if (numberofRooms != discoveredRooms)
                                {
                                    if (standardLanguage == 'h')
                                    {
                                        Console.WriteLine(gameDictoanary["hu14"]);
                                    }
                                    else
                                    {
                                        Console.WriteLine(gameDictoanary["en14"]);
                                    }
                                    choosenLeave = LeaveMap();
                                    if (choosenLeave == 'y')
                                    {
                                        run = false;
                                    }
                                }
                                else
                                {
                                    run = false;
                                }
                            }
                        }
                        if ((PosCharacterD(map, startPositionX, startPositionY) != '.') && PossibleSteps(map, startPositionX, startPositionY).Contains("D"))
                        {
                            showCells[showCellsindex] = startPositionX + "," + startPositionY;
                            showCellsindex++;
                            startPositionY = startPositionY + 1;
                            numberofSteps++;

                            if (roomCoords.ContainsKey(startPositionX + "," + startPositionY))
                            {
                                if (roomCoords[startPositionX + "," + startPositionY] == false)
                                {
                                    roomCoords[startPositionX + "," + startPositionY] = true;
                                    discoveredRooms++;
                                }
                            }
                        }
                    }
                    else if (startPositionX > -1 && bill == 'w')
                    {
                        if (exitCoords.ContainsKey(startPositionX + "," + startPositionY))
                        {
                            if ((bill == 'w') && 0 == startPositionX)
                            {
                                if (numberofRooms != discoveredRooms)
                                {
                                    if (standardLanguage == 'h')
                                    {
                                        Console.WriteLine(gameDictoanary["hu14"]);
                                    }
                                    else
                                    {
                                        Console.WriteLine(gameDictoanary["en14"]);
                                    }
                                    choosenLeave = LeaveMap();
                                    if (choosenLeave == 'y')
                                    {
                                        run = false;
                                    }
                                }
                                else
                                {
                                    run = false;
                                }
                            }
                        }
                        if ((PosCharacterW(map, startPositionX, startPositionY) != '.') && PossibleSteps(map, startPositionX, startPositionY).Contains("W"))
                        {
                            showCells[showCellsindex] = startPositionX + "," + startPositionY;
                            showCellsindex++;
                            startPositionX = startPositionX - 1;
                            numberofSteps++;

                            if (roomCoords.ContainsKey(startPositionX + "," + startPositionY))
                            {
                                if (roomCoords[startPositionX + "," + startPositionY] == false)
                                {
                                    roomCoords[startPositionX + "," + startPositionY] = true;
                                    discoveredRooms++;
                                }
                            }
                        }
                    }
                    else if ((map.GetLength(1) > startPositionY && bill == 'a') && PossibleSteps(map, startPositionX, startPositionY).Contains("A"))
                    {
                        if (exitCoords.ContainsKey(startPositionX + "," + startPositionY))
                        {
                            if ((bill == 'a') && 0 == startPositionY)
                            {
                                if (numberofRooms!=discoveredRooms)
                                {
                                    if (standardLanguage=='h')
                                    {
                                        Console.WriteLine(gameDictoanary["hu14"]);
                                    }
                                    else
                                    {
                                        Console.WriteLine(gameDictoanary["en14"]);
                                    }
                                    choosenLeave = LeaveMap();
                                    if (choosenLeave=='y')
                                    {
                                        run = false;
                                    }
                                }
                                else
                                {
                                    run = false;
                                }
                            }
                        }
                        if (PosCharacterA(map, startPositionX, startPositionY) != '.')
                        {
                            showCells[showCellsindex] = startPositionX + "," + startPositionY;
                            showCellsindex++;
                            startPositionY = startPositionY - 1;
                            numberofSteps++;

                            if (roomCoords.ContainsKey(startPositionX + "," + startPositionY))
                            {
                                if (roomCoords[startPositionX + "," + startPositionY] == false)
                                {
                                    roomCoords[startPositionX + "," + startPositionY] = true;
                                    discoveredRooms++;
                                }
                            }
       

                        }
                    }
                    else if ((map.GetLength(0) > startPositionX && bill == 's') && PossibleSteps(map, startPositionX, startPositionY).Contains("S"))
                    {
                        if (exitCoords.ContainsKey(startPositionX + "," + startPositionY))
                        {
                            if ((bill == 's') && map.GetLength(0)-1==startPositionX)
                            {
                                if (numberofRooms != discoveredRooms)
                                {
                                    if (standardLanguage == 'h')
                                    {
                                        Console.WriteLine(gameDictoanary["hu14"]);
                                    }
                                    else
                                    {
                                        Console.WriteLine(gameDictoanary["en14"]);
                                    }
                                    choosenLeave = LeaveMap();
                                    if (choosenLeave == 'y')
                                    {
                                        run = false;
                                    }
                                }
                                else
                                {
                                    run = false;
                                }
                            }
                        }
                        if (PosCharacterS(map, startPositionX, startPositionY) != '.')
                        {
                            showCells[showCellsindex] = startPositionX + "," + startPositionY;
                            showCellsindex++;
                            startPositionX = startPositionX + 1;
                            numberofSteps++;

                            if (roomCoords.ContainsKey(startPositionX + "," + startPositionY))
                            {
                                if (roomCoords[startPositionX + "," + startPositionY] == false)
                                {
                                    roomCoords[startPositionX + "," + startPositionY] = true;
                                    discoveredRooms++;
                                }
                            }
                        }
                    }
                }
                Console.Clear();
            }
            if (standardLanguage=='i')
            {
                Console.WriteLine(gameDictoanary["hu15"]);
            }
            else
            {
                Console.WriteLine(gameDictoanary["en15"]);
            }
            
        }
    }
}
