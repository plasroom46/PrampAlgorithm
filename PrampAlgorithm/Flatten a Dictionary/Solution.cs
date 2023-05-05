using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Flatten_a_Dictionary
{
    public class Solution
    {
        public Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
        {
            Dictionary<string, string> ans = new Dictionary<string, string>();
            List<string> keys = new List<string>();
            FlattenDictionary(dict, keys, ans);
            return ans;
        }

        private void FlattenDictionary(Dictionary<string, object> dict, List<string> keys, Dictionary<string, string> ans)
        {
            foreach (var pair in dict)
            {
                if (pair.Key != "")
                    keys.Add(pair.Key);
                if (pair.Value.GetType() == typeof(string))
                    ans[string.Join(".", keys)] = (string)pair.Value;
                else
                    FlattenDictionary((Dictionary<string, object>)dict[pair.Key], keys, ans);
                if (pair.Key != "")
                    keys.RemoveAt(keys.Count - 1);
            }
        }

        public void Run()
        {

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["Key1"] = "1";
            dict["Key2"] = new Dictionary<string, object>();
            ((Dictionary<string, object>)dict["Key2"])["a"] = "2";
            ((Dictionary<string, object>)dict["Key2"])["b"] = "3";
            ((Dictionary<string, object>)dict["Key2"])["c"] = new Dictionary<string, object>();
            ((Dictionary<string, object>)((Dictionary<string, object>)dict["Key2"])["c"])["d"] = "3";
            ((Dictionary<string, object>)((Dictionary<string, object>)dict["Key2"])["c"])["e"] = new Dictionary<string, object>();
            ((Dictionary<string, object>)((Dictionary<string, object>)((Dictionary<string, object>)dict["Key2"])["c"])["e"])[""] = "1";

            var ans = FlattenDictionary(dict);
            foreach (var pair in ans)
                Console.WriteLine($"{pair.Key}:{pair.Value}");
        }
    }
}
