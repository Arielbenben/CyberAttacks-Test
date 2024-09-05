using DefencesCyberTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefencesCyberTest.Utils
{
    internal class TreeUtils
    {
        public static BinaryTree AddDefencesBinaryTree(List<DefenceModel> listDefences)
        {
            List<NodeValue>? allDefencesNode = listDefences?.Select(a => new NodeValue()
            {
                MinSeverity = a.MinSeverity,
                MaxSeverity = a.MaxSeverity,
                Defences = a.Defenses
            }).ToList();

            BinaryTree defenceTree = new();

            allDefencesNode!.ForEach(defenceTree.Insert);

            return defenceTree;
        }
    }
}
