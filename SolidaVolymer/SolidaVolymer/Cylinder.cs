using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolidaVolymer
{
    class Cylinder : Solid
    {
        public override double BaseArea
        {
            get { return RadiusSquared * Math.PI; }
        }
        public override double SurfaceArea 
        {
            get { return (Height + Radius) * Radius * Math.PI * 2; }
        }
        public override double Volume 
        {
            get { return Height * RadiusSquared * Math.PI; }
        }
        public Cylinder(double radius, double height)
            : base(radius, height) 
        { }
    }
}
