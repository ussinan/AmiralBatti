using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class PlayerBoard
    {
        private static String[,] shipPositions = new String[8, 8];
        private static String[,] shots = new String[8, 8];

        public void Draw()
        {
            Console.WriteLine("    1    2    3    4    5    6    7    8");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" " + (i + 1) + "  ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(shipPositions[i,j]+"    ");
                }
                Console.WriteLine("");
            }
        }

        public string GetShipPosition(int x , int y)
        {
            return shipPositions[x, y];
        }

        public void SetShotShipPosition(int x,int y)
        {
            shipPositions[x, y] = "V";
        }

        public void Position()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    shots[i, j] = "*";
                    shipPositions[i, j] = "*";
                }
            }
        }
        public bool CanBePlaced(int x, int y, char c, int s)
        {
            x--;
            y--;
            String ch = "*";
            int sY, sX;
            if (x > 7 || x < 0 || y < 0 || y > 7)
            {
                Console.WriteLine("Gemileri karadan yürütemezsiniz!!!\n\n");
                return false;
            }

            switch (c)
            {
                case 'L':
                    if ((y - s) < -1)
                    {
                        Console.WriteLine("Gemileri karadan yürütemezsiniz!!!\n\n");
                        Console.WriteLine();
                        return false;
                    }

                    sY = y;
                    for (int i = 0; i < s; i++)
                    {
                        if (shipPositions[x, sY] != ch)
                        {
                            Console.WriteLine("Gemileri üst üste yerleştiremezsiniz!!!\n\n");
                            return false;
                        }
                        sY--;
                    }
                    return true;

                case 'R':
                    if ((y + s) > 8)
                    {
                        Console.WriteLine("Gemileri karadan yürütemezsiniz!!!\n\n");
                        return false;
                    }
                    sY = y;
                    for (int i = 0; i < s; i++)
                    {
                        if (shipPositions[x, sY] != ch)
                        {
                            Console.WriteLine("Gemileri üst üste yerleştiremezsiniz!!!\n\n");
                            return false;
                        }
                        sY++;
                    }
                    return true;

                case 'U':
                    if ((x - s) < -1)
                    {
                        Console.WriteLine("Gemileri karadan yürütemezsiniz!!!\n\n");
                        return false;
                    }
                    sX = x;
                    for (int i = 0; i < s; i++)
                    {
                        if (shipPositions[sX, y] != ch)
                        {
                            Console.WriteLine("Gemileri üst üste yerleştiremezsiniz!!!\n\n");
                            return false;
                        }
                        sX--;
                    }
                    return true;

                case 'D':
                    if ((x + s) > 8)
                    {
                        Console.WriteLine("Gemileri karadan yürütemezsiniz!!!\n\n");
                        return false;
                    }
                    sX = x;
                    for (int i = 0; i < s; i++)
                    {
                        if (shipPositions[sX, y] != ch)
                        {
                            Console.WriteLine("Gemileri üst üste yerleştiremezsiniz!!!\n\n");
                            return false;
                        }
                        sX++;
                    }
                    return true;

            }
            return true;
        }

        public void Place(int x, int y, char c, int s,String str)
        {

            switch (c)
            {
                case 'L':
                    for (int i = 0; i < s; i++)
                    {
                        shipPositions[x, y] = str;
                        y--;
                    }
                    break;
                case 'R':
                    for (int i = 0; i < s; i++)
                    {
                        shipPositions[x, y] = str;
                        y++;
                    }
                    break;
                case 'U':
                    for (int i = 0; i < s; i++)
                    {
                        shipPositions[x, y] = str;
                        x--;
                    }
                    break;
                case 'D':
                    for (int i = 0; i < s; i++)
                    {
                        shipPositions[x, y] = str;
                        x++;
                    }
                    break;
            }
        }

        public void DrawTakenShots(int x, int y, String s)
        {
            shipPositions[x, y] = s;
            Console.WriteLine("    1    2    3    4    5    6    7    8");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" " + (i + 1) + "  ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(shipPositions[i,j] + "    ");
                }
                Console.WriteLine("");
            }
        }

        public void DrawShots(int x,int y,String s)
        {
            shots[x, y] = s;
            Console.WriteLine("    1    2    3    4    5    6    7    8");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" " + (i + 1) + "  ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(shots[i, j] + "    ");
                }
                Console.WriteLine("");
            }
        }

        public void DrawShotTable()
        {
            Console.WriteLine("    1    2    3    4    5    6    7    8");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" " + (i + 1) + "  ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(shots[i, j] + "    ");
                }
                Console.WriteLine("");
            }
        }

        public bool Shots(int x,int y)
        {
            if (shots[x, y] != "*")
                return false;
            else
            {
                return true;
            }
            
        }

}
}
