using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace Term2
{
    public partial class Russian
    {
        public enum Perspective { Unknown, Return, First, Second, Third }
        public enum Number { Unknown, Singular, Plural, ZeroPlural, FirstPlural, SecondPlural }
        public enum Case {  Unknown, ICase, RCase, DCase, VCase, TCase, PCase };
        public enum Gender { Unknown, Masculine, Feminine, Neuter, PermanentPlural }
        public enum Tense { Unknown, Past, Present, Future, NotPast }
        public enum Form { Unknown, None, Comparative, Superlative }
        public enum Animated { Unknown, False, True }
        public enum WordType 
        { 
            Unknown,

            Verb,           
            Adverb,         

            Noun,           
            Pronoun,        
            

            Adjective,      
            Numeral,        
            Particle,       
            Preposition,    
            Interjection,   
            Union,          

            Participle,     
            Gerund,         


            Number,         
            Symbol,         
        }

        public enum Distance { Unknown, Close, Far } 
        public enum Reflexive { Unknown, False, True }
        public enum Perfectness { Unknown, False, True, Both }
        public enum TypeVariant { Declarative, Unknown }

        public static char[] CommonConsonants = new char[] { 'б', 'в', 'д', 'з', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф' };
        public static char[] ShConsonants = new char[] { 'ш', 'щ', 'ч', 'ж' };
        public static char[] GConsonants = new char[] { 'г', 'х', 'к' };
        static string vowels = "аеёиоуыэюя";


        public static readonly string _noform = "_noform";

        public static HashSet<string> GetList(string path)
        {
            string[] rems =System.IO.File.ReadAllLines(path);
            for (int i = 0; i < rems.Length; i++)
            {
                rems[i] = rems[i].Replace("ё", "е").Trim();
            }
            var hs = new HashSet<string>(rems);
            hs.Remove("");
            return hs;
        }
		
        static string Capitalize(string word, string w_neutralform)
        {
            if (word.Length < 1) return word;
            if (word.StartsWith("_")) return word;
            if (w_neutralform.Length > 0 && char.IsUpper(w_neutralform[0]))
            {
                return char.ToUpper(word[0]) + word.Substring(1);
            }
            else return word;
        }


        static void subfunction_CaseSwitchVIR(ref Case c, Animated a)
        { 
            if (c == Case.VCase)
            { 
                if (a == Animated.False)
                {
                    c = Case.ICase;
                }
                else if (a == Animated.True)
                {
                    c = Case.RCase;
                }
            }
        }
    }
}