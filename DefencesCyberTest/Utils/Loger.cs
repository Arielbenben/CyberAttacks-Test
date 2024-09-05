using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefencesCyberTest.Utils
{
    internal static class Loger
    {
        public static void PrintDefencesTreeByPreOrder(List<NodeValue>? allTreePreOrder)
        {
            Console.WriteLine(string.Join(",", allTreePreOrder!));
            return;
        }


    }
}
