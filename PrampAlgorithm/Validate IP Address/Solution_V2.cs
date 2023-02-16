using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Validate_IP_Address
{
    public class Solution_V2
    {
        public bool ValidateIPAddress(string ip)
        {
            if (ip == null) return false;

            // 1. separate the string by dot
            var blocks = ip.Split('.');

            // 2. if the number of dot is not 3
            if (blocks.Length != 4) return false;

            foreach (var block in blocks)
            {
                // check the block is valid, the block is between 0 to 255
                if (!Check(block)) return false;
            }
            return true;
        }

        private bool Check(string s)
        {
            //  1. the valid range is 0 ~ 255, that means 1 to 3
            if (s.Length == 0 || s.Length > 4) return false;

            int num = 0;
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                    num = num * 10 + c - '0';
                // 2. if the character is not a digit
                else return false;
            }

            // 3. if the string has a leading zero
            if (s.Length > 1 && s[0] == '0')
                return false;

            // check the number is between 0 to 255
            return num <= 255;
        }

        public void Run()
        {
            Console.WriteLine(ValidateIPAddress("192.168.0.1"));
            Console.WriteLine(ValidateIPAddress("0.0.0.0"));
            Console.WriteLine(ValidateIPAddress("123.24.59.99"));
            Console.WriteLine(ValidateIPAddress("192.168.123.456"));
            Console.WriteLine(ValidateIPAddress("092.168.123.456"));
        }
    }
}
