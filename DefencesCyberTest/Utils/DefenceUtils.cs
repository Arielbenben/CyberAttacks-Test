using DefencesCyberTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefencesCyberTest.Utils
{
    internal static class DefenceUtils
    {
        public static async Task TurnOnDefence(BinaryTree defenceTree, ThreatModel threatModel)
        {
            var threatSeverity = ThreatUtils.CalculateThreatSeverity(threatModel);

            var defences = defenceTree.SearchByPreOrderTraversal(threatSeverity);

            if(defences == null)
            {
                CheckWhyNull(defenceTree, threatSeverity);
                return;
            }

            foreach ( var defence in defences )
            {
                Console.WriteLine(defence);
                await Task.Delay(2000);
            }
            Console.WriteLine("The threat destroyed!");
        }

        private static void CheckWhyNull(BinaryTree defenceTree, int threatSeverity)
        {
            var minSeverity = defenceTree.PreOrderTraversal().Min(t => t.MinSeverity);
            var maxSeverity = defenceTree.PreOrderTraversal().Max(t => t.MinSeverity);

            if(threatSeverity < minSeverity)
            {
                Console.WriteLine("Attack severity is below the threshold. Attack is ignored");
                return;
            }

            else
            {
                Console.WriteLine("Attack severity is above the threshold. Attack is ignored");
                return;
            }
        }

        public static async Task TurnOnDefenceOnAllTherat(BinaryTree defencesTree, List<ThreatModel> allThreats)
        {
            foreach (var threat in allThreats)
            {
                await TurnOnDefence(defencesTree, threat);
                await Task.Delay(4000);
            }
        }
    }
}
