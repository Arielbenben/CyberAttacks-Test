using DefencesCyberTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefencesCyberTest.Utils
{
    internal static class ThreatUtils
    {
        private static int CalculateThreatValue(ThreatModel threatModel)
        {
            switch (threatModel.Target)
            {
                case "Database":
                    return 15;
                case "User Credentials":
                    return 20;
                case "Web Server":
                    return 10;
                default:
                    return 5;
            }
        }

        public static int CalculateThreatSeverity(ThreatModel threatModel)
        {
            int targetValue = CalculateThreatValue(threatModel);
            int severity = (threatModel.Volume * threatModel.Sophistication) + targetValue;
            return severity;
        }
    }
}
