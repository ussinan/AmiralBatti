using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class AiHard : AiStrategy
    {
        private char[] rotation = new char[]{'L','R','U','D'};
        Random random = new Random();
        int[,] target = new int[8,2];
        public bool nextTarget = false;
        private int  targetTurn = 5;
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

        public void IncreaseHitCount() { }
        public void SetPreShot(int x, int y)
        {
        }
        public void IsTargetAvailable(string shipName, int x, int y) { }

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
                if(isOk)
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

        public void ResetTarget()
        {
            nextTarget = false;
            targetTurn = 5;
        }
        public void AimShot(int x, int y) {
            nextTarget = true;
            target[0, 0] = x - 1;
            target[0, 1] = y - 1;
            target[1, 0] = x - 1;
            target[1, 1] = y;
            target[2, 0] = x - 1;
            target[2, 1] = y + 1;
            target[3, 0] = x ;
            target[3, 1] = y+1;
            target[4, 0] = x +1;
            target[4, 1] = y+1;
            target[5, 0] = x+1;
            target[5, 1] = y;
            target[6, 0] = x+1;
            target[6, 1] = y-1;
            target[7, 0] = x ;
            target[7, 1] = y - 1;

        }
        public String TakeShots()
        {
            bool ctrl = true;
            int numX;
            int numY;
            if (nextTarget==false) {
                do
                {
                    numX = Convert.ToInt32(random.Next(0, 8));
                    numY = Convert.ToInt32(random.Next(0, 8));
                    ctrl = board.Shots(numX, numY);

                } while (ctrl == false);
                string s;
                s = "" + numX;
                s += numY;
                return s;
            }
            else
            {
                targetTurn--;
                int numI;
                int numJ;
                do
                {
                    numI = Convert.ToInt32(random.Next(0, 8));
                    ctrl = board.Shots(target[numI,0], target[numI,1]);
                } while (ctrl == false);
                string s;
                s = "" + target[numI,0];
                s += target[numI,1];
                return s;
            }
            
        }
    }
}
