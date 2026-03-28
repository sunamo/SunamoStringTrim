# SunamoStringTrim

A lightweight .NET library providing various string trimming utilities beyond what the standard `String.Trim()` offers.

## Features

- **TrimStartingAndTrailingChars** - Trims special characters (whitespace and punctuation) from both ends, collecting removed characters
- **TrimIsNotNull** - Null-safe trim that returns empty string for null input
- **TrimNewLineAndTab** - Removes tab, carriage return, newline, and non-breaking space characters
- **TrimStartAndEnd** - Trims characters using custom predicate functions
- **TrimEndSpaces** - Trims trailing spaces
- **TrimBrackets** - Removes surrounding parentheses
- **TrimStart / TrimEnd** - Trims specified prefix or suffix strings (repeating)
- **TrimIfStartsWith** - Conditionally trims a prefix and returns whether it was found
- **Trim** - Trims a substring from both ends
- **AdvancedTrim** - Removes non-breaking spaces and trims whitespace
- **TrimLeadingNumbersAtStart / TrimTrailingNumbersAtEnd** - Removes numeric characters from start or end

## Installation

```
dotnet add package SunamoStringTrim
```

## Target Frameworks

`net10.0`, `net9.0`, `net8.0`

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

For feature requests or bug reports: [Email](mailto:radek.jancik@sunamo.cz) or open an issue on GitHub.
