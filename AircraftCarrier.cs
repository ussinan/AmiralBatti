﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AmiralBatti
{
    class AircraftCarrier:Ships
    {
        private String shipName = "Uçak Gemisi";
        private String shortName = "U";
        private int size = 5;
        private String shipStatus = "Active";
        private int shipCoordinatesX = 0, shipCoordinatesY = 0;

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
        public void setCoordinates(int x, int y)
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
