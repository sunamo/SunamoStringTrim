namespace SunamoStringTrim._sunamo.SunamoChar;

/// <summary>
/// Helper class for character classification (whitespace, punctuation, special characters).
/// </summary>
internal class CharHelper
{
    /// <summary>
    /// Determines whether the character at the specified index is a special character (whitespace or punctuation).
    /// </summary>
    /// <param name="index">The index of the character to check.</param>
    /// <param name="text">The source string, which may be modified if immediate removal is enabled.</param>
    /// <param name="character">Outputs the character found at the specified index.</param>
    /// <param name="isImmediatelyRemoving">If true, removes the character from the string when it is special.</param>
    /// <returns>True if the character is a special character; otherwise, false.</returns>
    internal static bool IsSpecialChar(int index, ref string text, ref char character,
        bool isImmediatelyRemoving = false)
    {
        character = text[index];
        return IsSpecialChar(character, ref text, index, isImmediatelyRemoving);
    }

    /// <summary>
    /// Determines whether the specified character is a special character (whitespace or punctuation),
    /// excluding parentheses, backslash, and curly braces.
    /// </summary>
    /// <param name="character">The character to check.</param>
    /// <param name="text">The source string, which may be modified if immediate removal is enabled.</param>
    /// <param name="index">The index of the character in the string. Required when immediate removal is enabled.</param>
    /// <param name="isImmediatelyRemoving">If true, removes the character from the string when it is special.</param>
    /// <returns>True if the character is a special character; otherwise, false.</returns>
    private static bool IsSpecialChar(char character, ref string text, int index = -1,
        bool isImmediatelyRemoving = false)
    {
        if (character == '(' || character == ')') return false;
        if (character == '\\' || character == '{' || character == '}') return false;
        if (character == '-') return true;
        if (char.IsWhiteSpace(character))
        {
            if (isImmediatelyRemoving && text != null) text = text.Remove(index, 1);
            return true;
        }

        if (char.IsPunctuation(character))
        {
            if (isImmediatelyRemoving && text != null) text = text.Remove(index, 1);
            return true;
        }

        return false;
    }
}
