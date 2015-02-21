using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolidaVolymer
{
    class CircularCone : Solid
    {
        public override double BaseArea
        {
             get { return RadiusSquared * Math.PI; }
        }

        public override double SurfaceArea 
        {
             get { return (Radius + Math.Sqrt(RadiusSquared + HeightSquared)) * Radius * Math.PI; }
        }

        public override double Volume 
        {
             get { return Height * RadiusSquared * (Math.PI / 3.0); }
        }

        public CircularCone(double radius, double height)
          : base(radius, height) 
        {}
    }
}
