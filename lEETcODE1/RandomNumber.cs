using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lEETcODE1
{
    public class RandomizedSet
    {
        List<int> vals;
        Dictionary<int, int> map;
        public RandomizedSet()
        {
            vals = new List<int>();
            map = new Dictionary<int, int>();
        }

        public bool Insert(int val)
        {
            if (!map.ContainsKey(val))
            {
                map[val] = vals.Count;
                vals.Add(val); 
                return true;
            }
            else
                return false;
        }

        public bool Remove(int val)
        {
            if (map.ContainsKey(val))
            {
                //index of val
                //lastvalue
                var indexOfVal = map[val];
                var lastValue = vals[vals.Count - 1];

                //Move lastvalue to removal var index
                vals[indexOfVal] = lastValue;
                //Update the lastvalue index to new index
                map[lastValue] = indexOfVal;

                vals.RemoveAt(vals.Count - 1);
                map.Remove(val);
                return true;
            }
            else
                return false;
        }

        public int GetRandom()
        {
            int n = new Random().Next(vals.Count);
            return vals[n];
        }
    }
}
