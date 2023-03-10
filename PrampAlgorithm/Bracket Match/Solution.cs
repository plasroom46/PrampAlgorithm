using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Bracket_Match
{
    public class Solution
    {
        public int BracketMatch(string text)
        {
            int leftCount = 0; // extra left bracket
            int rightCount = 0; // extra right bracket
            foreach (var c in text)
            {
                if (c == '(') leftCount++;
                else
                {
                    if (leftCount == 0) rightCount++;
                    // can combine a pair
                    else leftCount--;
                }
            }
            return leftCount + rightCount;
        }

        public void Run()
        {
            Console.WriteLine(BracketMatch(")("));
            Console.WriteLine(BracketMatch("(())"));
            Console.WriteLine(BracketMatch("())("));
        }
    }
}
