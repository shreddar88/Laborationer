using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskåp
{
    class Cooler
    {
        private decimal _insideTemperature;
        private decimal _targetTemperature;
        private const decimal OutsideTemperature = 23.7m;

        public bool DoorIsOpen { get; set; }

        public decimal InsideTemperature
        {
            get { return _insideTemperature; }
            set
            {
                    if (value < 0 || value > 45)
                    {
                        throw new ArgumentException();
                    }

                _insideTemperature = value;
            }
        }

        public bool IsOn { get; set; }

        public decimal TargetTemperature
        {
            get { return _targetTemperature; }
            set
            {
                    if (value < 0 || value > 20)
                    {
                        throw new ArgumentException();
                    }

                _targetTemperature = value;
            }
        }

        public Cooler()
            : this(0m, 0m) { }

        public Cooler(decimal temperature, decimal targetTemperature)
            : this(temperature, targetTemperature, false, false) { }

        public Cooler(decimal temperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
        {
            InsideTemperature = temperature;
            TargetTemperature = targetTemperature;
            IsOn = isOn;
            DoorIsOpen = doorIsOpen;
        }

        public void Tick()
        {
            decimal change = 0.0m;

                if (IsOn == true && DoorIsOpen == false)
                {
                    change -= 0.2m;
                }

                else if (IsOn == true && DoorIsOpen == true)
                {
                    change += 0.2m;
                }

                else if (IsOn == false && DoorIsOpen == true)
                {
                    change += 0.5m;
                }

                else
                {
                    change += 0.1m;
                }

                if (InsideTemperature + change < TargetTemperature)
                {
                    InsideTemperature = TargetTemperature;
                }

                else if (InsideTemperature + change > OutsideTemperature)
                {
                    InsideTemperature = OutsideTemperature;
                }

                else
                {
                    InsideTemperature += change;
                }
        }

        public override string ToString()
        {
            string OnOff = IsOn ? "PÅ" : "AV";
            string OpenClosed = DoorIsOpen ? "Öppen" : "Stängt";
            return string.Format("[{0}] : {1:f1}°C : <{2:f1}°C> : {3}", OnOff, InsideTemperature, TargetTemperature, OpenClosed);
        }
    }
}

