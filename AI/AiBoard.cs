using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class AiBoard
    {
        public String[,] shipPositions = new String[8, 8];
        public String[,] shots = new String[8, 8];
        private String ch = "*";

        public void Draw()
        {
            Console.WriteLine("    1    2    3    4    5    6    7    8");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" " + (i + 1) + "  ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(shipPositions[i, j] + "    ");
                }
                Console.WriteLine("");
            }
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

            
            int sY, sX;
            if (x > 7 || x < 0 || y < 0 || y > 7)
            {
                return false;
            }
                switch (c)
                {
                    case 'L':
                        if ((y - s) < 0)
                        {
                            return false;
                        }

                        sY = y;
                        for (int i = 0; i < s; i++)
                        {
                            if (shipPositions[x, sY] != ch)
                            {
                                return false;
                            }
                            sY--;
                        }
                        return true;

                    case 'R':
                        if ((y + s) > 7)
                        {
                            return false;
                        }
                        sY = y;
                        for (int i = 0; i < s; i++)
                        {
                            if (shipPositions[x, sY] != ch)
                            {
                                return false;
                            }
                            sY++;
                        }
                        return true;

                    case 'U':
                        if ((x - s) < 0)
                        {
                            return false;
                        }
                        sX = x;
                        for (int i = 0; i < s; i++)
                        {
                            if (shipPositions[sX, y] != ch)
                            {
                                return false;
                            }
                            sX--;
                        }
                        return true;

                    case 'D':
                        if ((x + s) > 7)
                        {
                            return false;
                        }
                        sX = x;
                        for (int i = 0; i < s; i++)
                        {
                            if (shipPositions[sX, y] != ch)
                            {
                                return false;
                            }
                            sX++;
                        }
                        return true;
            }
            return true;
        }
        public bool MediumPlacement(int x , int y, char c, int size)
        {

                switch (c)
            {
                case 'L':
                    if ((x - 1) >= 0)
                        for (int i = y; i > (y - size); i--)
                        {
                            if (shipPositions[x - 1, y] != "*")
                                return false;
                        }
                    if ((x + 1) < 8)
                    {
                        for (int i = y; i > (y - size); i++)
                        {
                            if (shipPositions[x + 1, y] != "*")
                                return false;
                        }
                    }
                    if ((y + 1) < 8)
                    {
                        if (shipPositions[x, y + 1] != "*")
                            return false;
                    }
                    if ((y - size) >= 0)
                    {
                        if (shipPositions[x, y - 1] != "*")
                            return false;
                    }
                    return true;
                    break;

                case 'R':
                    if ((x - 1) >= 0)
                        for (int i = y; i < (y + size); i++)
                        {
                            if (shipPositions[x - 1, y] != "*")
                                return false;
                        }
                    if ((x + 1) < 8)
                    {
                        for (int i = y; i > (y + size); i++)
                        {
                            if (shipPositions[x + 1, y] != "*")
                                return false;
                        }
                    }
                    if ((y + size) < 8)
                    {
                        if (shipPositions[x, y + 1] != "*")
                            return false;
                    }
                    if ((y - 1) >= 0)
                    {
                        if (shipPositions[x, y - 1] != "*")
                            return false;
                    }
                    return true;
                    break;
                case 'U':
                    if ((y - 1) >= 0)
                        for (int i = x; i > (x - size); i--)
                        {
                            if (shipPositions[x, y - 1] != "*")
                                return false;
                        }
                    if ((y + 1) < 8)
                    {
                        for (int i = x; i > (x - size); i++)
                        {
                            if (shipPositions[x, y + 1] != "*")
                                return false;
                        }
                    }
                    if ((x + 1) < 8)
                    {
                        if (shipPositions[x + 1, y] != "*")
                            return false;
                    }
                    if ((x - size) >= 0)
                    {
                        if (shipPositions[x - 1, y] != "*")
                            return false;
                    }
                    return true;
                    break;
                case 'D':
                    if ((y - 1) >= 0)
                        for (int i = x; i < (x + size); i++)
                        {
                            if (shipPositions[x, y - 1] != "*")
                                return false;
                        }
                    if ((y + 1) < 8)
                    {
                        for (int i = x; i > (x + size); i++)
                        {
                            if (shipPositions[x, y + 1] != "*")
                                return false;
                        }
                    }
                    if ((x + size) < 8)
                    {
                        if (shipPositions[x + 1, y] != "*")
                            return false;
                    }
                    if ((x - 1) >= 0)
                    {
                        if (shipPositions[x - 1, y] != "*")
                            return false;
                    }
                    return true;
                    break;
            }
            return true;
        }
        public void Place(int x, int y, char c, int s, string str)
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

        public bool Shots(int x, int y)
        {
            if ((x < 0) || x > 7 || y < 0 || y > 7)
                return false;
            else if (shots[x, y] != "*" ){
                return false;
            }
            else
            {
                shots[x, y] = "S";
                return true;
            }

        }
    }
}

