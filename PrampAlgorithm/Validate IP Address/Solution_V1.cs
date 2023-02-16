using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrampAlgorithm.Validate_IP_Address
{
    public class Solution_V1
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
                // 3. the valid range is 0 ~ 255, that means 1 to 3
                if (block.Length == 0 || block.Length > 4) return false;
                int num = 0;
                bool firstZero = false;
                for (int i = 0; i < block.Length; i++)
                {
                    var c = block[i];
                    // 4. check the character is the digit
                    if (c < '0' || c > '9') return false;
                    // 5. remember the first digit is zero
                    if (i == 0 && c == '0') firstZero = true;
                    // 6. check leading zero case
                    if (i != 0 && firstZero) return false;
                    // 7. convert the character to number
                    num = num * 10 + c - '0';
                    // 8. check the number is too large
                    if (num > 255) return false;
                }
            }
            return true;
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
