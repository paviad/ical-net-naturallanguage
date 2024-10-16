[![NuGet Version](https://img.shields.io/nuget/v/Ical.Net.NaturalLanguage)](https://www.nuget.org/packages/Ical.Net.NaturalLanguage/)

# Ical.Net.NaturalLanguage

This library adds natural language parsing and serialization to the Ical.Net library.
It uses Antlr and is partially based on ideas from [rrule.js](https://github.com/jkbrzt/rrule)

## Usage

Assume you want to parse the following phrase:

`Every week on sun, tue and thu at 2 and 16`

The expected rule should be:

`FREQ=WEEKLY;BYDAY=SU,TU,TH;BYHOUR=2,16`

The following code will parse the text into an `Ical.Net.RecurrencePattern` with the above rule.

```
    var p = new NlParser();
    var result = p.Parse("Every week on sun, tue and thu at 2 and 16");
    Assert.Equal("FREQ=WEEKLY;BYDAY=SU,TU,TH;BYHOUR=2,16", result.ToString());
```

See `/Ical.Net.NaturalLanguage.CoreUnitTests/Tests.cs` in this repository for more tests.
