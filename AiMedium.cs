using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class AiMedium : AiStrategy
    {
        private char[] rotation = new char[] { 'L', 'R', 'U', 'D' };
        
        Random random = new Random();
         
        private int hitCount = 0,failCount=0;
        int preShotX=-1, preShotY=-1;
        int mod = 0;
        int aimTargetX1 = 0,aimTargetX2=0, aimTargetY1 = 0,aimTargetY2=0;
        public bool nextTarget = false,consHit = false;
        private int targetTurn = 5;
        private String ch = "*";
        private String shotShip = null;
        private static String name = "AI";
        private int shipCount = 5;
        public TorpedoBoat torpedoboat = new TorpedoBoat();
        public Cruiser cruiser = new Cruiser();
        public Corvette corvette = new Corvette();
        public Battleship battleship = new Battleship();
        public AircraftCarrier aircraftcarrier = new AircraftCarrier();

        public AiBoard board = new AiBoard();

        public void Position()
        {
            board.Position();
        }

        public void Draw()
        {
            board.Draw();
        }

        public int GetShipCount()
        {
            return shipCount;
        }

        public void SetShipCount()
        {
            shipCount--;
        }

        public void SetFailCount()
        {
            failCount++;
        }
        public void SetPreShot(int x,int y)
        {

            if (preShotX == -1 && preShotY == -1)
            {
                consHit = false;
            }
            else
                consHit = true;
            preShotX = x;
            preShotY = y;
        }
        public void PlaceShips(Ships s)
        {

            bool isOk = false;


            do
            {
                int numX = Convert.ToInt32(random.Next(0, 8));
                int numY = Convert.ToInt32(random.Next(0, 8));
                int rot = Convert.ToInt32(random.Next(0, 4));

                isOk = board.CanBePlaced(numX, numY, rotation[rot], s.GetShipSize());
                if (isOk)
                    board.MediumPlacement(numX, numY, rotation[rot], s.GetShipSize());
                if (isOk)
                {

                    board.Place(numX, numY, rotation[rot % 4], s.GetShipSize(), s.GetShortName());
                    s.setCoordinates(numX, numY);

                    break;
                }
                rot++;
            } while (isOk == false);

        }

        public string IsShot(int x, int y)
        {
            if (board.shipPositions[x, y] != ch)
            {
                switch (board.shipPositions[x, y])
                {
                    case "T":
                        torpedoboat.SetShipSize();
                        return "T";
                    case "K":
                        cruiser.SetShipSize();
                        return "K";
                    case "R":
                        corvette.SetShipSize();
                        return "R";
                    case "Z":
                        battleship.SetShipSize();
                        return "Z";
                    case "U":
                        aircraftcarrier.SetShipSize();
                        return "U";
                }
                return "H";
            }
            else
                return null;
        }

        public string isSinked(String s)
        {

            switch (s)
            {
                case "T":

                    if (torpedoboat.GetShipSize() == 0)
                    {
                        SetShipCount();
                        return torpedoboat.GetShipName();
                    }
                    break;
                case "K":
                    if (cruiser.GetShipSize() == 0)
                    {
                        SetShipCount();
                        return cruiser.GetShipName();
                    }
                    break;
                case "R":
                    if (corvette.GetShipSize() == 0)
                    {
                        SetShipCount();
                        return corvette.GetShipName();
                    }
                    break;
                case "Z":
                    if (battleship.GetShipSize() == 0)
                    {
                        SetShipCount();
                        return battleship.GetShipName();
                    }
                    break;
                case "U":
                    if (aircraftcarrier.GetShipSize() == 0)
                    {
                        SetShipCount();
                        return aircraftcarrier.GetShipName();
                    }
                    break;
            }
            return null;
        }

        public void ResetTarget() { }

        public void AimShot(int x,int y)
        {
            int[,] arr = new int[4, 2] { { x - 1, y }, { x, y + 1 }, { x + 1, y }, { x, y - 1 } };
            if (consHit == false)
            {
                if (mod % 4 == 0)
                {
                    aimTargetX1 = arr[0, 0];
                    aimTargetY1 = arr[0, 1];
                }
                else if (mod % 4 == 1)
                {
                    aimTargetX1 = arr[1, 0];
                    aimTargetY1 = arr[1, 1];

                }
                else if (mod % 4 == 2)
                {
                    aimTargetX1 = arr[2, 0];
                    aimTargetY1 = arr[2, 1];

                }
                else if (mod % 4 == 3)
                {
                    aimTargetX1 = arr[3, 0];
                    aimTargetY1 = arr[3, 1];
                }
                mod++;
            }
            else if (consHit)
            {
                int Xmar = x - preShotX;
                int Ymar = y - preShotY;
                if (Xmar > 0 )
                {
                    aimTargetY1 = y;
                    if(x==7)
                        aimTargetX1 = preShotX - 1;
                    else 
                        aimTargetX1 = x + 1;

                } 
                else if (Xmar < 0)
                {
                    aimTargetY1 = y;
                    if (x == 0)
                        aimTargetX1 = preShotX + 1;
                    else
                        aimTargetX1 = x + 1;
                }
                else if(Ymar >0)
                {
                    aimTargetX1 = x;
                    if (y==7)
                        aimTargetY1 = preShotY - 1;
                    else
                        aimTargetY1 = y + 1;
                }
                else if (Ymar < 0)
                {
                    aimTargetX1 = x;
                    if (y== 0)
                        aimTargetY1 = preShotY - 1;
                    else
                        aimTargetY1 = y - 1;
                }

            }
         

        }

        public void IncreaseHitCount()
        {
            hitCount++;
        }
         public void ResetHitCount()
        {
            hitCount = 0;
        }
        public void IsTargetAvailable(string shipName,int x,int y)
        {
            int size = 0;
            string s1 = torpedoboat.GetShipName();


            switch (shipName)
            {
                case ("Torpido Botu"):
                    size = torpedoboat.GetShipSize();
                    break;
                case ("Kruvazör"):
                    size = cruiser.GetShipSize();
                    break;
                case ("Korvet"):
                    size = corvette.GetShipSize();
                    break;
                case ("Zırhlı"):
                    size=battleship.GetShipSize();
                    break;
                case ("Uçak Gemisi"):
                    size=aircraftcarrier.GetShipSize();
                    break;
            }
            if ((hitCount - size) > 0)
            {
                nextTarget = true;
                int Xmar = x - preShotX;
                int Ymar = y - preShotY;
                if (Xmar > 0)
                {
                    aimTargetY1 = y;
                    aimTargetX1 = x -size;
                }
                else if (Xmar < 0)
                {
                    aimTargetY1 = y;
                    aimTargetX1 = x +size;
                }
                else if (Ymar > 0)
                {
                    aimTargetY1 = y + size;
                    aimTargetX1 = x;
                }
                else if (Ymar < 0)
                {
                    aimTargetY1 = y - size;
                    aimTargetX1 = x;
                }


            }
            else if (hitCount == size)
            {
                nextTarget = false;
                preShotX = -1;
                preShotY = -1;
                consHit = false;
                hitCount = 0;
            }


        }
        public void AimTarget()
        {
            if (mod % 4 == 0)
            {
                aimTargetX1 = 0;
                aimTargetX2= 4;
                aimTargetY1 = 0;
                aimTargetY2 = 4;
            }
            else if ( mod % 4 == 1)
            {
                aimTargetX1 = 0;
                aimTargetX2 = 4;
                aimTargetY1 = 4;
                aimTargetY2 = 8;

            }
            else if (mod % 4 == 2)
            {
                aimTargetX1 = 4;
                aimTargetX2 = 8;
                aimTargetY1 = 0;
                aimTargetY2 = 4;
            }
            else if ( mod % 4 == 3)
            {
                aimTargetX1 = 4;
                aimTargetX2 = 8;
                aimTargetY1 = 4;
                aimTargetY2 = 8;
            }
        }
        public String TakeShots()
        {
            bool ctrl = true;
            int numX;
            int numY;
            if (nextTarget == false || failCount >=4)
            {
                do
                {
                    AimTarget();
                    numX = Convert.ToInt32(random.Next(aimTargetX1,aimTargetX2));
                    numY = Convert.ToInt32(random.Next(aimTargetY1, aimTargetY2));
                    ctrl = board.Shots(numX, numY);

                } while (ctrl == false);
                string s;
                s = "" + numX;
                s += numY;
                return s;
            }
            else
            {
                AimShot(preShotX, preShotY);
                if (aimTargetX1 < 0 || aimTargetX1 > 7 || aimTargetY1 > 7 || aimTargetY1 < 0)
                {
                    do
                    {
                        numX = Convert.ToInt32(random.Next(aimTargetX1, aimTargetX2));
                        numY = Convert.ToInt32(random.Next(aimTargetY1, aimTargetY2));
                        ctrl = board.Shots(numX, numY);

                    } while (ctrl == false);
                    string st;
                    st = "" + numX;
                    st += numY;
                    return st;
                }
                else
                {
                    do
                    {
                        ctrl = board.Shots(aimTargetX1, aimTargetY1);
                    } while (ctrl == false);
                    string s;
                    s = "" + aimTargetX1;
                    s += aimTargetY1;
                    return s;
                }
            }

        }
    }
}
