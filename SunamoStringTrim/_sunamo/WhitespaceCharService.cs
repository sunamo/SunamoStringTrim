namespace SunamoStringTrim._sunamo;

internal class WhitespaceCharService
{
    internal List<char> WhiteSpaceChars { get; set; }

    internal readonly List<int> WhiteSpaceCodes = new(new[]
    {
        9, 10, 11, 12, 13, 32, 133, 160, 5760, 6158, 8192, 8193, 8194, 8195, 8196, 8197, 8198, 8199, 8200, 8201,
        8202, 8232, 8233, 8239, 8287, 12288
    });

    internal WhitespaceCharService()
    {
        WhiteSpaceChars = WhiteSpaceCodes.Select(code => (char)code).ToList();
    }
}
