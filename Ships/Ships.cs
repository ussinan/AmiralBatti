using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    abstract class Ships
    {
        private string shipName;
        private string shortName;
        private  int size;
        private static String shipStatus = "Active";
        private static int shipCoordinatesX = 0, shipCoordinatesY = 0;
        public static void ShipPlacement(int x, int y) { }
        public virtual int  GetShipSize() { return size; }
        public virtual void SetShipSize()
        {
           size--;
        }
        public virtual String GetShipName() { return shipName; }

        public virtual String GetShortName()
        {
            return shortName;
        }
        public virtual void setCoordinates(int x, int y)
        {
            shipCoordinatesX = x;
            shipCoordinatesY = y;
        }

        public virtual void setStatus(String s)
        {
            shipStatus = s;
        }
        public virtual int getCoordinateX()
        {
            return shipCoordinatesX;
        }
        public virtual int getCoordinateY()
        {
            return shipCoordinatesY;
        }

        public virtual String getStatus()
        {
            return shipStatus;
        }

    }
}
