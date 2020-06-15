using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class BoxData
    {
        private double length;
        private double width;
        private double height;
        public BoxData(double length,double width,double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length 
        {
            get { return this.length; }
            private set 
            {
                if(value <= 0)
                {
                    throw new ArgumentException($"Lenght cannot be zero or negative.");
                }
                this.length = value;
            } 
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        
        public double CalculateSurfaceArea()
        {
            double sum = 2 * (this.Length * this.width) + 2 * (this.length * this.height) + 2 * (this.width * this.height);
            return sum;
        }
        public double CalculateLateralSurfaceArea()
        {
            double sum = 2 * (Length * height) + 2 * (width * height);
            return sum;
        }
        public double CalculateVolume()
        {
            
            double sum = this.length * this.width * this.height;
            return sum;
        }
    }
}
