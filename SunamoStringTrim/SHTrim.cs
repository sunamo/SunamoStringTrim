namespace SunamoStringTrim;

/// <summary>
/// Provides methods for trimming strings in various ways (whitespace, special characters, brackets, numbers, etc.).
/// </summary>
public class SHTrim
{
    /// <summary>
    /// Trims special characters (whitespace and punctuation) from the start and end of the string,
    /// collecting removed characters into separate StringBuilders.
    /// </summary>
    /// <param name="text">The input string to trim.</param>
    /// <param name="fromStart">Outputs the special characters removed from the start.</param>
    /// <param name="fromEnd">Outputs the special characters removed from the end.</param>
    /// <returns>The trimmed string with special characters removed.</returns>
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
    /// Returns an empty string when input is null; otherwise trims whitespace from the input.
    /// </summary>
    /// <param name="text">The input string to trim, or null.</param>
    /// <returns>The trimmed string, or an empty string if input is null.</returns>
    public static string TrimIsNotNull(string text)
    {
        if (text != null) return text.Trim();
        return "";
    }

    /// <summary>
    /// Removes tab, carriage return, newline, and non-breaking space characters from the string.
    /// Optionally replaces double quotes with single quotes.
    /// </summary>
    /// <param name="text">The input string to clean.</param>
    /// <param name="isReplacingDoubleQuotes">If true, replaces double quotes with single quotes.</param>
    /// <returns>The cleaned string.</returns>
    public static string TrimNewLineAndTab(string text, bool isReplacingDoubleQuotes = false)
    {
        var result = text.Replace("\t", "").Replace("\r", "")
            .Replace("\n", "").Replace("\u00A0", "");
        if (isReplacingDoubleQuotes)
            result = result.Replace("\"", "'");
        return result;
    }

    /// <summary>
    /// Trims characters from the start and end of the string using custom predicate functions.
    /// Characters are removed from the start while <paramref name="isStartAllowed"/> returns false,
    /// and from the end while <paramref name="isEndAllowed"/> returns false.
    /// </summary>
    /// <param name="text">The string to trim.</param>
    /// <param name="isStartAllowed">Predicate that returns true when a start character should be kept.</param>
    /// <param name="isEndAllowed">Predicate that returns true when an end character should be kept.</param>
    /// <returns>The trimmed string.</returns>
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
    /// Trims trailing spaces from the end of the string.
    /// </summary>
    /// <param name="text">The string to trim.</param>
    /// <returns>The string with trailing spaces removed.</returns>
    public static string TrimEndSpaces(string text)
    {
        return text.TrimEnd(' ');
    }

    /// <summary>
    /// Trims leading '(' and trailing ')' from the string.
    /// </summary>
    /// <param name="text">The string to trim.</param>
    /// <returns>The string with surrounding parentheses removed.</returns>
    public static string TrimBrackets(string text)
    {
        return text.TrimStart('(').TrimEnd(')');
    }

    /// <summary>
    /// Trims the specified prefix from the start of the string, repeatedly if it occurs multiple times.
    /// </summary>
    /// <param name="text">The string to trim.</param>
    /// <param name="prefix">The prefix to remove from the start.</param>
    /// <returns>The string with the prefix removed.</returns>
    public static string TrimStart(string text, string prefix)
    {
        while (text.StartsWith(prefix)) text = text.Substring(prefix.Length);

        return text;
    }

    /// <summary>
    /// Trims all trailing whitespace characters (including Unicode whitespace) from the string.
    /// </summary>
    /// <param name="text">The string to trim.</param>
    /// <returns>The string with trailing whitespace removed.</returns>
    public static string TrimEnd(string text)
    {
        WhitespaceCharService whitespaceCharService = new();
        return text.TrimEnd(whitespaceCharService.WhiteSpaceChars.ToArray());
    }

    /// <summary>
    /// If the string starts with the specified prefix, removes it and returns true; otherwise returns false.
    /// </summary>
    /// <param name="text">The string to check and modify.</param>
    /// <param name="prefix">The prefix to look for and remove.</param>
    /// <returns>True if the prefix was found and removed; otherwise, false.</returns>
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
    /// Trims the specified suffix from the end of the string.
    /// </summary>
    /// <param name="text">The string to trim.</param>
    /// <param name="suffix">The suffix to remove from the end.</param>
    /// <returns>The string with the suffix removed.</returns>
    public static string TrimEnd(string text, string suffix)
    {
        while (text.EndsWith(suffix)) text = text.Substring(0, text.Length - suffix.Length);
        return text;
    }

    /// <summary>
    /// Trims the specified prefix from the start and suffix from the end of the string.
    /// </summary>
    /// <param name="text">The string to trim.</param>
    /// <param name="prefix">The prefix to remove from the start.</param>
    /// <param name="suffix">The suffix to remove from the end.</param>
    /// <returns>The string with prefix and suffix removed.</returns>
    public static string TrimStartAndEnd(string text, string prefix, string suffix)
    {
        text = TrimEnd(text, suffix);
        text = TrimStart(text, prefix);

        return text;
    }

    /// <summary>
    /// Trims the specified substring from both the beginning and end of the string.
    /// </summary>
    /// <param name="text">The string to trim.</param>
    /// <param name="trimText">The substring to remove from both ends.</param>
    /// <returns>The trimmed string.</returns>
    public static string Trim(string text, string trimText)
    {
        text = TrimStart(text, trimText);
        text = TrimEnd(text, trimText);

        return text;
    }

    /// <summary>
    /// Removes all non-breaking spaces and then trims standard whitespace from the string.
    /// </summary>
    /// <param name="text">The string to trim.</param>
    /// <returns>The cleaned and trimmed string.</returns>
    public static string AdvancedTrim(string text)
    {
        return text.Replace("\u00A0", "").Trim();
    }

    /// <summary>
    /// Removes leading numeric characters from the start of the string.
    /// </summary>
    /// <param name="text">The string to process.</param>
    /// <returns>The string with leading numbers removed.</returns>
    public static string TrimLeadingNumbersAtStart(string text)
    {
        while (text.Length > 0 && char.IsDigit(text[0]))
            text = text.Substring(1);

        return text;
    }

    /// <summary>
    /// Removes trailing numeric characters from the end of the string.
    /// </summary>
    /// <param name="text">The string to process.</param>
    /// <returns>The string with trailing numbers removed.</returns>
    public static string TrimTrailingNumbersAtEnd(string text)
    {
        while (text.Length > 0 && char.IsDigit(text[text.Length - 1]))
            text = text.Substring(0, text.Length - 1);

        return text;
    }
}
