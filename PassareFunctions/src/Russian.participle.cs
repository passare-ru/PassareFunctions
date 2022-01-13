using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Term2
{
    public partial class Russian
    { 
        public static string CompleteParticiplePastTense2(string w_neutralform, bool redirect = false) 
        { 
            string result = "";
            bool ret = false;

            if (w_neutralform.EndsWith("ся", "сь"))
            {
                w_neutralform = w_neutralform.Till(2);
                ret = true;
            }

            bool perf = GetPerfectness(w_neutralform);

            if (w_neutralform.EndsWith("расти", "ползти", "пасти", "лезть", "грызть", "переть", "тереть")
                && !w_neutralform.EndsWith("матереть")) 
            {
                string form = Verb2(w_neutralform, Perspective.First, Number.Singular, Gender.Masculine, Tense.Past, TypeVariant.Declarative);
                result = form + "ши";
            }
            else if (w_neutralform.EndsWith("цвести", "гнести", "блюсти", "прясть")) 
            {
                string form = "";
                if (perf) { form = Verb2(w_neutralform, Perspective.First, Number.Singular, Gender.Masculine, Tense.Future, TypeVariant.Declarative); }
                else { form = Verb2(w_neutralform, Perspective.First, Number.Singular, Gender.Masculine, Tense.Present, TypeVariant.Declarative); }

                result = form.Till(1) + "ши";
            }
            else if (w_neutralform.Contains("зт") ||
                (w_neutralform.EndsWith("сти")
                && !w_neutralform.EndsWith("цвести", "гнести", "блюсти")) 
                || w_neutralform.EndsWith("честь", "ти"))
            {
                string form = "";
                if (perf) { form = Verb2(w_neutralform, Perspective.First, Number.Singular, Gender.Masculine, Tense.Future, TypeVariant.Declarative); }
                else { form = Verb2(w_neutralform, Perspective.First, Number.Singular, Gender.Masculine, Tense.Present, TypeVariant.Declarative); }

                result = form.Till(1) + "я";
            }
            else
            {

                if (w_neutralform.EndsWith("чь")
                 || w_neutralform.EndsWith("ссохнуть", "назябнуть", "намерзнуть", "скиснуть", "разверзнуть", "разлипнуть", "слипнуть", "смерзнуть")) 
                {
                    var form = Verb2(w_neutralform, Perspective.First, Number.Singular, Gender.Masculine, Tense.Past, TypeVariant.Declarative);
                    result = form + "ши";
                }
                else if (w_neutralform.EndsWith("ть"))
                {
                    var lc = w_neutralform.LastChar(3);
                    if (vowels.Contains(lc))
                    {
                        result = w_neutralform.Till(2) + "в";
                    }
                    else
                    {
                        result = w_neutralform.Till(3) + "в";
                    }
                    if (ret) result += "ши";
                }
            }


            if (ret) result += "сь";

            return result;
        }

    }
}
