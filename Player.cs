using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class Player
    {
        private static String name = "Oyuncu";
        private int shipCount = 5;
        public  TorpedoBoat torpedoboat = new TorpedoBoat();
        public  Cruiser cruiser = new Cruiser();
        public  Corvette corvette = new Corvette();
        public  Battleship battleship = new Battleship();
        public  AircraftCarrier aircraftcarrier = new AircraftCarrier();


        public PlayerBoard board = new PlayerBoard();
 
        public int GetShipCount()
        {
            return shipCount;
        }

        public void SetShipCount()
        {
            shipCount--;
        }
  
        public void ShipPlacement(Ships s){

                int xCor = 0, yCor = 0;
                char rotation='D';
                int size = s.GetShipSize();
                bool isOk = false;

                do
                {
                    Console.WriteLine(s.GetShipName() + " Türü Geminizi Yerleştiriniz ( Uzunluk : " + size + ") ");
                    try
                    {
                        xCor = int.Parse((Console.ReadKey().KeyChar).ToString());
                        yCor = int.Parse((Console.ReadKey().KeyChar).ToString());
                        rotation = Console.ReadKey().KeyChar;
                        rotation = char.ToUpper(rotation);
                    }
                    catch { };
                    Console.WriteLine();
                    
                    isOk = board.CanBePlaced(xCor, yCor, rotation, size);

                    if (isOk)
                    {
                        board.Place((xCor-1), (yCor-1), rotation, size,s.GetShortName());
                        s.setCoordinates((xCor + 1), (yCor + 1));
                        break;
                    }
                } while (isOk == false);
                Console.Clear();
                board.Draw();

            }
        public string IsShot(int x, int y)
        {
            string ch="*";
            if (board.GetShipPosition(x, y) != ch)
            {
                switch (board.GetShipPosition(x, y))
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
    }        
}
