 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; 

namespace Term2
{
    public partial class Russian
    {
        public enum PronounType { Unknown, Personal, Possesive, Demonstrative }
        static List<string> pp1 = new List<string> { "я", "меня", "мне", "меня", "мной", "мне" };
        static List<string> pp2 = new List<string> { "мы", "нас", "нам", "нас", "нами", "нас" };

        static List<string> pp3 = new List<string> { "ты", "тебя", "тебе", "тебя", "тобой", "тебе" };
        static List<string> pp4 = new List<string> { "вы", "вас", "вам", "вас", "вами", "вас" };
         
        static List<string> pp5 = new List<string> { "он", "его", "ему", "его", "им", "нем" }; 
        static List<string> pp6 = new List<string> { "она", "ее", "ей", "ее", "ей", "ней" }; 
        static List<string> pp7 = new List<string> { "оно", "его", "ему", "его", "им", "нем" };

        static List<string> pp8 = new List<string> { "они", "их", "им", "их", "ими", "них" };
         
        /////////// 

        static List<string> dp1 = new List<string> { "этот", "этого", "этому", "этот", "этим", "этом" }; 
        static List<string> dp2 = new List<string> { "эта", "этой", "этой", "эту", "этой", "этой" };
        static List<string> dp3 = new List<string> { "это", "этого", "этому", "это", "этим", "этом" };

        static List<string> dp4 = new List<string> { "тот", "того", "тому", "тот", "тем", "том" }; 
        static List<string> dp5 = new List<string> { "та", "той", "той", "ту", "той", "той" };
        static List<string> dp6 = new List<string> { "то", "того", "тому", "то", "тем", "том" };

