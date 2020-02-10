using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class CodilityShoeProgram
    {
        public int solution(string S)
        {
            LinkedList<string> patterns = GatherListOfPatterns(S);
            List<string> collection = new List<string>();

            // At this point, all the strips of characters have been recovered.
            // Now, to pair them.
            LinkedListNode<string> currentNode = patterns.First;
            LinkedListNode<string> nextNode = currentNode.Next;
            string foundPair;
            while (patterns.Count != 0)
            {
                if (IsAPair(currentNode.Value, nextNode.Value))
                {
                    foundPair = currentNode.Value + nextNode.Value;
                    collection.Add(foundPair);

                    var remove1 = currentNode;
                    var remove2 = nextNode;
                    nextNode = nextNode.Next;
                    currentNode = currentNode.Previous;
                    patterns.Remove(remove1);
                    patterns.Remove(remove2);
                }
                currentNode = currentNode.Next;
                nextNode = nextNode.Next;
            }

            return collection.Count;
        }

        private LinkedList<string> GatherListOfPatterns(string S)
        {
            LinkedList<string> patterns = new LinkedList<string>();
            StringBuilder sequence = new StringBuilder();
            char currentChar = new char();
            char previousChar = new char();

            for (int i = 0; i < S.Length; i++)
            {
                // Go through the the input and split it into lines of similar characters.
                currentChar = S[i];
                sequence.Append(currentChar);

                if (previousChar.ToString() != "")
                {
                    //  After the first round.
                    if (currentChar != previousChar)
                    {
                        // In the event of coming across a character which breaks the streak
                        patterns.AddLast(sequence.ToString());
                        sequence.Clear();
                        sequence.Append(currentChar);
                    }
                    else if (currentChar == previousChar)
                    {
                        // As long as we are getting the same string as before
                        // we come here.
                        sequence.Append(currentChar);
                    }
                }
                previousChar = currentChar;
            }

            return patterns;
        }

        private string GetOpposite(string Input)
        {
            string output = "";
            if (Input[0] == 'R')
            {
                output = new string('L', Input.Length);
            }
            else if (Input[0] == 'L')
            {
                output = new string('R', Input.Length);
            }
            else
            {
                throw new System.ArgumentException("The value of {0} was not 'L' or 'R'.", Input);
            }
            return output;
        }

        private bool IsOpposite(string A, string B)
        {
            bool output = false;
            if (A[0] == 'R' && B[0] == 'L')
            {
                output = true;
            }
            else if (A[0] == 'L' && B[0] == 'R')
            {
                output = true;
            }
            return output;
        }

        private bool IsAPair(string A, string B)
        {
            bool output = false;
            if (A.Length == B.Length)
            {
                if (IsOpposite(A, B))
                {
                    output = true;
                }
            }
            return output;
        }
    }
}
