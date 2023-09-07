namespace Hw9.ErrorMessages;

public static class MathErrorMessager
{
    public const string DivisionByZero = "Division by zero";
    public const string EmptyString =  "Empty string";
    public const string IncorrectBracketsNumber = "The number of closing and opening brackets does not match";
    public const string StartingWithOperation =  "An expression cannot start with an operation sign";
    public const string EndingWithOperation =  "An expression cannot end with an operation sign";
    public const string NotNumber =  "There is no such number";
    public const string UnknownCharacter =  "Unknown character";
    public const string TwoOperationInRow = "There are two operations in a row";
    public const string InvalidOperatorAfterParenthesis = "After the opening brackets, only negation can go";
    public const string OperationBeforeParenthesis = "There is only a number before the closing parenthesis";

    public static string NotNumberMessage(string num) =>
        $"{NotNumber} {num}";
    
    public static string UnknownCharacterMessage(char symbol) =>
        $"{UnknownCharacter} {symbol}";

    public static string TwoOperationInRowMessage(string firstOperation, string secondOperation) =>
        $"{TwoOperationInRow} {firstOperation} and {secondOperation}";

    public static string InvalidOperatorAfterParenthesisMessage(string operation) =>
        $"{InvalidOperatorAfterParenthesis} ({operation}";

    public static string OperationBeforeParenthesisMessage(string operation) =>
        $"{OperationBeforeParenthesis} {operation})";
}