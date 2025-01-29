namespace SunamoStringTrim._sunamo.SunamoChar;


internal class CharHelper
{


    
    /// <summary>
    ///     Return whether is whitespace or punctaction
    /// </summary>
    /// <param name="dx"></param>
    /// <param name="s"></param>
    /// <param name="ch"></param>
    internal static bool IsSpecialChar(int dx, ref string s, ref char ch, bool immediatelyRemove = false)
    {
        ch = s[dx];
        return IsSpecialChar(ch, ref s, dx, immediatelyRemove);
    }

    private static bool IsSpecialChar(char ch, ref string s, int dx = -1, bool immediatelyRemove = false)
    {
        if (ch == '(' || ch == ')') return false;
        if (ch == '\\' || ch == '{' || ch == '}') return false;
        if (ch == '-') return true;
        if (char.IsWhiteSpace(ch))
        {
            if (immediatelyRemove && s != null) s = s.Remove(dx, 1);
            return true;
        }

        if (char.IsPunctuation(ch))
        {
            if (immediatelyRemove && s != null) s = s.Remove(dx, 1);
            return true;
        }

        return false;
    }



    internal static bool IsUnicodeChar(UnicodeChars generic, char c)
    {
        switch (generic)
        {
            case UnicodeChars.Control:
                return char.IsControl(c);
            case UnicodeChars.HighSurrogate:
                return char.IsHighSurrogate(c);
            case UnicodeChars.Lower:
                return char.IsLower(c);
            case UnicodeChars.LowSurrogate:
                return char.IsLowSurrogate(c);
            case UnicodeChars.Number:
                return char.IsNumber(c);
            case UnicodeChars.Punctaction:
                return char.IsPunctuation(c);
            case UnicodeChars.Separator:
                return char.IsSeparator(c);
            case UnicodeChars.Surrogate:
                return char.IsSurrogate(c);
            case UnicodeChars.Symbol:
                return char.IsSymbol(c);
            case UnicodeChars.Upper:
                return char.IsUpper(c);
            case UnicodeChars.WhiteSpace:
                return char.IsWhiteSpace(c);
            case UnicodeChars.Special:
                return IsSpecial(c);
            case UnicodeChars.Generic:
                return IsGeneric(c);
            default:
                ThrowEx.NotImplementedCase(generic.ToString());
                return false;
        }
    }

    internal static bool IsSpecial(char c)
    {
        SpecialCharsService specialChars = new();

        var v = specialChars.specialChars.Contains(c);
        if (!v) v = specialChars.specialChars2.Contains(c);
        return v;
    }


    internal static bool IsGeneric(char c)
    {
        GeneralCharService generalChar = new();
        return generalChar.generalChars.Contains(c);
    }


}