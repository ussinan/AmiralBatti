using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    interface AiStrategy
    {
        //public AiBoard ;
        public static TorpedoBoat torpedoboat = new TorpedoBoat();
        public static Cruiser cruiser = new Cruiser();
        public static Corvette corvette = new Corvette();
        public static Battleship battleship = new Battleship();
        public static AircraftCarrier aircraftcarrier = new AircraftCarrier();
        void PlaceShips(Ships s);
        public void SetShipCount();
        public int GetShipCount();
        public void Position();
        public void Draw();
        public void ResetTarget();
        public void IncreaseHitCount();
        public void IsTargetAvailable(string shipName,int x,int y) ;

        public void SetPreShot(int x, int y);
        public void SetFailCount();
        public void AimShot(int x, int y);
        public string IsShot(int x, int y);
        public string isSinked(String s);
        public string TakeShots();
    }
}
