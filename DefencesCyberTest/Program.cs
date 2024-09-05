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

            await Task.Delay(4000);

            List<NodeValue>? allTreePreOrder = defencesTree.PreOrderTraversal();

            Loger.PrintDefencesTreeByPreOrder(allTreePreOrder);

            await Task.Delay(4000);

            List<ThreatModel>? allThreats = JsonUtils.GetAllThreats();

            await Task.Delay(4000);

            await DefenceUtils.TurnOnDefenceOnAllTherat(defencesTree, allThreats!);

        }
    }
}
