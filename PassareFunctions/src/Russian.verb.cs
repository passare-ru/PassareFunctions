using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Term2
{
    public partial class Russian
    {
        public static HashSet<string> imperfect_verbs = GetList(@"data/Russian Imperfect Verbs.txt");
        public static HashSet<string> perfect_verbs = GetList(@"data/Russian Perfect Verbs.txt");

        public static bool? IsPerfect(string w_neutralform)
        {
            w_neutralform = w_neutralform.Trim().ToLower();
            if (perfect_verbs.Contains(w_neutralform)) return true;
            if (imperfect_verbs.Contains(w_neutralform)) return false;
            return null;
        }

        public static bool GetPerfectness(string w_neutralform)
        { 
            return IsPerfect(w_neutralform) ?? false;
        }

        public static string Verb2(string w_neutralform, 
            Perspective p, Number n, Gender g, Tense t, TypeVariant d, 
            Perfectness perfoverride = Perfectness.Unknown)
        {
            return "";
        }
    }
}
