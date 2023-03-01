using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Decrypt_Message
{
    public class Solution
    {
        public string Decrypt(string word)
        {
            if (word == null || word.Length == 0)
                return string.Empty;
            int secondStep = 1;
            StringBuilder ans = new StringBuilder();
            foreach (var c in word)
            {
                // dec[i] = enc[i] - secondStep[i-1] - 26m
                var decryptAscii = c - secondStep;
                while (decryptAscii < 'a')
                    decryptAscii += 26;
                ans.Append((char)decryptAscii);
                secondStep += decryptAscii;
            }
            return ans.ToString();
        }

        public void Run()
        {
            Console.WriteLine(Decrypt("dnotq"));
            Console.WriteLine(Decrypt("flgxswdliefy"));
        }
    }
}
