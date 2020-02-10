using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution(); ;

            // Binary Gap exercise
            //Console.WriteLine("The size of the binary gap was: {0}.", solution.IterationSolution(8992).ToString());

            // CyclicRotation
            //foreach (var item in solution.CyclicRotation(new int[] { 1, 2, 3, 4 }, 4))
            //{
            //    Console.Write("{0} ", item);
            //}
            //Console.Write("\n");

            // OddOccurrencesInArray
            // Console.WriteLine(solution.OddOccurrencesInArray(new int[] {0, 1, 2, 2, 4, 4, 1}));

            // PermMissingElem
            Console.WriteLine(solution.PermMissingElem(new int[] {2, 3, 1, 5}));
        }
    }
}
