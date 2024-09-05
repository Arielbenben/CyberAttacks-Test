using DefencesCyberTest.Models;
using DefencesCyberTest.Utils;

namespace DefencesCyberTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<DefenceModel>? allDefences = JsonUtils.GetAllDefences();

            BinaryTree defencesTree = TreeUtils.AddDefencesBinaryTree(allDefences!);

            List<NodeValue>? allTreePreOrder = defencesTree.PreOrderTraversal();

            Loger.PrintDefencesTreeByPreOrder(allTreePreOrder);

            List<ThreatModel>? allThreats = JsonUtils.GetAllThreats();

            await DefenceUtils.TurnOnDefenceOnAllTherat(defencesTree, allThreats!);

        }
    }
}
