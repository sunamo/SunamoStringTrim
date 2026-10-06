namespace SunamoStringTrim._sunamo.SunamoChar;

internal class CharHelper
{
    internal static bool IsSpecialChar(int index, ref string text, ref char character,
        bool isImmediatelyRemoving = false)
    {
        character = text[index];
        return IsSpecialChar(character, ref text, index, isImmediatelyRemoving);
    }

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
