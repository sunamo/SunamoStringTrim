namespace SunamoStringTrim;

public class SHTrim
{
    public static string TrimStartingAndTrailingChars(string text, out StringBuilder fromStart,
        out StringBuilder fromEnd)
    {
        fromStart = new StringBuilder();
        fromEnd = new StringBuilder();
        var specialCharacter = 'a';

        for (var i = 0; i < text.Length; i++)
            if (CharHelper.IsSpecialChar(i, ref text, ref specialCharacter, true))
                fromStart.Append(specialCharacter);
            else
                break;

        for (var i = text.Length - 1; i >= 0; i--)
            if (CharHelper.IsSpecialChar(i, ref text, ref specialCharacter, true))
                fromEnd.Insert(0, specialCharacter);
            else
                break;

        return text;
    }

    public static string TrimIsNotNull(string text)
    {
        if (text != null) return text.Trim();
        return "";
    }

    public static string TrimNewLineAndTab(string text, bool isReplacingDoubleQuotes = false)
    {
        var result = text.Replace("\t", "").Replace("\r", "")
            .Replace("\n", "").Replace(" ", "");
        if (isReplacingDoubleQuotes)
            result = result.Replace("\"", "'");
        return result;
    }

    public static string TrimStartAndEnd(string text, Func<char, bool> isStartAllowed,
        Func<char, bool> isEndAllowed)
    {
        for (var i = 0; i < text.Length; i++)
            if (!isStartAllowed.Invoke(text[i]))
            {
                text = text.Substring(1);
                i--;
            }
            else
            {
                break;
            }

        for (var i = text.Length - 1; i >= 0; i--)
            if (!isEndAllowed.Invoke(text[i]))
                text = text.Remove(text.Length - 1, 1);
            else
                break;
        return text;
    }

    public static string TrimEndSpaces(string text)
    {
        return text.TrimEnd(' ');
    }

    public static string TrimBrackets(string text)
    {
        return text.TrimStart('(').TrimEnd(')');
    }

    public static string TrimStart(string text, string prefix)
    {
        while (text.StartsWith(prefix)) text = text.Substring(prefix.Length);

        return text;
    }

    public static string TrimEnd(string text)
    {
        WhitespaceCharService whitespaceCharService = new();
        return text.TrimEnd(whitespaceCharService.WhiteSpaceChars.ToArray());
    }

    public static bool TrimIfStartsWith(ref string text, string prefix)
    {
        if (text.StartsWith(prefix))
        {
            text = text.Substring(prefix.Length);
            return true;
        }

        return false;
    }

    public static string TrimEnd(string text, string suffix)
    {
        while (text.EndsWith(suffix)) text = text.Substring(0, text.Length - suffix.Length);
        return text;
    }

    public static string TrimStartAndEnd(string text, string prefix, string suffix)
    {
        text = TrimEnd(text, suffix);
        text = TrimStart(text, prefix);

        return text;
    }

    public static string Trim(string text, string trimText)
    {
        text = TrimStart(text, trimText);
        text = TrimEnd(text, trimText);

        return text;
    }

    public static string AdvancedTrim(string text)
    {
        return text.Replace(" ", "").Trim();
    }

    public static string TrimLeadingNumbersAtStart(string text)
    {
        while (text.Length > 0 && char.IsDigit(text[0]))
            text = text.Substring(1);

        return text;
    }

    public static string TrimTrailingNumbersAtEnd(string text)
    {
        while (text.Length > 0 && char.IsDigit(text[text.Length - 1]))
            text = text.Substring(0, text.Length - 1);

        return text;
    }
}
