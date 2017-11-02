using System;
namespace AgeOfEmpiresLibrary
{
    public class Createable
    {
        public int id;
        public string name;
        public double positionX;
        public double positionY;

        public Createable()
        {
            
        }

        public void setPosition(double x, double y)
        {
            positionX = x;
            positionY = y;
        }

        public void setPositionX(double x)
        {
            positionX = x;
        }

        public void setPositionY(double y)
        {
            positionX = y;
        }
    }
}
