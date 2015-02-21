using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolidaVolymer
{
    public abstract class Solid
    {
        private double _height;
        private double _radius;

        public abstract double BaseArea { get; }

        public double Height
        {
            get { return _height; }
            set { 
                    if (value <= 0)
                    { 
                        throw new ArgumentException();               
                    }
                
                    _height = value; 
                }
        }
        
        public double Radius
        {
            get { return _radius; }
            set {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    } 
                
                _radius = value;
                }
        }

        public double HeightSquared
        {
            get { return _height * _height;} 
        }

        public double RadiusSquared
        {
            get { return _radius * _radius; }
        }

        public abstract double SurfaceArea { get; }
        public abstract double Volume { get; }

        protected Solid(double radius, double height)
        {
            Height = height;
            Radius = radius;
        }

        public override string ToString()
        {
            return string.Format("{0,-10:}:{1,10:f2}\n{2,-10}:{3,10:f2}\n{4,-10}:{5,10:f2}\n{6,-10}:{7,10:f2}\n{8,-10}:{9,10:f2}\n",
                                 "Radie (r)", Radius, "Höjd (h)", Height, "Volym", Volume, "Basarea", BaseArea, "Ytarea", SurfaceArea);
        }
    }
}
