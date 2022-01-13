using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace Term2
{
    public static class Utils
    { 
        public static string Till(this string s, int countbeforend)
        {
            return s.Substring(0, s.Length - countbeforend);
        }
		
        public static string Last(this string s, int count)
        {
            if (s.Length < count) return s;
            return s.Substring(s.Length - count, count);
        }

        public static char LastChar(this string s, int number)
        {
            return s[s.Length - number];
        }

        public static bool EndsWith(this string s, params string[] ends)
        {
            for (int i = 0; i < ends.Length; i++)
            {
                if (s.EndsWith(ends[i])) return true;
            }
            return false;
        }
        public static bool StartsWith(this string s, params string[] starts)
        {
            for (int i = 0; i < starts.Length; i++)
            {
                if (s.StartsWith(starts[i])) return true;
            }
            return false;
        }
        public static bool ContainsAny(this string s, params string[] ins)
        {
            for (int i = 0; i < ins.Length; i++)
            {
                if (s.Contains(ins[i])) return true;
            }
            return false;
        }
    }
}