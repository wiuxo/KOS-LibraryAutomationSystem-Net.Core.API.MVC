namespace KOS.Core.Constants;

public static class ValidatorMessage
{
    public const string IsStringMessage = "Must be a string Value";
    public const string IsNumericMessage = "Must be a numeric value";
    public const string IsNull = "Field cannot be empty";

    public const string IsSafePassw =
        "Invalid password. Must be between 8-32 characters, must contain at least one digit, " +
        "one lowercase letter, one uppercase letter and one special character";
}