using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolidaVolymer
{
    class Cylinder : Solid
    {
        public override double BaseArea // Räknar ut cylinderns basarea
        {
            get { return RadiusSquared * Math.PI; }
        }
        public override double SurfaceArea // Räknar ut cylinderns ytarea
        {
            get { return (Height + Radius) * Radius * Math.PI * 2; }
        }
        public override double Volume // Räknar ut cylinderns volym
        {
            get { return Height * RadiusSquared * Math.PI; }
        }
        public Cylinder(double radius, double height)
            : base(radius, height) // Anropar Solids konstuktor
        { }
    }
}
