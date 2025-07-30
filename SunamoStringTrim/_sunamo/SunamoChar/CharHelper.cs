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








}