        static List<string> dp7 = new List<string> { "эти", "этих", "этим", "эти", "этими", "этих" }; 
        static List<string> dp8 = new List<string> { "те", "тех", "тем", "те", "теми", "тех" }; 
        public static PronounType DetectPronoun(string w)
        {
            PronounType t;
            Perspective p;
            Number n;
            Gender g;
            Case c;
            Distance d;
            Animated a;
            DetectPronoun(w, out  t, out  p, out  n, out  g, out  c, out  d, out  a);
            return t;
        }
        public static void DetectPronoun(string w, out PronounType t, out Perspective p, out Number n, out Gender g, out Case c, out Distance d,out Animated a)
        {
            t = PronounType.Unknown;
            p = Perspective.Unknown;
            n = Number.Unknown;
            g = Gender.Unknown;
            c = Case.Unknown;
            d = Distance.Unknown;
            a = Animated.Unknown;

            
              
            int
            dex = pp1.IndexOf(w); if (dex >= 0) { t = PronounType.Personal; p = Perspective.First; n = Number.Singular; c = (Case)(dex + 1); return; }
            dex = pp2.IndexOf(w); if (dex >= 0) { t = PronounType.Personal; p = Perspective.First; n = Number.Plural; c = (Case)(dex + 1); return; }
            dex = pp3.IndexOf(w); if (dex >= 0) { t = PronounType.Personal; p = Perspective.Second; n = Number.Singular; c = (Case)(dex + 1); return; }
            dex = pp4.IndexOf(w); if (dex >= 0) { t = PronounType.Personal; p = Perspective.Second; n = Number.Plural; c = (Case)(dex + 1); return; }

            dex = pp5.IndexOf(w); if (dex >= 0) { t = PronounType.Personal; p = Perspective.Third; n = Number.Singular; g = Gender.Masculine; c = (Case)(dex + 1); return; }
            dex = pp6.IndexOf(w); if (dex >= 0) { t = PronounType.Personal; p = Perspective.Third; n = Number.Singular; g = Gender.Feminine; c = (Case)(dex + 1); return; }
            dex = pp7.IndexOf(w); if (dex >= 0) { t = PronounType.Personal; p = Perspective.Third; n = Number.Singular; g = Gender.Neuter; c = (Case)(dex + 1); return; }
            dex = pp8.IndexOf(w); if (dex >= 0) { t = PronounType.Personal; p = Perspective.Third; n = Number.Plural; c = (Case)(dex + 1); return; }
             

            ////
            if (w == "этого") { t = PronounType.Demonstrative; d = Distance.Close; n = Number.Singular; g = Gender.Masculine; c = Case.VCase; a = Animated.True; return; }
            dex = dp1.IndexOf(w);
            if (dex >= 0) { t = PronounType.Demonstrative; d = Distance.Close; n = Number.Singular; g = Gender.Masculine; c = (Case)(dex + 1); if (c == Case.VCase) a = Animated.False; return; }
            dex = dp2.IndexOf(w);
            if (dex >= 0) { t = PronounType.Demonstrative; d = Distance.Close; n = Number.Singular; g = Gender.Feminine; c = (Case)(dex + 1); return; }
            dex = dp3.IndexOf(w);
            if (dex >= 0) { t = PronounType.Demonstrative; d = Distance.Close; n = Number.Singular; g = Gender.Neuter; c = (Case)(dex + 1); return; }

            if (w == "того") { t = PronounType.Demonstrative; d = Distance.Far; n = Number.Singular; g = Gender.Masculine; c = Case.VCase; a = Animated.True; return; }
            dex = dp4.IndexOf(w);
            if (dex >= 0) { t = PronounType.Demonstrative; d = Distance.Far; n = Number.Singular; g = Gender.Masculine; c = (Case)(dex + 1); if (c == Case.VCase) a = Animated.False; return; }
            dex = dp5.IndexOf(w);
            if (dex >= 0) { t = PronounType.Demonstrative; d = Distance.Far; n = Number.Singular; g = Gender.Feminine; c = (Case)(dex + 1); return; }
            dex = dp6.IndexOf(w);
            if (dex >= 0) { t = PronounType.Demonstrative; d = Distance.Far; n = Number.Singular; g = Gender.Neuter; c = (Case)(dex + 1); return; }


            if (w == "этих") { t = PronounType.Demonstrative; d = Distance.Close; n = Number.Plural; c = Case.VCase; a = Animated.True; return; }
            dex = dp7.IndexOf(w); if (dex >= 0) { t = PronounType.Demonstrative; d = Distance.Close; n = Number.Plural; c = (Case)(dex + 1); if (c == Case.VCase) a = Animated.False; return; }

            if (w == "тех") { t = PronounType.Demonstrative; d = Distance.Far; n = Number.Plural; c = Case.VCase; a = Animated.True; return; }
            dex = dp8.IndexOf(w); if (dex >= 0) { t = PronounType.Demonstrative; d = Distance.Far; n = Number.Plural; c = (Case)(dex + 1); if (c == Case.VCase) a = Animated.False; return; }
        
            ////
            if (w == "себя") { }
            if (w == "себе") { }
            if (w == "собой") { }
            if (w == "собою") { }
        
        
        }
        public static string Pronoun(PronounType t, Perspective p, Number n, Gender g, Distance d, Case c, bool a)
        {
            if (t == PronounType.Unknown) t = PronounType.Personal;

            if (t == PronounType.Personal) return PersonalPronoun(p, n, g, c);
            else if (t == PronounType.Demonstrative) return DemonstrativePronoun(n, d, g, c, a);
            else if (t == PronounType.Possesive) return PossesivePronoun(p, n, g, c, a? Animated.True: Animated.False, false);
            return "";
        } 
        public static string PersonalPronoun(Perspective p, Number n, Gender g, Case c)
        {
            if (p == Perspective.First)
            {
                if (n == Number.Singular) return pp1[(int)c - 1];
                else return pp2[(int)c - 1]; 
            }
            else if (p == Perspective.Second)
            {
                if (n == Number.Singular) return pp3[(int)c - 1];
                else return pp4[(int)c - 1];
            }
            else if (p == Perspective.Third)
            {
                if (n == Number.Singular)
                {
                    if (g == Gender.Masculine) return pp5[(int)c - 1];
                    if (g == Gender.Feminine) return pp6[(int)c - 1];
                    if (g == Gender.Neuter) return pp7[(int)c - 1];
                }
                else return pp8[(int)c - 1];
            }
            return "";
        }
        public static string DemonstrativePronoun(Number n, Distance d, Gender g, Case c, bool animated)
        {

            if (n == Number.Singular)
            {
                if (d == Distance.Close)
                {
                    if (g == Gender.Masculine)
                    {
                        if (c == Case.VCase && animated) return "этого";
                        return dp1[(int)c - 1];
                    }
                    if (g == Gender.Feminine) return dp2[(int)c - 1];
                    if (g == Gender.Neuter) return dp3[(int)c - 1];
                }
                else
                {
                    if (g == Gender.Masculine)
                    {
                        if (c == Case.VCase && animated) return "того";
                        return dp4[(int)c - 1];
                    }
                    if (g == Gender.Feminine) return dp5[(int)c - 1];
                    if (g == Gender.Neuter) return dp6[(int)c - 1];
                }
            }
            else
            {
                if (d == Distance.Close)
                {
                    if (c == Case.VCase && animated) return "этих";
                    return dp7[(int)c - 1]; 
                }
                else
                {
                    if (c == Case.VCase && animated) return "тех";
                    return dp8[(int)c - 1]; 
                }
            }
            return ""; 
        }
        public static string PossesivePronoun(Perspective p, Number n, Gender g, Case c, Animated a, bool multiplesubject, bool subjectfeminine = false)
        { 
            string[] basicm = { "й", "его", "ему", "его", "им", "ем" }; 
            string[] basicm2 = { "", "его", "ему", "его", "им", "ем" };
            string[] basicf = { "я", "ей", "ей", "ю", "ей", "ей" };
            string[] basicf2 = { "а", "ей", "ей", "у", "ей", "ей" };
            string[] basicn = { "е", "его", "ему", "е", "им", "ем" }; 
            string[] basicn2 = { "е", "его", "им", "е", "им", "ем" };
            string[] basicx = { "и", "их", "им", "и", "ими", "их" }; 
            if (p == Perspective.First)
            {
                if (multiplesubject)
                {
                    return "наш" + sub_Construct(basicm2, basicf2, basicn2, basicx, n, g, c, a);
                }
                else
                {
                    return "мо" + sub_Construct(basicm, basicf, basicn, basicx, n, g, c, a);
                }
            }
            else if (p == Perspective.Second)
            {
                if (multiplesubject)
                {
                    return "ваш" + sub_Construct(basicm2, basicf2, basicn2, basicx, n, g, c, a);
                }
                else
                {
                    return "тво" + sub_Construct(basicm, basicf, basicn, basicx, n, g, c, a);
                }
            }
            else if (p == Perspective.Third)
            {
                if (n == Number.Plural)
                {
                    return "их";
                }
                else
                if (!multiplesubject)
                {
                    if (subjectfeminine)  
                        return "ее";
                    else return "его";
                } 
            }
            else if (p == Perspective.Return)
            {
                return "сво" + sub_Construct(basicm, basicf, basicn, basicx, n, g, c, a);
            }
            return null;
        }
        static string sub_Construct( string[] cases_m, string[] cases_f, string[] cases_n, string[] cases_x, Number n, Gender g, Case c,Animated a)
        { 
            if (n == Number.Singular)
            {
                if (g == Gender.Masculine)
                {
                    subfunction_CaseSwitchVIR(ref c, a);
                    return cases_m[(int)c - 1];
                }
                else if (g == Gender.Feminine)
                {
                    return cases_f[(int)c - 1];
                }
                else// if (g == Gender.Neuter)
                {
                    return cases_n[(int)c - 1];
                }
            }
            else//(n == Number.Plural)
            {
                subfunction_CaseSwitchVIR(ref c, a);
                return cases_x[(int)c - 1];
            }
        } 
        public static EnumBag PersonalPronounGetParameters(string pronoun)
        {
            EnumBag parameters = null; 
            switch (pronoun)
            {
                case "я": parameters = new EnumBag(Perspective.First, Number.Singular, Case.ICase); break; 
                case "меня": parameters = new EnumBag(Perspective.First, Number.Singular, Case.RCase, Case.VCase); break; 
                case "мне": parameters = new EnumBag(Perspective.First, Number.Singular, Case.DCase);  break;
                case "мной": 
                case "мною": parameters = new EnumBag(Perspective.First, Number.Singular, Case.TCase);  break;
                case "обо мне": parameters = new EnumBag(Perspective.First, Number.Singular, Case.PCase); break;


                case "ты": parameters = new EnumBag(Perspective.Second, Number.Singular, Case.ICase); break;
                case "тебя": parameters = new EnumBag(Perspective.Second, Number.Singular, Case.RCase, Case.VCase);break; 
                case "тебе": parameters = new EnumBag(Perspective.Second, Number.Singular, Case.DCase); break;
                case "тобой":
                case "тобою": parameters = new EnumBag(Perspective.Second, Number.Singular, Case.TCase); break;
                case "о тебе": parameters = new EnumBag(Perspective.Second, Number.Singular, Case.PCase); break;

                case "вы": parameters = new EnumBag(Perspective.Second, Number.Singular, Number.Plural, Case.ICase); break; 
                case "вас": parameters = new EnumBag(Perspective.Second, Number.Singular, Number.Plural, Case.RCase, Case.VCase); break; 
                case "вам": parameters = new EnumBag(Perspective.Second, Number.Singular, Number.Plural, Case.DCase); break; 
                case "вами": parameters = new EnumBag(Perspective.Second, Number.Singular, Number.Plural, Case.TCase); break; 
                case "о вас": parameters = new EnumBag(Perspective.Second, Number.Singular, Number.Plural, Case.PCase); break; 



                case "он": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Masculine, Case.ICase); break;
                case "она": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Feminine, Case.ICase); break;
                case "оно": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Neuter, Case.ICase); break;

