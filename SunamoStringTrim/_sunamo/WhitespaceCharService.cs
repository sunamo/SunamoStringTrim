namespace SunamoStringTrim._sunamo;

/// <summary>
/// Provides a collection of whitespace characters and their Unicode code points.
/// </summary>
internal class WhitespaceCharService
{
    /// <summary>
    /// List of whitespace characters derived from their Unicode code points.
    /// </summary>
    internal List<char> WhiteSpaceChars { get; set; }

    /// <summary>
    /// List of Unicode code points representing whitespace characters.
    /// </summary>
    internal readonly List<int> WhiteSpaceCodes = new(new[]
    {
        9, 10, 11, 12, 13, 32, 133, 160, 5760, 6158, 8192, 8193, 8194, 8195, 8196, 8197, 8198, 8199, 8200, 8201,
        8202, 8232, 8233, 8239, 8287, 12288
    });

    /// <summary>
    /// Initializes a new instance and converts code points to characters.
    /// </summary>
    internal WhitespaceCharService()
    {
        WhiteSpaceChars = WhiteSpaceCodes.Select(code => (char)code).ToList();
    }
}
