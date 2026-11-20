namespace SunamoStringTrim;

/// <summary>
/// Represents the SH trim type.
/// </summary>
public class SHTrim
{
    /// <summary>
    /// Trim starting and trailing chars.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="fromStart">The from start.</param>
    /// <param name="fromEnd">The from end.</param>
    /// <returns>The trim starting and trailing chars result.</returns>
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

    /// <summary>
    /// Trim is not null.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The trim is not null result.</returns>
    public static string TrimIsNotNull(string text)
    {
        if (text != null) return text.Trim();
        return "";
    }

    /// <summary>
    /// Trim new line and tab.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="isReplacingDoubleQuotes">The is replacing double quotes.</param>
    /// <returns>The trim new line and tab result.</returns>
    public static string TrimNewLineAndTab(string text, bool isReplacingDoubleQuotes = false)
    {
        var result = text.Replace("\t", "").Replace("\r", "")
            .Replace("\n", "").Replace(" ", "");
        if (isReplacingDoubleQuotes)
            result = result.Replace("\"", "'");
        return result;
    }

    /// <summary>
    /// Trim start and end.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="isStartAllowed">The is start allowed.</param>
    /// <param name="isEndAllowed">The is end allowed.</param>
    /// <returns>The trim start and end result.</returns>
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

    /// <summary>
    /// Trim end spaces.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The trim end spaces result.</returns>
    public static string TrimEndSpaces(string text)
    {
        return text.TrimEnd(' ');
    }

    /// <summary>
    /// Trim brackets.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The trim brackets result.</returns>
    public static string TrimBrackets(string text)
    {
        return text.TrimStart('(').TrimEnd(')');
    }

    /// <summary>
    /// Trim start.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="prefix">The prefix.</param>
    /// <returns>The trim start result.</returns>
    public static string TrimStart(string text, string prefix)
    {
        while (text.StartsWith(prefix)) text = text.Substring(prefix.Length);

        return text;
    }

    /// <summary>
    /// Trim end.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The trim end result.</returns>
    public static string TrimEnd(string text)
    {
        WhitespaceCharService whitespaceCharService = new();
        return text.TrimEnd(whitespaceCharService.WhiteSpaceChars.ToArray());
    }

    /// <summary>
    /// Trim if starts with.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="prefix">The prefix.</param>
    /// <returns>The trim if starts with result.</returns>
    public static bool TrimIfStartsWith(ref string text, string prefix)
    {
        if (text.StartsWith(prefix))
        {
            text = text.Substring(prefix.Length);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Trim end.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="suffix">The suffix.</param>
    /// <returns>The trim end result.</returns>
    public static string TrimEnd(string text, string suffix)
    {
        while (text.EndsWith(suffix)) text = text.Substring(0, text.Length - suffix.Length);
        return text;
    }

    /// <summary>
    /// Trim start and end.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="prefix">The prefix.</param>
    /// <param name="suffix">The suffix.</param>
    /// <returns>The trim start and end result.</returns>
    public static string TrimStartAndEnd(string text, string prefix, string suffix)
    {
        text = TrimEnd(text, suffix);
        text = TrimStart(text, prefix);

        return text;
    }

    /// <summary>
    /// Trim.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="trimText">The trim text.</param>
    /// <returns>The trim result.</returns>
    public static string Trim(string text, string trimText)
    {
        text = TrimStart(text, trimText);
        text = TrimEnd(text, trimText);

        return text;
    }

    /// <summary>
    /// Advanced trim.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The advanced trim result.</returns>
    public static string AdvancedTrim(string text)
    {
        return text.Replace(" ", "").Trim();
    }

    /// <summary>
    /// Trim leading numbers at start.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The trim leading numbers at start result.</returns>
    public static string TrimLeadingNumbersAtStart(string text)
    {
        while (text.Length > 0 && char.IsDigit(text[0]))
            text = text.Substring(1);

        return text;
    }

    /// <summary>
    /// Trim trailing numbers at end.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The trim trailing numbers at end result.</returns>
    public static string TrimTrailingNumbersAtEnd(string text)
    {
        while (text.Length > 0 && char.IsDigit(text[text.Length - 1]))
            text = text.Substring(0, text.Length - 1);

        return text;
    }
}
