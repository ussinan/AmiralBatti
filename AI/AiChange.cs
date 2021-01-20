using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class AiChange
    {
        private AiStrategy strategy;
       // public  AiBoard board = new AiBoard();
        public TorpedoBoat torpedoboat = new TorpedoBoat();
        public Cruiser cruiser = new Cruiser();
        public Corvette corvette = new Corvette();
        public Battleship battleship = new Battleship();
        public AircraftCarrier aircraftcarrier = new AircraftCarrier();

        public AiChange(AiStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Position()
        {
            this.strategy.Position();
        }

        public void Draw()
        {
            this.strategy.Draw();
        }
        public void IncreaseHitCount()
        {
            this.strategy.IncreaseHitCount();
        }

        public void IsTargetAvailable(string shipName, int x, int y)
        {
            this.strategy.IsTargetAvailable(shipName,x,y);
        }
        public void ResetTarget()
        {
            this.strategy.ResetTarget();
        }
        public void SetFailCount()
        {
            this.strategy.SetFailCount();
        }
        public void SetPreShot(int x, int y)
        {
            this.strategy.SetPreShot(x,y);
        }
        public string IsShot(int x, int y)
        {
            return this.strategy.IsShot(x, y);          
        }
        public int GetShipCount()
        {
            return this.strategy.GetShipCount();
        }
        public void AimShot(int x, int y)
        {
            this.strategy.AimShot(x,y);
        }
        public void SetShipCount()
        {
            this.strategy.SetShipCount();
        }
        public string isSinked(String s)
        {
            return this.strategy.isSinked(s);
        }

        public void PlaceShips(Ships s) {
            this.strategy.PlaceShips(s);
        }
        public string TakeShots() {
            return this.strategy.TakeShots();
        }
    }
}
