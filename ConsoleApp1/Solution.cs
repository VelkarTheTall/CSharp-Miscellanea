using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Solution
    {
        public Solution()
        {
        }

        public int IterationSolution(int N)
        {
            // BinaryGap
            /* Make a program which takes a positive integer 
             * and finds the longest sequence of zeros within 
             * the binary representation of that number. 
             * Such a sequence of zeros must be flanked by number ones on both sides.
             */

            Console.WriteLine("The number was {0}.", N);
            StringBuilder numberInString = new StringBuilder(Convert.ToString(N, 2));
            Console.WriteLine("Its binary representation is {0}.", numberInString);
            int counter = 0;
            int record = 0;
            // Iterate through string which represents the number in binary.
            for (int i = 0; i < numberInString.Length; i++)
            {
                if (numberInString[i] == '0')
                {
                    counter++;
                    // If one record has already been set and the counter reset
                    // and the counter is ticking bigger than the current record,
                    // overwrite the record.
                    if (counter > record)
                    {
                        record = counter;
                    }
                    // Look ahead to see if the current binary gap
                    // is going to end. If so, record this as having been the longest
                    // binary gap.
                    try
                    {
                        if (numberInString[i + 1] == '1')
                        {
                            // record = counter;
                            // Reset counter.
                            counter = 0;
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        counter = 0;
                    }
                }
            }
            return record;
        }

        public Array CyclicRotation(int[] A, int K)
        {
            // Rotation
            /*Give an array and an integer as parameters.
             The array gets rotated as many times as 
             is given in the integer parameter.
             The integer parameter is presumed non-negative.
             The array itself contains integers.
             */
            int[] tmpArray = new int[A.Length];
            if (K != 0)
            {
                while (K > A.Length)
                {
                    K = K - A.Length;
                }
                //Console.WriteLine(A.Length);
                //Console.WriteLine(tmpArray.Length);
                //console.writeline(k);

                try
                {
                    for (int i = 0; i < A.Length; i++)
                    {
                        tmpArray[i] = A[i + K];
                    }
                }
                catch (IndexOutOfRangeException e)
                {

                }

                for (int i = 0; i < K; i++)
                {
                    tmpArray[i + (A.Length - K)] = A[i];
                }
            }
            return tmpArray;
        }

        public int OddOccurrencesInArray(int[] A)
        {
            // OddOccurrencesInArray
            /*Take an array full of non-negative integers.
             The array holds an uneven number of elements.
             For every element except one there is another
             element of equal value.
             This function finds that one element, which is unique
             and returns it.
             */
            int feedback = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != -1)
                {
                    for (int k = i; k < A.Length; k++)
                    {
                        if (A[k] != -1)
                        {
                            if (A[i] == A[k])
                            {
                                A[i] = -1;
                                A[k] = -1;
                            }
                            if (A[i] != -1)
                            {
                                feedback = A[i];
                            }
                        }
                    }
                }
            }
            return feedback;
        }

        public int PermMissingElem(int[] A)
        {
            // PermMissingElem
            /*Take in an array of integers that are ordered randomly.
             Most of the numbers are within a distance of 1 from other number
             so that, if ordered, they would make a steadily growing sequence N,
             such as "1, 2, 3...". However, there will be one number missing.
             This method finds that missing element.
             */

            int missingElement = new int();
            SortedSet<int> binaryTree = new SortedSet<int>();

            for (int i = 0; i < A.Length; i++)
            {
                binaryTree.Add(A[i]);
            }
            
            int previous = -1;
            foreach(int currentNumber in binaryTree)
            {
                if (previous != -1)
                {
                    if (currentNumber - 1 != previous)
                    {
                        missingElement = currentNumber - 1;
                        break;
                    }
                }
                previous = currentNumber;
            }

            return missingElement;
        }
    }
}
