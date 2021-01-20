using System;
using System.Collections.Generic;
using System.Text;


namespace AmiralBatti
{
    class AiEasy : AiStrategy
    {
        Random random = new Random();
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

        public void ResetTarget() { }
        public void IncreaseHitCount() { }
        public void IsTargetAvailable(string shipName, int x, int y) { }

        public void SetPreShot(int x, int y)
        {
        }
        public void Position()
        {
            board.Position();
        }
        public void SetFailCount()
        {
        }

        public void Draw()
        {
            board.Draw();
        }

        public void AimShot(int x, int y) { }
        public int GetShipCount()
        {
            return shipCount;
        }

        public void SetShipCount()
        {
            shipCount--;
        }
        public void PlaceShips(Ships s)
        {

            bool isOk = false;


            do
            {
                int numX = Convert.ToInt32(random.Next(0, 8));
                int numY = Convert.ToInt32(random.Next(0, 8));
                int rot = Convert.ToInt32(random.Next(1, 5));
                char rotation = 'L';
                switch (rot)
                {
                    case 1:
                        rotation = 'L';
                        break;
                    case 2:
                        rotation = 'R';
                        break;
                    case 3:
                        rotation = 'U';
                        break;
                    case 4:
                        rotation = 'D';
                        break;
                }
                isOk = board.CanBePlaced(numX, numY, rotation, s.GetShipSize());

                if (isOk)
                {
                    board.Place(numX, numY, rotation, s.GetShipSize(), s.GetShortName());
                    s.setCoordinates(numX, numY);

                    break;
                }
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
        public String TakeShots() {
            bool ctrl=true;
            int numX;
            int numY;
            do
            {
                numX = Convert.ToInt32(random.Next(0, 8));
                numY = Convert.ToInt32(random.Next(0, 8));
                ctrl = board.Shots(numX, numY);
              
            } while (ctrl==false);
            string s;
            s = "" + numX;
            s += numY;
            return s;
        }
    }
    }

