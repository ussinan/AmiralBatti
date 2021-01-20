using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class Ai
    {
        private string name = "AI";
        private string zorluk = "kolay";
        public static TorpedoBoat torpedoboat = new TorpedoBoat();
        public static Cruiser cruiser1 = new Cruiser();
        public static Cruiser cruiser2 = new Cruiser();
        public static Battleship battleship = new Battleship();
        public static AircraftCarrier aircraftcarrier = new AircraftCarrier();


        public static AiBoard board = new AiBoard();

        public void SetZorluk(string z)
        {
            this.zorluk = z;
        }
    }
}