                case "его":
                case "него": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Masculine, Gender.Neuter, Case.RCase, Case.VCase); break; 
                case "ее":
                case "нее": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Feminine, Case.RCase, Case.VCase); break; 

                case "ему":
                case "нему": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Masculine, Gender.Neuter, Case.DCase); break; 
                case "ей":
                case "ней": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Feminine, Case.DCase, Case.TCase); break; 
                case "им":
                case "ним": parameters = new EnumBag(Perspective.Third, Number.Singular, Number.Plural, Gender.Masculine, Gender.Neuter, Case.TCase); break; 
                
                case "ею": 
                case "нею": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Feminine, Case.TCase); break;


                case "о нем": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Masculine, Gender.Neuter, Case.PCase); break; 
                case "о ней": parameters = new EnumBag(Perspective.Third, Number.Singular, Gender.Feminine, Case.PCase); break;

                case "мы": parameters = new EnumBag(Perspective.First, Number.Plural, Case.ICase); break; 

                case "нас": parameters = new EnumBag(Perspective.First, Number.Plural, Case.RCase, Case.VCase); break; 

                case "нам": parameters = new EnumBag(Perspective.First, Number.Plural, Case.DCase); break; 

                case "нами": parameters = new EnumBag(Perspective.First, Number.Plural, Case.TCase); break; 

                case "о нас": parameters = new EnumBag(Perspective.First, Number.Plural, Case.PCase); break; 

                case "они": parameters = new EnumBag(Perspective.Third, Number.Plural, Case.ICase); break;

                case "их":
                case "них": parameters = new EnumBag(Perspective.Third, Number.Plural, Case.RCase, Case.VCase); break; 

                case "ими":
                case "ними": parameters = new EnumBag(Perspective.Third, Number.Plural, Case.TCase); break;

                case "о них": parameters = new EnumBag(Perspective.Third, Number.Plural, Case.PCase); break;
                     
            }
            return parameters;
        } 
    }
}
