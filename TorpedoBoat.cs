using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class TorpedoBoat:Ships
    {
        private  String shipName = "Torpido Botu";
        private  String shortName = "T";
        private  int size = 2;
        private  String shipStatus = "Active";
        private  int shipCoordinatesX = 0, shipCoordinatesY = 0;
        public override int GetShipSize()
        {
            return size;
        }
        public override void SetShipSize()
        {
            this.size--;
        }
        public override String GetShipName()
        {
            return shipName;
        }
        public override String GetShortName()
        {
            return shortName;
        }

        public void setCoordinates(int x,int y)
        {
            shipCoordinatesX = x;
            shipCoordinatesY = y;
        }
        
        public void setStatus(String s)
        {
            shipStatus = s;
        }
        public int getCoordinateX()
        {
            return shipCoordinatesX;
        }
        public int getCoordinateY()
        {
            return shipCoordinatesY;
        }

        public String getStatus()
        {
            return shipStatus;
        }
    }
}
