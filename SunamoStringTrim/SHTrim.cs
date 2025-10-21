// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoStringTrim;

// //: SHData mi způsobilo chyby Reference to type ' ' claims it is defined in ' ', but it could not be found. důvod byl jednoduchý, původně jsem chtěl dědit z SHSE který bude dědit z SHData. Pak jsem to ale obrátil. Neměl jsem zkompilované nové SunamoStringData ve kterém nebylo SunExc a VS sice ví kde hledaná třída je ale neřekne přímo ten problém. Proto to vše bylo takové matoucí.
public class SHTrim //: SHData
{
    public static string TrimStartingAndTrailingChars(string html, out StringBuilder fromStart,
        out StringBuilder fromEnd)
    {
        fromStart = new StringBuilder();
        fromEnd = new StringBuilder();
        var specialChar = 'a';

        for (var i = 0; i < html.Length; i++)
            if (CharHelper.IsSpecialChar(i, ref html, ref specialChar, true))
                fromStart.Append(specialChar);
            else
                break;

        for (var i = html.Length - 1; i >= 0; i--)
            if (CharHelper.IsSpecialChar(i, ref html, ref specialChar, true))
                fromEnd.Insert(0, specialChar);
            else
                break;

        return html;
    }

    /// <summary>
    ///     Vrátí SE když A1 bude null, pokud null nebude, trimuje ho
    /// </summary>
    /// <param name="p"></param>
    public static string TrimIsNotNull(string p)
    {
        if (p != null) return p.Trim();
        return "";
    }

    public static string TrimNewLineAndTab(string lyricsFirstOriginal, bool replaceDoubleSpaceForSingle = false)
    {
        var result = lyricsFirstOriginal.Replace("\t", "").Replace("\r", "")
            .Replace("\n", "").Replace(" ", "");
        if (replaceDoubleSpaceForSingle)
            result = result.Replace("\"", "'"); //SHReplace.ReplaceAllDoubleSpaceToSingle(result, true);
        return result;
    }

    public static string TrimStartAndEnd(string target, Func<char, bool> startAllowed, Func<char, bool> endAllowed)
    {
        for (var i = 0; i < target.Length; i++)
            if (!startAllowed.Invoke(target[i]))
            {
                target = target.Substring(1);
                i--;
            }
            else
            {
                break;
            }

        for (var i = target.Length - 1; i >= 0; i--)
            if (!endAllowed.Invoke(target[i]))
                target = target.Remove(target.Length - 1, 1);
            else
                break;
        return target;
    }

    public static string TrimEndSpaces(string v)
    {
        return v.TrimEnd(' ');
    }

    public static string TrimBrackets(string ratingCount)
    {
        return ratingCount.TrimStart('(').TrimEnd(')');
    }

    /// <summary>
    ///     Usage: Exceptions.TypeAndMethodName
    /// </summary>
    /// <param name="v"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string TrimStart(string v, string text)
    {
        while (v.StartsWith(text)) v = v.Substring(text.Length);

        return v;
    }

    public static string TrimEnd(string name)
    {
        WhitespaceCharService whitespaceChar = new();
        return name.TrimEnd(whitespaceChar.whiteSpaceChars.ToArray());
    }

    public static bool TrimIfStartsWith(ref string text, string p)
    {
        if (text.StartsWith(p))
        {
            text = text.Substring(p.Length);
            return true;
        }

        return false;
    }

    public static string TrimEnd(string name, string ext)
    {
        while (name.EndsWith(ext)) return name.Substring(0, name.Length - ext.Length);
        return name;
    }

    public static string TrimStartAndEnd(string v, string text, string e)
    {
        v = TrimEnd(v, e);
        v = TrimStart(v, text);

        return v;
    }

    /// <summary>
    ///     Trim from beginning and end of A1 substring A2
    /// </summary>
    /// <param name="s"></param>
    /// <param name="args"></param>
    public static string Trim(string text, string args)
    {
        text = TrimStart(text, args);
        text = TrimEnd(text, args);

        return text;
    }

    public static string AdvancedTrim(string p)
    {
        return p.Replace(" ", "").Trim();
    }

    public static string TrimLeadingNumbersAtStart(string nameSolution)
    {
        for (var i = 0; i < nameSolution.Length; i++)
        {
            var replace = false;
            for (var name = 0; name < 10; name++)
                if (nameSolution[i] == name.ToString()[0])
                {
                    replace = true;
                    nameSolution = nameSolution.Substring(1);
                    break;
                }

            if (!replace) return nameSolution;
        }

        return nameSolution;
    }


    public static string TrimTrailingNumbersAtEnd(string nameSolution)
    {
        for (var i = nameSolution.Length - 1; i >= 0; i--)
        {
            var replace = false;
            for (var name = 0; name < 10; name++)
                if (nameSolution[i] == name.ToString()[0])
                {
                    replace = true;
                    nameSolution = nameSolution.Length > 0
                        ? nameSolution.Substring(0, nameSolution.Length - 1)
                        : string.Empty;
                    break;
                }

            if (!replace) return nameSolution;
        }

        return nameSolution;
    }
}