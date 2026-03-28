using System.Text;

namespace SunamoStringTrim.Tests;

/// <summary>
/// Tests for the <see cref="SHTrim"/> class.
/// </summary>
public class SHTrimTests
{
    /// <summary>
    /// Verifies that null input returns an empty string.
    /// </summary>
    [Fact]
    public void TrimIsNotNull_WithNullInput_ReturnsEmptyString()
    {
        var result = SHTrim.TrimIsNotNull(null!);
        Assert.Equal("", result);
    }

    /// <summary>
    /// Verifies that whitespace-padded input is trimmed.
    /// </summary>
    [Fact]
    public void TrimIsNotNull_WithWhitespace_ReturnsTrimmed()
    {
        var result = SHTrim.TrimIsNotNull("  hello  ");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that a normal string without whitespace is returned unchanged.
    /// </summary>
    [Fact]
    public void TrimIsNotNull_WithNormalString_ReturnsSame()
    {
        var result = SHTrim.TrimIsNotNull("hello");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that tab, carriage return, and newline characters are removed.
    /// </summary>
    [Fact]
    public void TrimNewLineAndTab_RemovesTabAndNewlines()
    {
        var result = SHTrim.TrimNewLineAndTab("hello\tworld\r\n");
        Assert.Equal("helloworld", result);
    }

    /// <summary>
    /// Verifies that double quotes are replaced with single quotes when the flag is set.
    /// </summary>
    [Fact]
    public void TrimNewLineAndTab_WithDoubleQuoteReplacement_ReplacesQuotes()
    {
        var result = SHTrim.TrimNewLineAndTab("say \"hello\"", true);
        Assert.Equal("say 'hello'", result);
    }

    /// <summary>
    /// Verifies that trailing spaces are removed.
    /// </summary>
    [Fact]
    public void TrimEndSpaces_RemovesTrailingSpaces()
    {
        var result = SHTrim.TrimEndSpaces("hello   ");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that a string without trailing spaces is returned unchanged.
    /// </summary>
    [Fact]
    public void TrimEndSpaces_NoTrailingSpaces_ReturnsSame()
    {
        var result = SHTrim.TrimEndSpaces("hello");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that surrounding parentheses are removed.
    /// </summary>
    [Fact]
    public void TrimBrackets_RemovesSurroundingParentheses()
    {
        var result = SHTrim.TrimBrackets("(hello)");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that all leading '(' and trailing ')' are removed.
    /// </summary>
    [Fact]
    public void TrimBrackets_WithNestedParentheses_RemovesAll()
    {
        var result = SHTrim.TrimBrackets("((hello))");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that a repeated prefix is removed from the start.
    /// </summary>
    [Fact]
    public void TrimStart_RemovesPrefixRepeatedly()
    {
        var result = SHTrim.TrimStart("///hello", "/");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that a string without the prefix is returned unchanged.
    /// </summary>
    [Fact]
    public void TrimStart_NoPrefixMatch_ReturnsSame()
    {
        var result = SHTrim.TrimStart("hello", "/");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that the specified suffix is removed from the end.
    /// </summary>
    [Fact]
    public void TrimEnd_WithSuffix_RemovesSuffix()
    {
        var result = SHTrim.TrimEnd("hello.txt", ".txt");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that a string without the suffix is returned unchanged.
    /// </summary>
    [Fact]
    public void TrimEnd_NoSuffixMatch_ReturnsSame()
    {
        var result = SHTrim.TrimEnd("hello", ".txt");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that trailing whitespace characters are trimmed.
    /// </summary>
    [Fact]
    public void TrimEnd_WithoutSuffix_TrimsWhitespace()
    {
        var result = SHTrim.TrimEnd("hello   ");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that the prefix is removed and true is returned when the string starts with it.
    /// </summary>
    [Fact]
    public void TrimIfStartsWith_WhenStarts_TrimsAndReturnsTrue()
    {
        var text = "prefix_hello";
        var result = SHTrim.TrimIfStartsWith(ref text, "prefix_");
        Assert.True(result);
        Assert.Equal("hello", text);
    }

    /// <summary>
    /// Verifies that false is returned and the string is unchanged when prefix is not found.
    /// </summary>
    [Fact]
    public void TrimIfStartsWith_WhenNotStarts_ReturnsFalse()
    {
        var text = "hello";
        var result = SHTrim.TrimIfStartsWith(ref text, "prefix_");
        Assert.False(result);
        Assert.Equal("hello", text);
    }

    /// <summary>
    /// Verifies that both prefix and suffix are removed.
    /// </summary>
    [Fact]
    public void TrimStartAndEnd_RemovesPrefixAndSuffix()
    {
        var result = SHTrim.TrimStartAndEnd("[hello]", "[", "]");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that the substring is removed from both ends.
    /// </summary>
    [Fact]
    public void Trim_RemovesFromBothEnds()
    {
        var result = SHTrim.Trim("---hello---", "-");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that non-breaking spaces are removed and whitespace is trimmed.
    /// </summary>
    [Fact]
    public void AdvancedTrim_RemovesNonBreakingSpacesAndTrims()
    {
        var result = SHTrim.AdvancedTrim("\u00A0 hello \u00A0");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that leading digits are removed from the start.
    /// </summary>
    [Fact]
    public void TrimLeadingNumbersAtStart_RemovesLeadingDigits()
    {
        var result = SHTrim.TrimLeadingNumbersAtStart("123hello");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that a string without leading digits is returned unchanged.
    /// </summary>
    [Fact]
    public void TrimLeadingNumbersAtStart_NoDigits_ReturnsSame()
    {
        var result = SHTrim.TrimLeadingNumbersAtStart("hello");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that trailing digits are removed from the end.
    /// </summary>
    [Fact]
    public void TrimTrailingNumbersAtEnd_RemovesTrailingDigits()
    {
        var result = SHTrim.TrimTrailingNumbersAtEnd("hello123");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that a string without trailing digits is returned unchanged.
    /// </summary>
    [Fact]
    public void TrimTrailingNumbersAtEnd_NoDigits_ReturnsSame()
    {
        var result = SHTrim.TrimTrailingNumbersAtEnd("hello");
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that characters are trimmed using custom predicate functions.
    /// </summary>
    [Fact]
    public void TrimStartAndEnd_WithPredicates_TrimsCorrectly()
    {
        var result = SHTrim.TrimStartAndEnd("...hello...", character => character != '.',
            character => character != '.');
        Assert.Equal("hello", result);
    }

    /// <summary>
    /// Verifies that special characters are removed from start and end, collecting them in StringBuilders.
    /// </summary>
    [Fact]
    public void TrimStartingAndTrailingChars_RemovesSpecialChars()
    {
        var result = SHTrim.TrimStartingAndTrailingChars("  hello  ", out StringBuilder fromStart,
            out StringBuilder fromEnd);
        Assert.NotNull(fromStart);
        Assert.NotNull(fromEnd);
    }
}
