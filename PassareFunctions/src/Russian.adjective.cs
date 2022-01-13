using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace Term2
{
    public partial class Russian
    { 
        public static string[] PossessiveAdjectives = GetList(@"data/Russian Posssesive Adjectives.txt").ToArray();
        static string[,] adjectiveCases = 
        {
             {"","","","","",""},
            
             { "ий",    "его",     "ему",   "ий",   "им",   "ем" },//1
             { "ий",    "его",     "ему",   "его",  "им",   "ем" },
             { "яя",    "ей",      "ей",    "юю",   "ей",   "ей" },
             { "ее",    "его",     "ему",   "ее",   "им",   "ем" },
             { "ие",    "их",      "им",    "ие",   "ими",  "их" },
             { "ие",    "их",      "им",    "их",   "ими",  "их" },

             { "ий",    "его",     "ему",   "ий",   "им",   "ем" },//7  
             { "ий",    "его",     "ему",   "его",  "им",   "ем" },
             { "ая",    "ей",      "ей",    "ую",   "ей",   "ей" },
             { "ее",    "его",     "ему",   "ее",   "им",   "ем" },
             { "ие",    "их",      "им",    "ие",   "ими",  "их" },
             { "ие",    "их",      "им",    "их",   "ими",  "их" },

             { "ий",    "ого",     "ому",   "ий",   "им",   "ом" },//13
             { "ий",    "ого",     "ому",   "ого",  "им",   "ом" },
             { "ая",    "ой",      "ой",    "ую",   "ой",   "ой" },
             { "ое",    "ого",     "ому",   "ое",   "им",   "ом" },
             { "ие",    "их",      "им",    "ие",   "ими",  "их" },
             { "ие",    "их",      "им",    "их",   "ими",  "их" },

             { "ий",    "ьего",    "ьему",  "ий",   "ьим",  "ьем" },//19
             { "ий",    "ьего",    "ьему",  "ьего", "ьим",  "ьем" },
             { "ья",    "ьей",     "ьей",   "ью",   "ьей",  "ьей" },
             { "ье",    "ьего",    "ьему",  "ье",   "ьим",  "ьем" },
             { "ьи",    "ьих",     "ьим",   "ьи",   "ьими", "ьих" },
             { "ьи",    "ьих",     "ьим",   "ьих",  "ьими", "ьих" },
            
             {"ый", "ого", "ому", "ый", "ым", "ом"},//25
             {"ый", "ого", "ому", "ого", "ым", "ом"},  
             {"ая", "ой", "ой", "ую", "ой", "ой"},  
             {"ое", "ого", "ому", "ое", "ым", "ом"},  
             {"ые", "ых", "ым", "ые", "ыми", "ых"},  
             {"ые", "ых", "ым", "ых", "ыми", "ых"},  
            
             {"ой", "ого", "ому", "ой", "ым", "ом"},//31
             {"ой", "ого", "ому", "ого", "ым", "ом"},  
             {"ая", "ой", "ой", "ую", "ой", "ой"},  
             {"ое", "ого", "ому", "ое", "ым", "ом"},  
             {"ые", "ых", "ым", "ые", "ыми", "ых"},  
             {"ые", "ых", "ым", "ых", "ыми", "ых"},  
	        
             {"ой", "ого", "ому", "ой", "им", "ом"},//37  
             {"ой", "ого", "ому", "ого", "им", "ом"},  
             {"ая", "ой", "ой", "ую", "ой", "ой"},  
             {"ое", "ого", "ому", "ого", "им", "ом"},  
             {"ие", "их", "им", "ие", "ими", "их"},  
             {"ие", "их", "им", "их", "ими", "их"},  
            
             {"ый", "его", "ему", "ый", "ым", "ем"},//43
             {"ый", "его", "ему", "его", "ым", "ем"},  
             {"ая", "ей", "ей", "ую", "ей", "ей"},  
             {"ее", "его", "ему", "ее", "ым", "ем"},  
             {"ые", "ых", "ым", "ые", "ыми", "ых"},  
             {"ые", "ых", "ым", "ых", "ыми", "ых"},  

             
             {"ий", "ого", "ому", "ий", "им", "ом"},//49
             {"ий", "ого", "ому", "ого", "им", "ом"},  
             {"ая", "ой", "ой", "ую", "ой", "ой"},  
             {"ое", "ого", "ому", "ое", "им", "ом"},  
             {"ие", "их", "им", "ие", "ими", "их"},  
             {"ие", "их", "им", "их", "ими", "их"}, 
        };
        public static bool IsAdjective(string w_neutralform)
        {
            return w_neutralform.ToLower().EndsWith("ий", "ый", "ой", "ая", "яя", "ые", "ие");
        }
        public static string Adjective(string w_neutralform, Number n, Gender g, Case c, bool animated)
        {
            if (string.IsNullOrWhiteSpace(w_neutralform)) return w_neutralform;
            if (w_neutralform.Length < 3) return w_neutralform;

            string inputform = w_neutralform;
            w_neutralform = w_neutralform.ToLower();

            if (n == Number.FirstPlural)
            {
                n = Number.Plural;

                if (animated) c = Case.RCase;
                else c = Case.ICase;
            }
            else if (n == Number.SecondPlural)
            {
                n = Number.Plural;
                if (animated) 
                    c = Case.RCase;
                else c = Case.ICase;
            }
            if (w_neutralform.EndsWith("гой", "хой", "кой", "жой", "шой", "кий"))
            {
                if (c == Case.VCase && n == Number.Singular && g == Gender.Neuter && !animated)
                {
                    c = Case.ICase;
                }
            }
            string ending = w_neutralform.Last(2);
            char baseend = w_neutralform[w_neutralform.Length - 3];
            string w_baseform = w_neutralform.Till(2);
            int rcase = 0;
            if (w_neutralform.EndsWith("шеий")) { ending = "ее"; }
            
            if (ending == "ые") ending = "ый"; 
            switch (ending)
            {
                case "ий":
                    {
                        if (PossessiveAdjectives.Contains(w_neutralform)) rcase = 19 + subfunction_Adjective(n, g, animated);
                        else if (baseend == 'н' || w_neutralform == "карий" || w_neutralform == "орлий" || w_neutralform == "тугосисий") rcase = 1 + subfunction_Adjective(n, g, animated);
                        else if (ShConsonants.Contains(baseend) ) rcase = 7 + subfunction_Adjective(n, g, animated); 
                        else if (GConsonants.Contains(baseend)) rcase = 13 + subfunction_Adjective(n, g, animated);
                        else { rcase = 19 + subfunction_Adjective(n, g, animated); }
                    } break;
                case "ый" : 
                    {
                        if (CommonConsonants.Contains(baseend)) rcase = 25 + subfunction_Adjective(n, g, animated);
                        else if (baseend == 'ц') rcase = 43 + subfunction_Adjective(n, g, animated); 
                    } break;
                case "ая":
                    {
                        if (CommonConsonants.Contains(baseend) || baseend == 'к') rcase = 49 + subfunction_Adjective(n, g, animated);
                        else if (baseend == 'ц') rcase = 43 + subfunction_Adjective(n, g, animated); 
                    } break;
                case "яя":
                    {
                        if (CommonConsonants.Contains(baseend) || baseend == 'ц') rcase = 1 + subfunction_Adjective(n, g, animated); 
                    }break;
                case "ее":
                    {
                        rcase = 1 + subfunction_Adjective(n, g, animated); 
                    }break;
                case "ой":
                    {
                        if (CommonConsonants.Contains(baseend)) rcase = 31 + subfunction_Adjective(n, g, animated);
                        else if (ShConsonants.Contains(baseend)) rcase = 37 + subfunction_Adjective(n, g, animated);
                        else rcase = 37 + subfunction_Adjective(n, g, animated); 
                    } break;
            }
            if (rcase == 0)
            {
                return "";
            }
            else
            {
                return Capitalize(w_baseform + adjectiveCases[rcase, ((int)c - 1)], inputform);
            }
        }
        static int subfunction_Adjective(Number n, Gender g, bool animated)
        {
            if (n == Number.Singular)
            {
                if (g == Gender.Masculine)
                {
                    if (!animated)                      return 0;
                    else                                return 1;
                }
                else if (g == Gender.Feminine)          return 2;
                else/* if (g == Gender.Neuter)*/        return 3; 
            }
            else
            {
                if (!animated)                          return 4;
                else                                    return 5;
            }
        }
		
        public static string AdjectiveShortForm(string w_neutralform, Number n, Gender g)
        {
            int id = subfunction_Adjective(n, g, true);
            string[] aid1 = { "-", "ен", "на", "но", "-", "ны" };
            if (w_neutralform == "должен")
            {
                return w_neutralform.Till(2) + aid1[id];
            }
            return "";
        }
        public static string AdjectiveComparisonForm(string w_neutralform, Number n, Gender g, Case c, bool a, Form degree)
        {
            string result = ""; 
            int id = subfunction_Adjective(n, g, true);
            string[] aid1 = { "-", "ший", "шая", "шое", "-", "шие" };
            if (w_neutralform.EndsWith("ший", "шая", "шое", "шие"))
            {
                if (degree == Form.Superlative) result = w_neutralform.Till(3) + aid1[id];
            }
            else if (w_neutralform.EndsWith("ый", "ий"))
            {
                if (w_neutralform.EndsWith("дешевый"))
                {
                    if (degree == Form.Comparative) result = w_neutralform.Till(2) + "ле";
                    if (degree == Form.Superlative) result = Adjective(w_neutralform.Till(2) + "ейший", n, g, c, a);
                }
                else if (w_neutralform.EndsWith("икий", "ркий", "гкий", "окий"))
                {
                    if (degree == Form.Comparative) result = w_neutralform.Till(3) + (w_neutralform.EndsWith("гкий") ? "че" : "чее");
                    if (degree == Form.Superlative) result = Adjective(w_neutralform.Till(3) + "чайший", n, g, c, a);
                }
                else if (w_neutralform.EndsWith("изкий"))
                {
                    if (degree == Form.Comparative) result = w_neutralform.Till(4) + "же";
                    if (degree == Form.Superlative) result = Adjective(w_neutralform.Till(4) + "жайший", n, g, c, a);
                }
                else
                {
                    if (degree == Form.Comparative) result = w_neutralform.Till(2) + "ее";
                    if (degree == Form.Superlative) result = Adjective(w_neutralform.Till(2) + "ейший", n, g, c, a);
                }
            }
            return result;
        }

        public static string[] GetAdjectiveForms(string inf)
        {
            List<string> forms = new List<string>(111);
            forms.Add(inf);

            forms.Add(Adjective(inf, Number.Singular, Gender.Masculine, Case.ICase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Neuter, Case.ICase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Feminine, Case.ICase, false));
            forms.Add(Adjective(inf, Number.Plural, Gender.Masculine, Case.ICase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Masculine, Case.RCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Neuter, Case.RCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Feminine, Case.RCase, false));
            forms.Add(Adjective(inf, Number.Plural, Gender.Masculine, Case.RCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Masculine, Case.DCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Neuter, Case.DCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Feminine, Case.DCase, false));
            forms.Add(Adjective(inf, Number.Plural, Gender.Masculine, Case.DCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Masculine, Case.VCase, true));
            forms.Add(Adjective(inf, Number.Singular, Gender.Neuter, Case.VCase, true));
            forms.Add(Adjective(inf, Number.Singular, Gender.Feminine, Case.VCase, true));
            forms.Add(Adjective(inf, Number.Plural, Gender.Masculine, Case.VCase, true));
            forms.Add(Adjective(inf, Number.Singular, Gender.Masculine, Case.VCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Neuter, Case.VCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Feminine, Case.VCase, false));
            forms.Add(Adjective(inf, Number.Plural, Gender.Masculine, Case.VCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Masculine, Case.TCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Neuter, Case.TCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Feminine, Case.TCase, false));
            forms.Add(Adjective(inf, Number.Plural, Gender.Masculine, Case.TCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Masculine, Case.PCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Neuter, Case.PCase, false));
            forms.Add(Adjective(inf, Number.Singular, Gender.Feminine, Case.PCase, false));
            forms.Add(Adjective(inf, Number.Plural, Gender.Masculine, Case.PCase, false));

            return forms.ToArray();
        }
    }
}
