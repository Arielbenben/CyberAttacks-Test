using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefencesCyberTest.Models
{
    internal class ThreatModel
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }

        public override string ToString()
        {
            return $"ThreatType: {ThreatType}, \n" +
                $"Volume: {Volume}, \n" +
                $"Sophistication: {Sophistication}, \n" +
                $"Target: {Target}, \n" +
                $"\n" +
                $"\n";
        }
    }
}
