using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Diff_Between_Two_Strings
{
    public class Solution
    {
        public string[] DiffBetweenTwoStrings(string source, string target)
        {
            int sn = source.Length;
            int tn = target.Length;
            Tuple<int, List<string>>[][] memo = new Tuple<int, List<string>>[sn + 1][];
            for (int i = 0; i <= sn; ++i)
            {
                memo[i] = new Tuple<int, List<string>>[tn + 1];
            }
            DiffBetweenTwoStrings(source, target, 0, 0, memo);
            return memo[0][0].Item2.ToArray();
        }

        private Tuple<int, List<string>> DiffBetweenTwoStrings(string source, string target, int sp, int tp, Tuple<int, List<string>>[][] memo)
        {
            // already Solved the question
            if (memo[sp][tp] != null) return memo[sp][tp];
            // the source index is end of length
            else if (source.Length == sp)
            {
                int count = target.Length - tp;
                List<string> l = new List<string>();
                for (int i = tp; i < target.Length; ++i)
                    l.Add($"+{target[i]}");
                return memo[sp][tp] = new Tuple<int, List<string>>(count, l);
            }
            // the target index is end of length
            else if (target.Length == tp)
            {
                int count = source.Length - sp;
                List<string> l = new List<string>();
                for (int i = sp; i < source.Length; ++i)
                    l.Add($"-source[i]");
                return memo[sp][tp] = new Tuple<int, List<string>>(count, l);
            }
            else
            {
                // the character is same
                if (source[sp] == target[tp])
                {
                    var ans = DiffBetweenTwoStrings(source, target, sp + 1, tp + 1, memo);
                    var l = ans.Item2.ToList();
                    l.Insert(0, source[sp].ToString());
                    return memo[sp][tp] = new Tuple<int, List<string>>(ans.Item1, l);
                }
                else
                {
                    // the character is different
                    var ans1 = DiffBetweenTwoStrings(source, target, sp + 1, tp, memo);
                    var ans2 = DiffBetweenTwoStrings(source, target, sp, tp + 1, memo);
                    // choose the least edits answer
                    if (ans1.Item1 <= ans2.Item1)
                    {
                        var l = ans1.Item2.ToList();
                        l.Insert(0, $"-{source[sp]}");
                        memo[sp][tp] = new Tuple<int, List<string>>(ans1.Item1 + 1, l);
                    }
                    else
                    {
                        var l = ans2.Item2.ToList();
                        l.Insert(0, $"+{target[tp]}");
                        memo[sp][tp] = new Tuple<int, List<string>>(ans2.Item1 + 1, l);
                    }
                }
                return memo[sp][tp];
            }
        }
        public void Run()
        {
            // var ans = DiffBetweenTwoStrings("ABCDEFG", "ABDFFGH");
            // var ans = DiffBetweenTwoStrings("CCBC", "CCBC");
            // var ans = DiffBetweenTwoStrings("CBBC", "CABAABBC");
            // var ans = DiffBetweenTwoStrings("CABAAABBC", "CBBC");
            // var ans = DiffBetweenTwoStrings("AABACC", "BABCAC"); 
            // var ans = DiffBetweenTwoStrings("HMXPHHUM", "HLZPLUPH");
            // var ans = DiffBetweenTwoStrings("GHMXGHUGXL", "PPGGXHHULL");
            var ans = DiffBetweenTwoStrings("GMMGZGGLUGUH", "HPGPPMGLLUUU");
            foreach (var str in ans)
                Console.WriteLine(str);
        }
    }
}
