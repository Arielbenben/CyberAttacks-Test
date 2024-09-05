using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefencesCyberTest.Models
{
    internal class DefenceModel
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; } = [];

        public override string ToString()
        {
            return $"MinSeverity: {MinSeverity}, \n" +
                $"MaxSeverity: {MaxSeverity}, \n" +
                $"Defences: {string.Join(",", Defenses)} \n" +
                $"\n";
        }
    }
}
