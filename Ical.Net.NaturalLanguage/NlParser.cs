using Antlr4.Runtime;
using Ical.Net.DataTypes;

namespace Ical.Net.NaturalLanguage;

public class NlParser {
    public RecurrencePattern? Parse(string rawExpression, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday) {
        var stream = CharStreams.fromString(rawExpression.ToLower());
        var lexer = new RecurLexer(stream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new RecurParser(tokenStream);

        var context = parser.file();
        var visitor = new RecurVisitor(firstDayOfWeek);

        var rc = visitor.Visit(context);
        if (parser.NumberOfSyntaxErrors > 0) {
            return null;
        }

        return rc;
    }
}
